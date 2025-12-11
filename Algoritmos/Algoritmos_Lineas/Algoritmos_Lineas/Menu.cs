using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmDDA frmDDA = new FrmDDA();
            frmDDA.MdiParent = this;
            frmDDA.Dock = DockStyle.Fill;
            frmDDA.Show();
        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmBresenham frmBresenham = new FrmBresenham();
            frmBresenham.MdiParent = this;
            frmBresenham.Dock = DockStyle.Fill;
            frmBresenham.Show();
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmPuntoMedio frmPuntoMedio = new FrmPuntoMedio();
            frmPuntoMedio.MdiParent = this;
            frmPuntoMedio.Dock = DockStyle.Fill;
            frmPuntoMedio.Show();
        }

        private void formulaGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmCirculoFormulaGeneral frmCirculo = new FrmCirculoFormulaGeneral();
            frmCirculo.MdiParent = this;
            frmCirculo.Dock = DockStyle.Fill;
            frmCirculo.Show();
        }

        private void bresenhamCirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmCirculoBresenham frmBresenham = new FrmCirculoBresenham();
            frmBresenham.MdiParent = this;
            frmBresenham.Dock = DockStyle.Fill;
            frmBresenham.Show();
        }

        private void puntoMedioCirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmCirculoPuntoMedio frmPuntoMedio = new FrmCirculoPuntoMedio();
            frmPuntoMedio.MdiParent = this;
            frmPuntoMedio.Dock = DockStyle.Fill;
            frmPuntoMedio.Show();
        }

        private void rellenoFigurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmRelleno frmRelleno = new FrmRelleno();
            frmRelleno.MdiParent = this;
            frmRelleno.Dock = DockStyle.Fill;
            frmRelleno.Show();
        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmSutherlandHodgman frmSutherland = new FrmSutherlandHodgman();
            frmSutherland.MdiParent = this;
            frmSutherland.Dock = DockStyle.Fill;
            frmSutherland.Show();
        }

        private void cohenSutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmCohenSutherland frmCohen = new FrmCohenSutherland();
            frmCohen.MdiParent = this;
            frmCohen.Dock = DockStyle.Fill;
            frmCohen.Show();
        }

        private void liangBarskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmLiangBarsky frmLiangBarsky = new FrmLiangBarsky();
            frmLiangBarsky.MdiParent = this;
            frmLiangBarsky.Dock = DockStyle.Fill;
            frmLiangBarsky.Show();
        }
    }
}
