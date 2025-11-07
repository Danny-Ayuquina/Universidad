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
    public partial class Romboide : Form
    {
        public Romboide()
        {
            InitializeComponent();
        }

        private float calcularPerimetro(float ancho, float alto)
        {
            float perimetro = (ancho * 2) + (alto * 2);
            return perimetro;
        }

        private float calcularArea(float ancho, float alto)
        {
            float area = ancho * alto;
            return area;
        }

        private void calcularParametrosRomboide()
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
                MessageBox.Show("El área del Romboide es = " + area + "\n" + "El perímetro del Romboide es = " + perimetro);
            }

        }

        private void txtAlto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosRomboide();
        }
    }
}
