using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_Lineas
{
    internal class CohenSutherland
    {
        // Códigos de región
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        private RectangleF ventana;

        public CohenSutherland(RectangleF ventana)
        {
            this.ventana = ventana;
        }

        // Calcula el código de región para un punto (x, y)
        private int CalcularCodigo(float x, float y)
        {
            int codigo = INSIDE;

            if (x < ventana.Left)       // a la izquierda de la ventana
                codigo |= LEFT;
            else if (x > ventana.Right) // a la derecha de la ventana
                codigo |= RIGHT;

            if (y < ventana.Top)        // arriba de la ventana
                codigo |= TOP;
            else if (y > ventana.Bottom) // abajo de la ventana
                codigo |= BOTTOM;

            return codigo;
        }

        // Algoritmo de recorte de Cohen-Sutherland
        public LineaRecortada RecortarLinea(PointF p1, PointF p2)
        {
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;

            // Calcular códigos de región para P1 y P2
            int codigo1 = CalcularCodigo(x1, y1);
            int codigo2 = CalcularCodigo(x2, y2);

            bool aceptada = false;
            List<string> pasos = new List<string>();

            pasos.Add($"Punto inicial P1: ({x1:F2}, {y1:F2}) - Código: {Convert.ToString(codigo1, 2).PadLeft(4, '0')}");
            pasos.Add($"Punto final P2: ({x2:F2}, {y2:F2}) - Código: {Convert.ToString(codigo2, 2).PadLeft(4, '0')}");

            while (true)
            {
                if ((codigo1 | codigo2) == 0)
                {
                    // Ambos puntos dentro - aceptar línea
                    aceptada = true;
                    pasos.Add("Ambos puntos están dentro de la ventana - LÍNEA ACEPTADA");
                    break;
                }
                else if ((codigo1 & codigo2) != 0)
                {
                    // Ambos puntos en la misma región exterior - rechazar línea
                    pasos.Add("Ambos puntos están en la misma región exterior - LÍNEA RECHAZADA");
                    break;
                }
                else
                {
                    // Línea cruza la ventana - calcular intersección
                    float x = 0, y = 0;

                    // Seleccionar punto que está fuera
                    int codigoFuera = (codigo1 != 0) ? codigo1 : codigo2;

                    pasos.Add($"Procesando punto con código: {Convert.ToString(codigoFuera, 2).PadLeft(4, '0')}");

                    // Encontrar punto de intersección
                    if ((codigoFuera & TOP) != 0)
                    {
                        // Punto está arriba de la ventana
                        x = x1 + (x2 - x1) * (ventana.Top - y1) / (y2 - y1);
                        y = ventana.Top;
                        pasos.Add($"Intersección con borde superior: ({x:F2}, {y:F2})");
                    }
                    else if ((codigoFuera & BOTTOM) != 0)
                    {
                        // Punto está abajo de la ventana
                        x = x1 + (x2 - x1) * (ventana.Bottom - y1) / (y2 - y1);
                        y = ventana.Bottom;
                        pasos.Add($"Intersección con borde inferior: ({x:F2}, {y:F2})");
                    }
                    else if ((codigoFuera & RIGHT) != 0)
                    {
                        // Punto está a la derecha de la ventana
                        y = y1 + (y2 - y1) * (ventana.Right - x1) / (x2 - x1);
                        x = ventana.Right;
                        pasos.Add($"Intersección con borde derecho: ({x:F2}, {y:F2})");
                    }
                    else if ((codigoFuera & LEFT) != 0)
                    {
                        // Punto está a la izquierda de la ventana
                        y = y1 + (y2 - y1) * (ventana.Left - x1) / (x2 - x1);
                        x = ventana.Left;
                        pasos.Add($"Intersección con borde izquierdo: ({x:F2}, {y:F2})");
                    }

                    // Reemplazar punto exterior con intersección
                    if (codigoFuera == codigo1)
                    {
                        x1 = x;
                        y1 = y;
                        codigo1 = CalcularCodigo(x1, y1);
                        pasos.Add($"Nuevo P1: ({x1:F2}, {y1:F2}) - Código: {Convert.ToString(codigo1, 2).PadLeft(4, '0')}");
                    }
                    else
                    {
                        x2 = x;
                        y2 = y;
                        codigo2 = CalcularCodigo(x2, y2);
                        pasos.Add($"Nuevo P2: ({x2:F2}, {y2:F2}) - Código: {Convert.ToString(codigo2, 2).PadLeft(4, '0')}");
                    }
                }
            }

            return new LineaRecortada
            {
                Aceptada = aceptada,
                P1Original = p1,
                P2Original = p2,
                P1Recortado = new PointF(x1, y1),
                P2Recortado = new PointF(x2, y2),
                Pasos = pasos
            };
        }
    }

    // Clase para almacenar el resultado del recorte
    internal class LineaRecortada
    {
        public bool Aceptada { get; set; }
        public PointF P1Original { get; set; }
        public PointF P2Original { get; set; }
        public PointF P1Recortado { get; set; }
        public PointF P2Recortado { get; set; }
        public List<string> Pasos { get; set; }
    }
}
