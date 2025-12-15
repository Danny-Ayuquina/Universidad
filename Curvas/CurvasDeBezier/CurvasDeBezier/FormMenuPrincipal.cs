using System;
using System.Windows.Forms;

namespace CurvasDeBezier
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            // Configurar como MDI Container
            this.IsMdiContainer = true;
        }

        private void menuItemBezier_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Abriendo módulo de Curvas de Bézier...";
            
            // Crear nuevo formulario hijo
            FormBezier formBezier = new FormBezier();
            formBezier.MdiParent = this;
            formBezier.Show();
            
            toolStripStatusLabel.Text = "Módulo de Curvas de Bézier abierto.";
        }

        private void menuItemBSpline_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Abriendo módulo de Curvas B-Spline...";
            
            // Crear nuevo formulario hijo
            FormBSpline formBSpline = new FormBSpline();
            formBSpline.MdiParent = this;
            formBSpline.Show();
            
            toolStripStatusLabel.Text = "Módulo de Curvas B-Spline abierto.";
        }

        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuItemAcercaDe_Click(object sender, EventArgs e)
        {
            string mensaje = "Sistema de Curvas Paramétricas\n" +
                           "Versión 1.0\n\n" +
                           "Implementación de algoritmos de curvas de Bézier y B-Spline\n" +
                           "con interfaz interactiva para visualización y manipulación.\n\n" +
                           "Características:\n" +
                           "• Curvas de Bézier generalizadas para N puntos\n" +
                           "• Curvas B-Spline de grados 1-3 con N puntos\n" +
                           "• Algoritmo de De Casteljau (Bézier)\n" +
                           "• Algoritmo de Cox-de Boor (B-Spline)\n" +
                           "• Animación de trazado de curvas\n" +
                           "• Manipulación interactiva de puntos de control\n" +
                           "• Interfaz MDI para múltiples ventanas\n\n" +
                           "Proyecto educativo - Computación Gráfica\n" +
                           "Universidad - 5to Semestre";

            MessageBox.Show(mensaje, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
