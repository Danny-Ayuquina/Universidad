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
    public partial class FrmPuntoMedio : Form
    {
        private PuntoMedio puntoMedio;
        private int currentIndex = 0;

        public FrmPuntoMedio()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            float pInicialX = float.Parse(txtPInicialX.Text);
            float pInicialY = float.Parse(txtPInicialY.Text);
            float pFinalX = float.Parse(txtPFinalX.Text);
            float pFinalY = float.Parse(txtPFinalY.Text);

            puntoMedio = new PuntoMedio(new PointF(pInicialX, pInicialY), new PointF(pFinalX, pFinalY), picGrafico);

            puntoMedio.drawLine();

            // Llenar el ListBox con los puntos
            lstPuntos.Items.Clear();
            List<PointF> points = puntoMedio.GetPoints();
            foreach (PointF p in points)
            {
                lstPuntos.Items.Add($"({p.X:F2}, {p.Y:F2})");
            }

            currentIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            picGrafico.Refresh();
            lstPuntos.Items.Clear();
            currentIndex = 0;
            puntoMedio = null;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (puntoMedio == null)
            {
                MessageBox.Show("Por favor, primero calcule los puntos presionando 'Dibujar'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<PointF> points = puntoMedio.GetPoints();
            if (currentIndex < points.Count)
            {
                if (currentIndex == 0)
                {
                    picGrafico.Refresh();
                }

                puntoMedio.drawPointAtIndex(currentIndex);
                lstPuntos.SelectedIndex = currentIndex;
                currentIndex++;
            }
            else
            {
                MessageBox.Show("Ya se han dibujado todos los puntos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (puntoMedio == null)
            {
                MessageBox.Show("Por favor, primero calcule los puntos presionando 'Dibujar'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentIndex > 0)
            {
                currentIndex--;
                picGrafico.Refresh();

                // Redibujar todos los puntos hasta el índice actual
                for (int i = 0; i < currentIndex; i++)
                {
                    puntoMedio.drawPointAtIndex(i);
                }

                if (currentIndex > 0)
                {
                    lstPuntos.SelectedIndex = currentIndex - 1;
                }
                else
                {
                    lstPuntos.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("Ya está en el primer punto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
