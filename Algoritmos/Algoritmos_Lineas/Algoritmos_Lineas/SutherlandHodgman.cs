using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_Lineas
{
    internal class SutherlandHodgman
    {
        // Método principal del algoritmo Sutherland-Hodgman
        public static List<PointF> RecortarPoligono(List<PointF> poligono, List<PointF> ventana)
        {
            List<PointF> entrada = new List<PointF>(poligono);
            List<PointF> salida = new List<PointF>();

            // Para cada arco (lado) de la ventana de recorte
            for (int i = 0; i < ventana.Count; i++)
            {
                salida.Clear();
                PointF p1 = ventana[i];
                PointF p2 = ventana[(i + 1) % ventana.Count];

                // Para cada arco formado por (p_i, p_j) en entrada
                for (int j = 0; j < entrada.Count; j++)
                {
                    PointF pi = entrada[j];
                    PointF pj = entrada[(j + 1) % entrada.Count];

                    bool piDentro = EstaAdentro(pi, p1, p2);
                    bool pjDentro = EstaAdentro(pj, p1, p2);

                    // Caso 1: si p_i y p_j están fuera del borde
                    if (!piDentro && !pjDentro)
                    {
                        // Continuar al siguiente arco
                        continue;
                    }
                    // Caso 2: si p_i y p_j están dentro del borde
                    else if (piDentro && pjDentro)
                    {
                        salida.Add(pj);
                    }
                    // Caso 3: si p_i está dentro y p_j está fuera
                    else if (piDentro && !pjDentro)
                    {
                        PointF pk = CalcularInterseccion(pi, pj, p1, p2);
                        salida.Add(pk);
                    }
                    // Caso 4: si p_i está fuera y p_j está dentro
                    else if (!piDentro && pjDentro)
                    {
                        PointF pk = CalcularInterseccion(pi, pj, p1, p2);
                        salida.Add(pk);
                        salida.Add(pj);
                    }
                }

                entrada = new List<PointF>(salida);

                if (entrada.Count == 0)
                    break;
            }

            return salida;
        }

        // Determina si un punto está dentro (lado izquierdo) de una línea
        private static bool EstaAdentro(PointF punto, PointF p1, PointF p2)
        {
            // Producto cruz para determinar el lado
            return (p2.X - p1.X) * (punto.Y - p1.Y) - (p2.Y - p1.Y) * (punto.X - p1.X) >= 0;
        }

        // Calcula el punto de intersección entre dos líneas
        private static PointF CalcularInterseccion(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;
            float x3 = p3.X, y3 = p3.Y;
            float x4 = p4.X, y4 = p4.Y;

            float denominador = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (Math.Abs(denominador) < 0.0001f)
            {
                // Las líneas son paralelas
                return p1;
            }

            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / denominador;

            float x = x1 + t * (x2 - x1);
            float y = y1 + t * (y2 - y1);

            return new PointF(x, y);
        }
    }
}
