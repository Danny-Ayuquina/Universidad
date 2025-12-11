using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class CirculoFormulaGeneral
    {
        private PictureBox picGrafico;
        private Graphics g;
        private Pen lapiz;

        private int xc;
        private int yc;
        private int radio;
        private List<PointF> points;

        public CirculoFormulaGeneral(int xc, int yc, int radio, PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.g = picGrafico.CreateGraphics();
            this.lapiz = new Pen(Color.Purple, 3);

            this.xc = xc;
            this.yc = yc;
            this.radio = radio;

            getCirclePoints();
        }

        public void getCirclePoints()
        {
            this.points = new List<PointF>();

            int x, y, p;
            x = 0;
            y = radio;
            p = 1 - radio;

            // Agregar los puntos iniciales
            PlotPoint(xc, yc, x, y);

            // Se cicla hasta trazar todo un octante
            while (x < y)
            {
                x = x + 1;
                if (p < 0)
                {
                    p = p + 2 * x + 3;
                }
                else
                {
                    y = y - 1;
                    p = p + 2 * (x - y) + 5;
                }
                PlotPoint(xc, yc, x, y);
            }
        }

        private void PlotPoint(int xc, int yc, int x, int y)
        {
            // Dibujar los 8 puntos simétricos del círculo
            points.Add(new PointF(xc + x, yc + y));
            points.Add(new PointF(xc - x, yc + y));
            points.Add(new PointF(xc + x, yc - y));
            points.Add(new PointF(xc - x, yc - y));
            points.Add(new PointF(xc + y, yc + x));
            points.Add(new PointF(xc - y, yc + x));
            points.Add(new PointF(xc + y, yc - x));
            points.Add(new PointF(xc - y, yc - x));
        }

        public List<PointF> GetPoints()
        {
            return points;
        }

        public void drawCircle()
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
