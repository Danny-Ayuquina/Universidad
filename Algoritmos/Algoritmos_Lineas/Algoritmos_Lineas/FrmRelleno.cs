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
    public partial class FrmRelleno : Form
    {
        private RellenoFiguras relleno;
        private List<Point> vertices;
        private Point puntoInicio;
        private bool dibujando;

        public FrmRelleno()
        {
            InitializeComponent();
            vertices = new List<Point>();
            dibujando = false;
        }

        private void FrmRelleno_Load(object sender, EventArgs e)
        {
            relleno = new RellenoFiguras(picGrafico);
        }

        private void picGrafico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                vertices.Add(e.Location);
                lstVertices.Items.Add($"V{vertices.Count}: ({e.Location.X}, {e.Location.Y})");

                if (vertices.Count > 1)
                {
                    relleno.DibujarLinea(vertices[vertices.Count - 2], vertices[vertices.Count - 1], Color.Black);
                }
            }
        }

        private void btnCerrarFigura_Click(object sender, EventArgs e)
        {
            if (vertices.Count > 2)
            {
                relleno.DibujarLinea(vertices[vertices.Count - 1], vertices[0], Color.Black);
                MessageBox.Show("Figura cerrada. Ahora puede hacer clic dentro de la figura para rellenarla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Necesita al menos 3 vértices para cerrar la figura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haga clic dentro de la figura para aplicar FloodFill.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            picGrafico.Cursor = Cursors.Cross;
            picGrafico.MouseClick -= picGrafico_MouseClick;
            picGrafico.MouseClick += picGrafico_MouseClick_FloodFill;
        }

        private void picGrafico_MouseClick_FloodFill(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                relleno.FloodFill(e.Location, Color.Red, Color.Black);
                MostrarPixelesPintados();
                picGrafico.Cursor = Cursors.Default;
                picGrafico.MouseClick -= picGrafico_MouseClick_FloodFill;
                picGrafico.MouseClick += picGrafico_MouseClick;
            }
        }

        private void btnBoundaryFill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haga clic dentro de la figura para aplicar Boundary Fill.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            picGrafico.Cursor = Cursors.Cross;
            picGrafico.MouseClick -= picGrafico_MouseClick;
            picGrafico.MouseClick += picGrafico_MouseClick_BoundaryFill;
        }

        private void picGrafico_MouseClick_BoundaryFill(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                relleno.BoundaryFill(e.Location, Color.Blue, Color.Black);
                MostrarPixelesPintados();
                picGrafico.Cursor = Cursors.Default;
                picGrafico.MouseClick -= picGrafico_MouseClick_BoundaryFill;
                picGrafico.MouseClick += picGrafico_MouseClick;
            }
        }

        private void btnScanlineFill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haga clic dentro de la figura para aplicar Scanline Fill.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            picGrafico.Cursor = Cursors.Cross;
            picGrafico.MouseClick -= picGrafico_MouseClick;
            picGrafico.MouseClick += picGrafico_MouseClick_ScanlineFill;
        }

        private void picGrafico_MouseClick_ScanlineFill(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                relleno.ScanlineFill(e.Location, Color.Green, Color.Black);
                MostrarPixelesPintados();
                picGrafico.Cursor = Cursors.Default;
                picGrafico.MouseClick -= picGrafico_MouseClick_ScanlineFill;
                picGrafico.MouseClick += picGrafico_MouseClick;
            }
        }

        private void MostrarPixelesPintados()
        {
            lstPixeles.Items.Clear();
            List<Point> pixeles = relleno.GetPixelesPintados();
            lstPixeles.Items.Add($"Total de píxeles pintados: {pixeles.Count}");
            lstPixeles.Items.Add("------------------------");

            // Mostrar solo los primeros 1000 píxeles para no saturar la lista
            int maxMostrar = Math.Min(pixeles.Count, 1000);
            for (int i = 0; i < maxMostrar; i++)
            {
                lstPixeles.Items.Add($"({pixeles[i].X}, {pixeles[i].Y})");
            }

            if (pixeles.Count > 1000)
            {
                lstPixeles.Items.Add($"... y {pixeles.Count - 1000} píxeles más");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            relleno.Limpiar();
            vertices.Clear();
            lstVertices.Items.Clear();
            lstPixeles.Items.Clear();
            picGrafico.Cursor = Cursors.Default;
            picGrafico.MouseClick -= picGrafico_MouseClick_FloodFill;
            picGrafico.MouseClick -= picGrafico_MouseClick_BoundaryFill;
            picGrafico.MouseClick -= picGrafico_MouseClick_ScanlineFill;
            picGrafico.MouseClick += picGrafico_MouseClick;
        }
    }
}
