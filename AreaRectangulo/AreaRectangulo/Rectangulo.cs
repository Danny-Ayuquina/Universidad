using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaRectangulo
{
    public partial class Rectangulo : Form
    {
        public Rectangulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblAncho_Click(object sender, EventArgs e)
        {

        }

        private float calcularPerimetro(float ancho, float alto)
        {
            float perimetro = (ancho * 2) + (alto * 2);
            return perimetro;
        }

        private float calcularArea(float ancho, float alto)
        {
            float area = ancho*alto;
            return area;
        }

        private void calcularParametrosRectangulo()
        {
            float ancho = float.Parse(txtAncho.Text);
            float alto = float.Parse(txtAlto.Text);

            if (ancho <= 0 || alto <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(ancho, alto);
                float area = calcularArea(ancho, alto);
                MessageBox.Show("El área del Rectángulo es = " + area + "\n" + "El perímetro del Rectángulo es = " + perimetro);
            }
                
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosRectangulo();
        }
        private void txtAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y la tecla de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void txtAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y la tecla de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
