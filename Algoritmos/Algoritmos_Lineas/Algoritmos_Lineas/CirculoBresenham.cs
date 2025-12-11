using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    internal class CirculoBresenham
    {
        private PictureBox picGrafico;
        private Graphics g;
        private Pen lapiz;

        private int xc;
        private int yc;
        private int radio;
        private List<Tuple<PointF, string>> pointsWithSteps;

        public CirculoBresenham(int xc, int yc, int radio, PictureBox picGrafico)
        {
            if (picGrafico == null) throw new ArgumentNullException(nameof(picGrafico));

            this.picGrafico = picGrafico;
            this.g = picGrafico.CreateGraphics();
            this.lapiz = new Pen(Color.DarkOrange, 3);

            this.xc = xc;
            this.yc = yc;
            this.radio = radio;

            getCirclePoints();
        }

        public void getCirclePoints()
        {
            this.pointsWithSteps = new List<Tuple<PointF, string>>();

            int x = 0;
            int y = radio;
            int d = 3 - 2 * radio;

            // Agregar los puntos iniciales con información del paso
            PlotPoint(xc, yc, x, y, $"Inicial: x=0, y={radio}, d={d}");

            while (x <= y)
            {
                x++;

                string paso;
                if (d < 0)
                {
                    paso = $"d < 0: d = {d} + 4*{x} + 6 = {d + 4 * x + 6}";
                    d = d + 4 * x + 6;
                }
                else
                {
                    paso = $"d ≥ 0: d = {d} + 4*({x}-{y}) + 10 = {d + 4 * (x - y) + 10}";
                    d = d + 4 * (x - y) + 10;
                    y--;
                }

                PlotPoint(xc, yc, x, y, paso);
            }
        }

        private void PlotPoint(int xc, int yc, int x, int y, string paso)
        {
            // Dibujar los 8 puntos simétricos del círculo con el mismo paso
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc + x, yc + y), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc - x, yc + y), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc + x, yc - y), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc - x, yc - y), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc + y, yc + x), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc - y, yc + x), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc + y, yc - x), paso));
            pointsWithSteps.Add(new Tuple<PointF, string>(new PointF(xc - y, yc - x), paso));
        }

        public List<PointF> GetPoints()
        {
            return pointsWithSteps.Select(t => t.Item1).ToList();
        }

        public List<Tuple<PointF, string>> GetPointsWithSteps()
        {
            return pointsWithSteps;
        }

        public void drawCircle()
        {
            if (pointsWithSteps == null || g == null || lapiz == null) return;

            foreach (var item in pointsWithSteps)
            {
                PointF p = item.Item1;
                g.DrawRectangle(lapiz, p.X, p.Y, 1, 1);
            }
        }

        public void drawPointAtIndex(int index)
        {
            if (pointsWithSteps == null || g == null || lapiz == null || index < 0 || index >= pointsWithSteps.Count) return;

            PointF p = pointsWithSteps[index].Item1;
            g.DrawRectangle(lapiz, p.X, p.Y, 1, 1);
        }
    }
}
