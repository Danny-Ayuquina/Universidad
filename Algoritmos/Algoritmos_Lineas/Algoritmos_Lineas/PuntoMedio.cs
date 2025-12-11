using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class PuntoMedio
    {
        private PictureBox picGrafico;
        private Graphics g;
        private Pen lapiz;

        private PointF startPoint;
        private PointF endPoint;
        private List<PointF> points;
        private int dx;
        private int dy;

        public PuntoMedio(PointF startPoint, PointF endPoint, PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.g = picGrafico.CreateGraphics();
            this.lapiz = new Pen(Color.Green, 3);

            this.startPoint = startPoint;
            this.endPoint = endPoint;

            getLinePoints();
        }

        public void getLinePoints()
        {
            this.points = new List<PointF>();

            int x0 = (int)startPoint.X;
            int y0 = (int)startPoint.Y;
            int x1 = (int)endPoint.X;
            int y1 = (int)endPoint.Y;

            dx = Math.Abs(x1 - x0);
            dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int x = x0;
            int y = y0;

            // Algoritmo de Punto Medio
            if (dx > dy)
            {
                // Pendiente suave (|m| < 1)
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);

                points.Add(new PointF(x, y));

                while (x != x1)
                {
                    if (d <= 0)
                    {
                        d += incrE;
                        x += sx;
                    }
                    else
                    {
                        d += incrNE;
                        x += sx;
                        y += sy;
                    }
                    points.Add(new PointF(x, y));
                }
            }
            else
            {
                // Pendiente pronunciada (|m| >= 1)
                int d = 2 * dx - dy;
                int incrE = 2 * dx;
                int incrNE = 2 * (dx - dy);

                points.Add(new PointF(x, y));

                while (y != y1)
                {
                    if (d <= 0)
                    {
                        d += incrE;
                        y += sy;
                    }
                    else
                    {
                        d += incrNE;
                        x += sx;
                        y += sy;
                    }
                    points.Add(new PointF(x, y));
                }
            }
        }

        public List<PointF> GetPoints()
        {
            return points;
        }

        public void drawLine()
        {
            if (points == null || g == null || lapiz == null) return;

            foreach (PointF p in points)
            {
                g.DrawRectangle(lapiz, p.X, p.Y, 1, 1);
            }
        }

        public void drawPointAtIndex(int index)
        {
            if (points == null || g == null || lapiz == null || index < 0 || index >= points.Count) return;

            PointF p = points[index];
            g.DrawRectangle(lapiz, p.X, p.Y, 1, 1);
        }
    }
}
