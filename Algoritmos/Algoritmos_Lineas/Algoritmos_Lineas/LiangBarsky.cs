using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_Lineas
{
    internal class LiangBarsky
    {
        private RectangleF ventana;

        public LiangBarsky(RectangleF ventana)
        {
            this.ventana = ventana;
        }

        // Función para calcular el parámetro t
        private bool ClipTest(float p, float q, ref float t1, ref float t2, List<string> pasos)
        {
            if (p == 0)
            {
                if (q < 0)
                {
                    pasos.Add($"p = {p:F4}, q = {q:F4} → Línea paralela y fuera de la ventana - RECHAZADA");
                    return false;
                }
                else
                {
                    pasos.Add($"p = {p:F4}, q = {q:F4} → Línea paralela y dentro de la ventana");
                    return true;
                }
            }

            float r = q / p;
            pasos.Add($"p = {p:F4}, q = {q:F4} → r = q/p = {r:F4}");

            if (p < 0)
            {
                // Entrando a la ventana
                if (r > t2)
                {
                    pasos.Add($"  p < 0 (entrando): r ({r:F4}) > t2 ({t2:F4}) → RECHAZADA");
                    return false;
                }
                else if (r > t1)
                {
                    t1 = r;
                    pasos.Add($"  p < 0 (entrando): Actualizar t1 = {t1:F4}");
                }
                else
                {
                    pasos.Add($"  p < 0 (entrando): r ({r:F4}) ≤ t1 ({t1:F4}) → sin cambios");
                }
            }
            else
            {
                // Saliendo de la ventana
                if (r < t1)
                {
                    pasos.Add($"  p > 0 (saliendo): r ({r:F4}) < t1 ({t1:F4}) → RECHAZADA");
                    return false;
                }
                else if (r < t2)
                {
                    t2 = r;
                    pasos.Add($"  p > 0 (saliendo): Actualizar t2 = {t2:F4}");
                }
                else
                {
                    pasos.Add($"  p > 0 (saliendo): r ({r:F4}) ≥ t2 ({t2:F4}) → sin cambios");
                }
            }

            return true;
        }

        // Algoritmo de recorte de Liang-Barsky
        public LineaRecortada RecortarLinea(PointF p1, PointF p2)
        {
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;

            float dx = x2 - x1;
            float dy = y2 - y1;

            float t1 = 0.0f;
            float t2 = 1.0f;

            List<string> pasos = new List<string>();

            pasos.Add($"Punto inicial P1: ({x1:F2}, {y1:F2})");
            pasos.Add($"Punto final P2: ({x2:F2}, {y2:F2})");
            pasos.Add($"Δx = {dx:F2}, Δy = {dy:F2}");
            pasos.Add($"Ventana: ({ventana.Left:F2}, {ventana.Top:F2}) a ({ventana.Right:F2}, {ventana.Bottom:F2})");
            pasos.Add("Parámetros iniciales: t1 = 0, t2 = 1");
            pasos.Add("");

            // Prueba de recorte para cada borde
            pasos.Add("═══ Borde Izquierdo (x = xmin) ═══");
            if (!ClipTest(-dx, x1 - ventana.Left, ref t1, ref t2, pasos))
            {
                pasos.Add("Resultado: LÍNEA RECHAZADA");
                return new LineaRecortada
                {
                    Aceptada = false,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = p1,
                    P2Recortado = p2,
                    Pasos = pasos
                };
            }
            pasos.Add("");

            pasos.Add("═══ Borde Derecho (x = xmax) ═══");
            if (!ClipTest(dx, ventana.Right - x1, ref t1, ref t2, pasos))
            {
                pasos.Add("Resultado: LÍNEA RECHAZADA");
                return new LineaRecortada
                {
                    Aceptada = false,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = p1,
                    P2Recortado = p2,
                    Pasos = pasos
                };
            }
            pasos.Add("");

            pasos.Add("═══ Borde Superior (y = ymin) ═══");
            if (!ClipTest(-dy, y1 - ventana.Top, ref t1, ref t2, pasos))
            {
                pasos.Add("Resultado: LÍNEA RECHAZADA");
                return new LineaRecortada
                {
                    Aceptada = false,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = p1,
                    P2Recortado = p2,
                    Pasos = pasos
                };
            }
            pasos.Add("");

            pasos.Add("═══ Borde Inferior (y = ymax) ═══");
            if (!ClipTest(dy, ventana.Bottom - y1, ref t1, ref t2, pasos))
            {
                pasos.Add("Resultado: LÍNEA RECHAZADA");
                return new LineaRecortada
                {
                    Aceptada = false,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = p1,
                    P2Recortado = p2,
                    Pasos = pasos
                };
            }
            pasos.Add("");

            // La línea es aceptada, calcular puntos recortados
            if (t1 <= t2)
            {
                float xClip1 = x1 + t1 * dx;
                float yClip1 = y1 + t1 * dy;
                float xClip2 = x1 + t2 * dx;
                float yClip2 = y1 + t2 * dy;

                pasos.Add($"═══ Resultado Final ═══");
                pasos.Add($"Parámetros finales: t1 = {t1:F4}, t2 = {t2:F4}");
                pasos.Add($"Punto recortado P1': ({xClip1:F2}, {yClip1:F2})");
                pasos.Add($"Punto recortado P2': ({xClip2:F2}, {yClip2:F2})");
                pasos.Add("Estado: LÍNEA ACEPTADA");

                return new LineaRecortada
                {
                    Aceptada = true,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = new PointF(xClip1, yClip1),
                    P2Recortado = new PointF(xClip2, yClip2),
                    Pasos = pasos
                };
            }
            else
            {
                pasos.Add("t1 > t2 → LÍNEA RECHAZADA");
                return new LineaRecortada
                {
                    Aceptada = false,
                    P1Original = p1,
                    P2Original = p2,
                    P1Recortado = p1,
                    P2Recortado = p2,
                    Pasos = pasos
                };
            }
        }
    }
}
