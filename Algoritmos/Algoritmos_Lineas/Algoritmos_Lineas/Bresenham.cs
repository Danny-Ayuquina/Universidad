using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class Bresenham
    {
        private PictureBox picGrafico;
        private Graphics g;
        private Pen lapiz;

        private PointF startPoint;
        private PointF endPoint;
        private List<PointF> points;
        private int dx;
        private int dy;
        private int p;

        public Bresenham(PointF startPoint, PointF endPoint, PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.g = picGrafico.CreateGraphics();
            this.lapiz = new Pen(Color.Red, 3);

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

            int err = dx - dy;
            int x = x0;
            int y = y0;

            while (true)
            {
                points.Add(new PointF(x, y));

                if (x == x1 && y == y1)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
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
