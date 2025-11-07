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
    public partial class Triangulo : Form
    {
        public Triangulo()
        {
            InitializeComponent();
        }

        private void txtAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void txtBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private float calcularPerimetro(float baseT)
        {
            float perimetro = (baseT * 3);
            return perimetro;
        }

        private float calcularArea(float baseT, float alto)
        {
            float area = (baseT*alto)/2;
            return area;
        }

        private void calcularParametrosTriangulo()
        {
            float baseT = float.Parse(txtBase.Text);
            float alto = float.Parse(txtAlto.Text);

            if (baseT <= 0 || alto <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(baseT);
                float area = calcularArea(baseT, alto);
                MessageBox.Show("El área del Triángulo es = " + area + "\n" + "El perímetro del Triángulo es = " + perimetro);
            }
                
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosTriangulo();
        }
    }
}
