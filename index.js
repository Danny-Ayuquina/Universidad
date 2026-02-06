"use strict";
const express = require("express");
const responseTime = require("response-time");
const cors = require("cors");
const path = require("path");
const fs = require("fs");
const { createClient } = require("redis");
require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 3000;
const REDIS_URL = process.env.REDIS_URL || "redis://localhost:6379";

// Middlewares
app.use(cors());
app.use(express.json());
app.use(responseTime());

// Redis client
const redis = createClient({ url: REDIS_URL });
redis.on("error", (err) => console.error("Redis error:", err));
redis.on("connect", () => console.log("Redis connecting..."));
redis.on("ready", () => console.log("Redis ready"));
redis.on("reconnecting", () => console.log("Redis reconnecting..."));

const collections = ["clientes", "productos", "pedidos", "detalle_pedido"];
const idFieldMap = {
  clientes: "dni",
  productos: "codigo",
  pedidos: "codigo",
  detalle_pedido: "codigo",
};
const requiredFields = {
  clientes: ["dni", "nombres", "email", "telefono", "edad", "genero"],
  productos: ["codigo", "nombre", "categoria", "precio", "stock"],
  pedidos: ["codigo", "clienteId", "fecha", "subtotal", "iva", "total", "estado"],
  detalle_pedido: ["codigo", "productoId", "cantidad", "detalle", "precioUnit"],
};

function isValidCollection(col) {
  return collections.includes(col);
}
function getIdField(col) {
  return idFieldMap[col];
}
function getKey(col, id) {
  return `${col}:${id}`;
}
function getIndexKey(col) {
  return `idx:${col}`; // Set con los IDs para listar
}
function validateRecord(col, record) {
  const required = requiredFields[col] || [];
  const missing = required.filter((f) => !(f in record));
  return { ok: missing.length === 0, missing };
}

// Health check
app.get("/health", (req, res) => {
  res.json({ status: "ok", redis: redis.isOpen ? "connected" : "disconnected" });
});

async function seedFromFile() {
  const start = Date.now();
  const result = { inserted: 0, perCollection: {} };
  const dataPath = path.join(__dirname, "data", "tecnomega.json");
  const raw = await fs.promises.readFile(dataPath, "utf8");
  const json = JSON.parse(raw);

  for (const col of collections) {
    const arr = Array.isArray(json[col]) ? json[col] : [];
    result.perCollection[col] = 0;
    if (arr.length === 0) continue;

    for (const record of arr) {
      const { ok, missing } = validateRecord(col, record);
      if (!ok) {
        console.warn(`Registro inválido en ${col}: faltan campos`, missing);
        continue;
      }
      const idField = getIdField(col);
      const id = record[idField];
      const key = getKey(col, id);
      await redis.set(key, JSON.stringify(record));
      await redis.sAdd(getIndexKey(col), String(id));
      result.inserted += 1;
      result.perCollection[col] += 1;
    }
  }
  result.elapsedMs = Date.now() - start;
  return result;
}

// Seed: carga masiva desde JSON (endpoint)
app.post("/seed", async (req, res) => {
  try {
    const result = await seedFromFile();
    res.status(201).json(result);
  } catch (err) {
    console.error("Error en /seed:", err);
    res.status(500).json({ error: "Error al cargar datos", details: String(err) });
  }
});

// Guardar 1 registro (SET)
app.post("/:collection", async (req, res) => {
  try {
    const col = req.params.collection;
    if (!isValidCollection(col)) {
      return res.status(400).json({ error: "Colección inválida" });
    }
    const record = req.body;
    const { ok, missing } = validateRecord(col, record);
    if (!ok) {
      return res.status(400).json({ error: "Campos faltantes", missing });
    }
    const idField = getIdField(col);
    const id = record[idField];
    if (!id) {
      return res.status(400).json({ error: `Campo identificador '${idField}' requerido` });
    }
    const key = getKey(col, id);
    await redis.set(key, JSON.stringify(record));
    await redis.sAdd(getIndexKey(col), String(id));
    return res.status(201).json({ message: "Registro guardado", key, id });
  } catch (err) {
    console.error("Error en POST /:collection:", err);
    return res.status(500).json({ error: "Error al guardar registro", details: String(err) });
  }
});

// Obtener 1 registro (GET)
app.get("/:collection/:id", async (req, res) => {
  try {
    const col = req.params.collection;
    const id = req.params.id;
    if (!isValidCollection(col)) {
      return res.status(400).json({ error: "Colección inválida" });
    }
    const key = getKey(col, id);
    const value = await redis.get(key);
    if (!value) {
      return res.status(404).json({ error: "No encontrado" });
    }
    return res.json(JSON.parse(value));
  } catch (err) {
    console.error("Error en GET /:collection/:id:", err);
    return res.status(500).json({ error: "Error al obtener registro", details: String(err) });
  }
});

// Listar todos los registros de una tabla
app.get("/:collection", async (req, res) => {
  try {
    const col = req.params.collection;
    if (!isValidCollection(col)) {
      return res.status(400).json({ error: "Colección inválida" });
    }
    const ids = await redis.sMembers(getIndexKey(col));
    if (!ids || ids.length === 0) {
      return res.json([]);
    }
    const keys = ids.map((id) => getKey(col, id));
    // Obtener todos con MGET y tolerar valores malformados
    const values = await redis.mGet(keys);
    const items = [];
    let invalidCount = 0;
    for (const v of values) {
      if (!v) continue;
      try {
        items.push(JSON.parse(v));
      } catch (e) {
        invalidCount += 1;
      }
    }
    const payload = invalidCount > 0 ? { items, invalidCount } : items;
    return res.json(payload);
  } catch (err) {
    console.error("Error en GET /:collection:", err);
    return res.status(500).json({ error: "Error al listar registros", details: String(err) });
  }
});

// 404
app.use((req, res) => {
  res.status(404).json({ error: "Ruta no encontrada" });
});

async function start() {
  try {
    await redis.connect();
    app.listen(PORT, () => {
      console.log(`TecnoMega API escuchando en http://localhost:${PORT}`);
      console.log(`Redis: ${REDIS_URL}`);
    });

    if (String(process.env.AUTO_SEED).toLowerCase() === "true") {
      try {
        const result = await seedFromFile();
        console.log("Auto-seed completado:", result);
      } catch (e) {
        console.error("Auto-seed falló:", e);
      }
    }
  } catch (err) {
    console.error("No se pudo conectar a Redis:", err);
    process.exit(1);
  }
}

start();
