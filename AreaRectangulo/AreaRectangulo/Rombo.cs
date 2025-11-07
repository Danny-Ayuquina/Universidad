using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaRombo
{
    public partial class Rombo : Form
    {
        public Rombo()
        {
            InitializeComponent();
        }

        private void txtDiagonalMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void txtDiagonalMenor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void txtLado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private float calcularPerimetro(float lado)
        {
            float perimetro = (lado*4);
            return perimetro;
        }

        private float calcularArea(float DiagonalMenor, float DiagonalMayor)
        {
            float area = DiagonalMenor * DiagonalMayor;
            return area;
        }

        private void calcularParametrosRombo()
        {
            float DiagonalMenor = float.Parse(txtDiagonalMenor.Text);
            float DiagonalMayor = float.Parse(txtDiagonalMayor.Text);
            float lado = float.Parse(txtLado.Text);

            if (DiagonalMenor <= 0 || DiagonalMayor <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(lado);
                float area = calcularArea(DiagonalMenor, DiagonalMayor);
                MessageBox.Show("El área del Rombo es = " + area + "\n" + "El perímetro del Rombo es = " + perimetro);
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosRombo();
        }
    }
}
