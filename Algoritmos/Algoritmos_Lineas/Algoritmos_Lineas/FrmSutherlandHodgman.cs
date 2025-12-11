using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    public partial class FrmSutherlandHodgman : Form
    {
        private List<PointF> poligonoOriginal;
        private List<PointF> ventanaRecorte;
        private List<PointF> poligonoRecortado;
        private Bitmap bitmap;
        private Graphics g;
        private bool dibujandoPoligono;
        private bool dibujandoVentana;

        public FrmSutherlandHodgman()
        {
            InitializeComponent();
            poligonoOriginal = new List<PointF>();
            ventanaRecorte = new List<PointF>();
            poligonoRecortado = new List<PointF>();
            dibujandoPoligono = false;
            dibujandoVentana = false;
        }

        private void FrmSutherlandHodgman_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(picGrafico.Width, picGrafico.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            picGrafico.Image = bitmap;
        }

        private void btnDibujarPoligono_Click(object sender, EventArgs e)
        {
            dibujandoPoligono = true;
            dibujandoVentana = false;
            MessageBox.Show("Haga clic en el área de dibujo para crear los vértices del polígono.\nClic derecho para finalizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDibujarVentana_Click(object sender, EventArgs e)
        {
            dibujandoPoligono = false;
            dibujandoVentana = true;
            MessageBox.Show("Haga clic en el área de dibujo para crear los vértices de la ventana de recorte.\nClic derecho para finalizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picGrafico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dibujandoPoligono)
                {
                    poligonoOriginal.Add(e.Location);
                    lstPoligono.Items.Add($"V{poligonoOriginal.Count}: ({e.Location.X}, {e.Location.Y})");
                    DibujarTodo();
                }
                else if (dibujandoVentana)
                {
                    ventanaRecorte.Add(e.Location);
                    lstVentana.Items.Add($"V{ventanaRecorte.Count}: ({e.Location.X}, {e.Location.Y})");
                    DibujarTodo();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (dibujandoPoligono)
                {
                    dibujandoPoligono = false;
                    DibujarTodo();
                }
                else if (dibujandoVentana)
                {
                    dibujandoVentana = false;
                    DibujarTodo();
                }
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (poligonoOriginal.Count < 3)
            {
                MessageBox.Show("El polígono debe tener al menos 3 vértices.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ventanaRecorte.Count < 3)
            {
                MessageBox.Show("La ventana de recorte debe tener al menos 3 vértices.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            poligonoRecortado = SutherlandHodgman.RecortarPoligono(poligonoOriginal, ventanaRecorte);

            lstRecortado.Items.Clear();
            lstRecortado.Items.Add($"Vértices del polígono recortado: {poligonoRecortado.Count}");
            lstRecortado.Items.Add("------------------------");
            for (int i = 0; i < poligonoRecortado.Count; i++)
            {
                lstRecortado.Items.Add($"V{i + 1}: ({poligonoRecortado[i].X:F2}, {poligonoRecortado[i].Y:F2})");
            }

            DibujarTodo();
        }

        private void DibujarTodo()
        {
            g.Clear(Color.White);

            // Dibujar polígono original en azul
            if (poligonoOriginal.Count > 0)
            {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    if (poligonoOriginal.Count > 1)
                    {
                        g.DrawPolygon(pen, poligonoOriginal.ToArray());
                    }
                    // Dibujar vértices
                    foreach (PointF p in poligonoOriginal)
                    {
                        g.FillEllipse(Brushes.Blue, p.X - 3, p.Y - 3, 6, 6);
                    }
                }
            }

            // Dibujar ventana de recorte en negro
            if (ventanaRecorte.Count > 0)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    if (ventanaRecorte.Count > 1)
                    {
                        g.DrawPolygon(pen, ventanaRecorte.ToArray());
                    }
                    // Dibujar vértices
                    foreach (PointF p in ventanaRecorte)
                    {
                        g.FillRectangle(Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
                    }
                }
            }

            // Dibujar polígono recortado en rojo (relleno)
            if (poligonoRecortado.Count > 2)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(100, Color.Red)))
                {
                    g.FillPolygon(brush, poligonoRecortado.ToArray());
                }
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    g.DrawPolygon(pen, poligonoRecortado.ToArray());
                }
            }

            picGrafico.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            poligonoOriginal.Clear();
            ventanaRecorte.Clear();
            poligonoRecortado.Clear();
            lstPoligono.Items.Clear();
            lstVentana.Items.Clear();
            lstRecortado.Items.Clear();
            dibujandoPoligono = false;
            dibujandoVentana = false;
            g.Clear(Color.White);
            picGrafico.Invalidate();
        }
    }
}
