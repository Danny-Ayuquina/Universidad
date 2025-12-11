namespace Algoritmos_Lineas
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.círculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamCirculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioCirculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoFigurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liangBarskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.líneasToolStripMenuItem,
            this.círculosToolStripMenuItem,
            this.rellenoToolStripMenuItem,
            this.recorteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // líneasToolStripMenuItem
            // 
            this.líneasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.bresenhamToolStripMenuItem,
            this.puntoMedioToolStripMenuItem});
            this.líneasToolStripMenuItem.Name = "líneasToolStripMenuItem";
            this.líneasToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.líneasToolStripMenuItem.Text = "Líneas";
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dDAToolStripMenuItem.Text = "DDA";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bresenhamToolStripMenuItem
            // 
            this.bresenhamToolStripMenuItem.Name = "bresenhamToolStripMenuItem";
            this.bresenhamToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.bresenhamToolStripMenuItem.Text = "Bresenham";
            this.bresenhamToolStripMenuItem.Click += new System.EventHandler(this.bresenhamToolStripMenuItem_Click);
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.puntoMedioToolStripMenuItem.Text = "Punto medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // círculosToolStripMenuItem
            // 
            this.círculosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulaGeneralToolStripMenuItem,
            this.bresenhamCirculoToolStripMenuItem,
            this.puntoMedioCirculoToolStripMenuItem});
            this.círculosToolStripMenuItem.Name = "círculosToolStripMenuItem";
            this.círculosToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.círculosToolStripMenuItem.Text = "Círculos";
            // 
            // formulaGeneralToolStripMenuItem
            // 
            this.formulaGeneralToolStripMenuItem.Name = "formulaGeneralToolStripMenuItem";
            this.formulaGeneralToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.formulaGeneralToolStripMenuItem.Text = "Fórmula General";
            this.formulaGeneralToolStripMenuItem.Click += new System.EventHandler(this.formulaGeneralToolStripMenuItem_Click);
            // 
            // bresenhamCirculoToolStripMenuItem
            // 
            this.bresenhamCirculoToolStripMenuItem.Name = "bresenhamCirculoToolStripMenuItem";
            this.bresenhamCirculoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.bresenhamCirculoToolStripMenuItem.Text = "Bresenham";
            this.bresenhamCirculoToolStripMenuItem.Click += new System.EventHandler(this.bresenhamCirculoToolStripMenuItem_Click);
            // 
            // puntoMedioCirculoToolStripMenuItem
            // 
            this.puntoMedioCirculoToolStripMenuItem.Name = "puntoMedioCirculoToolStripMenuItem";
            this.puntoMedioCirculoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.puntoMedioCirculoToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioCirculoToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioCirculoToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rellenoFigurasToolStripMenuItem});
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // rellenoFigurasToolStripMenuItem
            // 
            this.rellenoFigurasToolStripMenuItem.Name = "rellenoFigurasToolStripMenuItem";
            this.rellenoFigurasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rellenoFigurasToolStripMenuItem.Text = "Relleno de Figuras";
            this.rellenoFigurasToolStripMenuItem.Click += new System.EventHandler(this.rellenoFigurasToolStripMenuItem_Click);
            // 
            // recorteToolStripMenuItem
            // 
            this.recorteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sutherlandHodgmanToolStripMenuItem,
            this.cohenSutherlandToolStripMenuItem,
            this.liangBarskyToolStripMenuItem});
            this.recorteToolStripMenuItem.Name = "recorteToolStripMenuItem";
            this.recorteToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.recorteToolStripMenuItem.Text = "Recorte";
            // 
            // sutherlandHodgmanToolStripMenuItem
            // 
            this.sutherlandHodgmanToolStripMenuItem.Name = "sutherlandHodgmanToolStripMenuItem";
            this.sutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.sutherlandHodgmanToolStripMenuItem.Text = "Sutherland-Hodgman";
            this.sutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.sutherlandHodgmanToolStripMenuItem_Click);
            // 
            // cohenSutherlandToolStripMenuItem
            // 
            this.cohenSutherlandToolStripMenuItem.Name = "cohenSutherlandToolStripMenuItem";
            this.cohenSutherlandToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.cohenSutherlandToolStripMenuItem.Text = "Cohen-Sutherland";
            this.cohenSutherlandToolStripMenuItem.Click += new System.EventHandler(this.cohenSutherlandToolStripMenuItem_Click);
            // 
            // liangBarskyToolStripMenuItem
            // 
            this.liangBarskyToolStripMenuItem.Name = "liangBarskyToolStripMenuItem";
            this.liangBarskyToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.liangBarskyToolStripMenuItem.Text = "Liang-Barsky";
            this.liangBarskyToolStripMenuItem.Click += new System.EventHandler(this.liangBarskyToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 654);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menú";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem círculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulaGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamCirculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioCirculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoFigurasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohenSutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liangBarskyToolStripMenuItem;
    }
}

