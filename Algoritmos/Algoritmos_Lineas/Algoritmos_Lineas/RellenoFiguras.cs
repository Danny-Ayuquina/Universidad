using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class RellenoFiguras
    {
        private PictureBox picGrafico;
        private Bitmap bitmap;
        private Graphics g;
        private List<Point> pixelesPintados;

        public RellenoFiguras(PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.bitmap = new Bitmap(picGrafico.Width, picGrafico.Height);
            this.g = Graphics.FromImage(bitmap);
            this.g.Clear(Color.White);
            this.picGrafico.Image = bitmap;
            this.pixelesPintados = new List<Point>();
        }

        public void DibujarLinea(Point p1, Point p2, Color color)
        {
            using (Pen pen = new Pen(color, 2))
            {
                g.DrawLine(pen, p1, p2);
            }
            picGrafico.Invalidate();
        }

        public List<Point> GetPixelesPintados()
        {
            return new List<Point>(pixelesPintados);
        }

        public void LimpiarPixelesPintados()
        {
            pixelesPintados.Clear();
        }

        // Algoritmo FloodFill (Iterativo con pila para evitar StackOverflow)
        public void FloodFill(Point punto, Color colorRelleno, Color colorBorde)
        {
            pixelesPintados.Clear();

            if (punto.X < 0 || punto.X >= bitmap.Width || punto.Y < 0 || punto.Y >= bitmap.Height)
                return;

            Color colorOriginal = bitmap.GetPixel(punto.X, punto.Y);

            if (colorOriginal == colorBorde || colorOriginal == colorRelleno)
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(punto);

            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                int x = p.X;
                int y = p.Y;

                if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);

                if (colorActual == colorOriginal && colorActual != colorBorde && colorActual != colorRelleno)
                {
                    bitmap.SetPixel(x, y, colorRelleno);
                    pixelesPintados.Add(new Point(x, y));

                    pila.Push(new Point(x + 1, y));
                    pila.Push(new Point(x - 1, y));
                    pila.Push(new Point(x, y + 1));
                    pila.Push(new Point(x, y - 1));
                }
            }

            picGrafico.Invalidate();
        }

        // Algoritmo Boundary Fill (Iterativo con pila)
        public void BoundaryFill(Point punto, Color colorRelleno, Color colorBorde)
        {
            pixelesPintados.Clear();

            if (punto.X < 0 || punto.X >= bitmap.Width || punto.Y < 0 || punto.Y >= bitmap.Height)
                return;

            Color colorInicial = bitmap.GetPixel(punto.X, punto.Y);

            if (colorInicial == colorBorde || colorInicial == colorRelleno)
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(punto);

            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                int x = p.X;
                int y = p.Y;

                if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);

                if (colorActual != colorBorde && colorActual != colorRelleno)
                {
                    bitmap.SetPixel(x, y, colorRelleno);
                    pixelesPintados.Add(new Point(x, y));

                    pila.Push(new Point(x + 1, y));
                    pila.Push(new Point(x - 1, y));
                    pila.Push(new Point(x, y + 1));
                    pila.Push(new Point(x, y - 1));
                }
            }

            picGrafico.Invalidate();
        }

        // Algoritmo Scanline Fill (Optimizado)
        public void ScanlineFill(Point punto, Color colorRelleno, Color colorBorde)
        {
            pixelesPintados.Clear();

            if (punto.X < 0 || punto.X >= bitmap.Width || punto.Y < 0 || punto.Y >= bitmap.Height)
                return;

            Color colorOriginal = bitmap.GetPixel(punto.X, punto.Y);

            if (colorOriginal == colorBorde || colorOriginal == colorRelleno)
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(punto);

            bool[,] visitado = new bool[bitmap.Width, bitmap.Height];

            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                int y = p.Y;
                int x = p.X;

                if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                    continue;

                if (visitado[x, y])
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);
                if (colorActual != colorOriginal || colorActual == colorBorde)
                    continue;

                // Buscar el inicio de la línea (expandir a la izquierda)
                int x1 = x;
                while (x1 > 0)
                {
                    Color c = bitmap.GetPixel(x1 - 1, y);
                    if (c != colorOriginal || c == colorBorde)
                        break;
                    x1--;
                }

                // Buscar el final de la línea (expandir a la derecha)
                int x2 = x;
                while (x2 < bitmap.Width - 1)
                {
                    Color c = bitmap.GetPixel(x2 + 1, y);
                    if (c != colorOriginal || c == colorBorde)
                        break;
                    x2++;
                }

                // Pintar la línea completa
                for (int i = x1; i <= x2; i++)
                {
                    bitmap.SetPixel(i, y, colorRelleno);
                    pixelesPintados.Add(new Point(i, y));
                    visitado[i, y] = true;
                }

                // Buscar píxeles en las líneas superior e inferior que necesiten ser procesados
                bool enRango = false;
                
                // Línea superior
                if (y > 0)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        Color c = bitmap.GetPixel(i, y - 1);
                        bool esRellenable = (c == colorOriginal && c != colorBorde && !visitado[i, y - 1]);

                        if (!enRango && esRellenable)
                        {
                            pila.Push(new Point(i, y - 1));
                            enRango = true;
                        }
                        else if (enRango && !esRellenable)
                        {
                            enRango = false;
                        }
                    }
                }

                // Línea inferior
                enRango = false;
                if (y < bitmap.Height - 1)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        Color c = bitmap.GetPixel(i, y + 1);
                        bool esRellenable = (c == colorOriginal && c != colorBorde && !visitado[i, y + 1]);

                        if (!enRango && esRellenable)
                        {
                            pila.Push(new Point(i, y + 1));
                            enRango = true;
                        }
                        else if (enRango && !esRellenable)
                        {
                            enRango = false;
                        }
                    }
                }
            }

            picGrafico.Invalidate();
        }

        public void Limpiar()
        {
            g.Clear(Color.White);
            pixelesPintados.Clear();
            picGrafico.Invalidate();
        }
    }
}
