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
    public partial class FrmCirculoBresenham : Form
    {
        private CirculoBresenham circulo;
        private int currentIndex = 0;
        private Bitmap bitmap;
        private Graphics g;

        public FrmCirculoBresenham()
        {
            InitializeComponent();
            InitializeBitmap();
            // Agregar evento de clic al PictureBox
            picGrafico.MouseClick += picGrafico_MouseClick;
        }

        private void InitializeBitmap()
        {
            bitmap = new Bitmap(picGrafico.Width, picGrafico.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            picGrafico.Image = bitmap;
        }

        private void picGrafico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Actualizar los campos de texto con las coordenadas del clic
                txtCentroX.Text = e.X.ToString();
                txtCentroY.Text = e.Y.ToString();

                // Limpiar y dibujar una marca en el centro seleccionado
                g.Clear(Color.White);

                // Dibujar cruz en el centro seleccionado
                Pen penCentro = new Pen(Color.Red, 2);
                g.DrawLine(penCentro, e.X - 5, e.Y, e.X + 5, e.Y);
                g.DrawLine(penCentro, e.X, e.Y - 5, e.X, e.Y + 5);
                g.FillEllipse(Brushes.Red, e.X - 3, e.Y - 3, 6, 6);
                
                picGrafico.Invalidate();
            }
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            try
            {
                int centroX = int.Parse(txtCentroX.Text);
                int centroY = int.Parse(txtCentroY.Text);
                int radio = int.Parse(txtRadio.Text);

                if (radio <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor que 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Limpiar el bitmap
                g.Clear(Color.White);

                circulo = new CirculoBresenham(centroX, centroY, radio, picGrafico);
                circulo.drawCircle();

                // Llenar el ListBox con los puntos y pasos
                lstPuntos.Items.Clear();
                List<Tuple<PointF, string>> pointsWithSteps = circulo.GetPointsWithSteps();
                foreach (var item in pointsWithSteps)
                {
                    lstPuntos.Items.Add($"({item.Item1.X:F0}, {item.Item1.Y:F0}) - {item.Item2}");
                }

                currentIndex = 0;
                lblInfo.Text = $"Total de puntos: {pointsWithSteps.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            picGrafico.Invalidate();
            lstPuntos.Items.Clear();
            currentIndex = 0;
            circulo = null;
            lblInfo.Text = "Ingrese los parámetros y presione Dibujar";
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (circulo == null)
            {
                MessageBox.Show("Por favor, primero calcule los puntos presionando 'Dibujar'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<PointF> points = circulo.GetPoints();
            if (currentIndex < points.Count)
            {
                if (currentIndex == 0)
                {
                    g.Clear(Color.White);
                }

                circulo.drawPointAtIndex(currentIndex);
                lstPuntos.SelectedIndex = currentIndex;
                currentIndex++;
                lblInfo.Text = $"Punto {currentIndex} de {points.Count}";
            }
            else
            {
                MessageBox.Show("Ya se han dibujado todos los puntos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (circulo == null)
            {
                MessageBox.Show("Por favor, primero calcule los puntos presionando 'Dibujar'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentIndex > 0)
            {
                currentIndex--;
                g.Clear(Color.White);

                // Redibujar todos los puntos hasta el índice actual
                for (int i = 0; i < currentIndex; i++)
                {
                    circulo.drawPointAtIndex(i);
                }

                if (currentIndex > 0)
                {
                    lstPuntos.SelectedIndex = currentIndex - 1;
                    lblInfo.Text = $"Punto {currentIndex} de {circulo.GetPoints().Count}";
                }
                else
                {
                    lstPuntos.ClearSelected();
                    lblInfo.Text = $"Total de puntos: {circulo.GetPoints().Count}";
                }
            }
            else
            {
                MessageBox.Show("Ya está en el primer punto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
