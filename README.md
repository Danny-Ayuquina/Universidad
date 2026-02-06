# TecnoMega API (Redis)

API REST en Node.js + Express para compra/venta de productos tecnológicos, usando Redis como base NoSQL clave–valor para almacenar catálogos y transacciones.

## Requisitos
- Node.js 18+
- Redis (local en `redis://localhost:6379` o variable `REDIS_URL`)

## Instalación
```bash
npm install
```

## Ejecutar
```bash
# desarrollo (recarga automática)
npm run dev

# producción
npm start
```

## Variables de entorno
- `PORT` (opcional, por defecto 3000)
- `REDIS_URL` (opcional, por defecto `redis://localhost:6379`)
 - `AUTO_SEED` (opcional, `true` para cargar automáticamente `data/tecnomega.json` al iniciar)

## Middlewares
- `express.json()` para parseo JSON
- `response-time` agrega cabecera `X-Response-Time`

## Modelo de datos
- `clientes`: dni, nombres, email, teléfono, edad, genero
- `productos`: código, nombre, categoría, precio, stock
- `pedidos`: código, clienteId, fecha, subtotal, iva, total, estado
- `detalle_pedido`: código, productoId, cantidad, detalle, precioUnit

Cada registro se guarda como string JSON en una key con prefijo `coleccion:id` y se mantiene un índice por colección en el Set `idx:coleccion`.

## Endpoints
- SET `/seed`: carga masiva desde `data/tecnomega.json`. Responde `{ inserted, perCollection, elapsedMs }` y cabecera `X-Response-Time`.
- SET `/:collection`: guarda 1 registro en la colección (`clientes|productos|pedidos|detalle_pedido`).
- GET `/:collection/:id`: obtiene 1 registro por id.
- GET `/:collection`: lista todos los registros de la colección.
- GET `/health`: estado de la API y conexión a Redis.

## Ejemplos
### Verificar en Redis (CLI)
Los datos se almacenan como claves String y un Set índice:
- Clave por registro: `clientes:0102030405`, `productos:P001`, etc.
- Índice por colección: `idx:clientes`, `idx:productos`, etc.

Comandos útiles:
```bash
# listar IDs registrados
redis-cli SMEMBERS idx:clientes

# obtener un registro por clave
redis-cli GET clientes:0102030405

# productos
redis-cli SMEMBERS idx:productos
redis-cli GET productos:P001
```
### Guardar un producto
```bash
curl -X POST http://localhost:3000/productos \
  -H "Content-Type: application/json" \
  -d '{
    "codigo":"P011",
    "nombre":"Tablet S",
    "categoria":"Tablets",
    "precio":299.0,
    "stock":15
  }'
```

### Obtener un cliente
```bash
curl http://localhost:3000/clientes/0102030405
```

### Listar productos
```bash
curl http://localhost:3000/productos
```

### Cargar seed
```bash
curl -X POST http://localhost:3000/seed
```

O habilita `AUTO_SEED=true` en `.env` para cargar automáticamente al iniciar.

## Evidencias
- Capturas en Postman/Thunder Client de cada endpoint (SET/GET, seed, list).
- Verificar la cabecera `X-Response-Time` en las respuestas.

## Manejo de errores
- Colección inválida: 400
- Campos faltantes: 400
- No encontrado: 404
- Error de servidor/Redis: 500

