using AreaRombo;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        // Abre un solo formulario hijo: si ya existe del mismo tipo lo trae al frente,
        // en caso contrario cierra cualquier hijo abierto y crea uno nuevo.
        private void OpenSingleChild<T>() where T : Form, new()
        {
            // Si ya existe una instancia del mismo tipo, traerla al frente y maximizarla
            var existing = this.MdiChildren.OfType<T>().FirstOrDefault();
            if (existing != null)
            {
                existing.WindowState = FormWindowState.Maximized;
                existing.BringToFront();
                existing.Activate();
                return;
            }

            // Cerrar todos los hijos abiertos (asegura que solo haya uno)
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Crear y mostrar la nueva instancia maximizada
            var form = new T();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void rectánguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Rectangulo>();
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Cuadrado>();
        }

        private void triánguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Triangulo>();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Rombo>();
        }

        private void romboideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Romboide>();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Trapecio>();
        }

        private void círculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Circulo>();
        }

        private void polígonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingleChild<Poligono>();            
        }
    }
}
