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
    public partial class Cuadrado : Form
    {
        public Cuadrado()
        {
            InitializeComponent();
        }

        private float calcularPerimetro(float lado)
        {
            float perimetro = lado* 4;
            return perimetro;
        }

        private float calcularArea(float lado)
        {
            float area = lado*lado;
            return area;
        }

        private void calcularParametrosCuadrado()
        {
            float lado = float.Parse(txtLado.Text);

            if (lado <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(lado);
                float area = calcularArea(lado);
                MessageBox.Show("El área del Rectángulo es = " + area + "\n" + "El perímetro del Rectángulo es = " + perimetro);
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosCuadrado();
        }
    }
}
