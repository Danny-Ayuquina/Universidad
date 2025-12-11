using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class DDA
    {
        private PictureBox picGrafico;
        private Graphics g;
        private Pen lapiz;

        private PointF startPoint;
        private PointF endPoint;
        private List<PointF> points;
        private float dx;
        private float dy;
        private float m;
        private int k;

        public DDA(PointF startPoint, PointF endPoint, PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.g = picGrafico.CreateGraphics();
            this.lapiz = new Pen(Color.Blue, 3);

            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.dx = endPoint.X - startPoint.X;
            this.dy = endPoint.Y - startPoint.Y;

            int steps = (int)Math.Max(Math.Abs(dx), Math.Abs(dy));
            if (steps <= 0) steps = 1;
            this.k = steps;

            this.m = (Math.Abs(dx) > float.Epsilon) ? dy / dx : float.PositiveInfinity;

            getLinePoints();
        }

        public void getLinePoints()
        {
            this.points = new List<PointF>();

            float x = startPoint.X;
            float y = startPoint.Y;
            points.Add(new PointF(x, y));

            float stepX = dx / k;
            float stepY = dy / k;

            for (int i = 0; i < k; i++)
            {
                x += stepX;
                y += stepY;
                points.Add(new PointF(x, y));
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
