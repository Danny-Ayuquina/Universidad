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
    public partial class Poligono : Form
    {
        public Poligono()
        {
            InitializeComponent();
        }

        private void txtLado_TextChanged(object sender, EventArgs e)
        {

        }

        private float calcularPerimetro(float lado, float numeroDeLados)
        {
            float perimetro = (lado * numeroDeLados);
            return perimetro;
        }

        private float calcularArea(float perimetro, float apotema)
        {
            float area = perimetro * apotema/2;
            return area;
        }

        private void calcularParametrosPoligonoRegular()
        {
            float lado = float.Parse(txtLado.Text);
            float apotema = float.Parse(txtApotema.Text);
            float numeroDeLados = float.Parse(txtNumeroDeLados.Text);

            if (lado <= 0 || apotema <= 0 || numeroDeLados <=0)
            {
                MessageBox.Show("Se ha ingresado un valor no permitido");
            }
            else
            {
                float perimetro = calcularPerimetro(lado, numeroDeLados);
                float area = calcularArea(perimetro, apotema);
                MessageBox.Show("El área del Polígono regular de " + lado + " lados es = " + area + "\n" + "El perímetro del Polígono regular de " + lado + " lados es = " + perimetro);
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularParametrosPoligonoRegular();
        }

        // Helper: permite el punto decimal solo si tras aplicar la selección no existe ya un punto
        // y además no quedaría como primer carácter (es decir, ya hay al menos un dígito antes).
        private bool CanInsertDecimal(TextBox tb)
        {
            if (tb == null) return false;
            string text = tb.Text ?? string.Empty;
            int selStart = tb.SelectionStart;
            int selLength = tb.SelectionLength;

            // Texto resultante si se inserta el punto en la posición actual (reemplando selección)
            string result = text;
            if (selLength > 0)
            {
                // quitar la selección para simular el texto final antes de insertar el punto
                result = result.Remove(selStart, selLength);
            }

            // Si ya hay un punto en el texto resultante, no permitir otro
            if (result.Contains('.')) return false;

            // Si el texto resultante está vacío, no permitir '.' como primer carácter
            if (result.Length == 0) return false;

            // También evita que el punto quede inmediatamente después solo de un signo negativo (por si existiera)
            if (result == "-") return false;

            return true;
        }

        private void txtLado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancela la tecla
            }

            if (e.KeyChar == '.' && !CanInsertDecimal(sender as TextBox))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void txtApotema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancela la tecla
            }
            
            if (e.KeyChar == '.' && !CanInsertDecimal(sender as TextBox))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void txtNumeroDeLados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancela la tecla
            }

            if (e.KeyChar == '.' && !CanInsertDecimal(sender as TextBox))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }
    }
}
