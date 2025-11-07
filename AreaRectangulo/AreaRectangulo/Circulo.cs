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
    public partial class Circulo : Form
    {
        public Circulo()
        {
            InitializeComponent();
        }

        private float calcularPerimetro(float radio, float pi)
        {
            float perimetro = (radio * 2) * pi;
            return perimetro;
        }

        private float calcularArea(float radio, float pi)
        {
            float area = pi*radio;
            return area;
        }

        private void calcularParametrosCirculo()
        {
            float radio = float.Parse(txtRadio.Text);
            float pi = (float)Math.PI;

            if (radio <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(radio, pi);
                float area = calcularArea(radio, pi);
                MessageBox.Show("El área del Círculo es = " + area + "\n" + "El perímetro del Círculo es = " + perimetro);
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosCirculo();
        }
    }
}
