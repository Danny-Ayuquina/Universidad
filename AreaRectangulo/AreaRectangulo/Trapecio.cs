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
    public partial class Trapecio : Form
    {
        public Trapecio()
        {
            InitializeComponent();
        }

        private void txtAlto_TextChanged(object sender, EventArgs e)
        {

        }

        private float calcularPerimetro(float lado, float alto, float baseMayor, float baseMenor)
        {
            float perimetro = (lado* 2) + baseMayor+baseMenor;
            return perimetro;
        }

        private float calcularArea(float lado, float alto, float baseMayor, float baseMenor)
        {
            float area = (alto/2)*(baseMayor*baseMenor);
            return area;
        }

        private void calcularParametrosTrapecio()
        {
            float lado = float.Parse(txtLado.Text);
            float alto = float.Parse(txtAlto.Text);
            float baseMayor = float.Parse(txtBaseMayor.Text);
            float baseMenor = float.Parse(txtBaseMenor.Text);

            if (lado <= 0 || alto <= 0 || baseMayor <= 0 || baseMenor <= 0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(lado, alto, baseMayor, baseMenor);
                float area = calcularArea(lado, alto, baseMayor, baseMenor);
                MessageBox.Show("El área del trapecio es = " + area + "\n" + "El perímetro del trapecio es = " + perimetro);
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosTrapecio();
        }
    }
}
