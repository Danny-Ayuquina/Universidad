namespace Algoritmos_Lineas
{
    partial class FrmRelleno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScanlineFill = new System.Windows.Forms.Button();
            this.btnBoundaryFill = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            this.btnCerrarFigura = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picGrafico = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPixeles = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGrafico)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScanlineFill);
            this.groupBox1.Controls.Add(this.btnBoundaryFill);
            this.groupBox1.Controls.Add(this.btnFloodFill);
            this.groupBox1.Controls.Add(this.btnCerrarFigura);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstVertices);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnScanlineFill
            // 
            this.btnScanlineFill.Location = new System.Drawing.Point(20, 400);
            this.btnScanlineFill.Name = "btnScanlineFill";
            this.btnScanlineFill.Size = new System.Drawing.Size(220, 30);
            this.btnScanlineFill.TabIndex = 6;
            this.btnScanlineFill.Text = "Scanline Fill (Verde)";
            this.btnScanlineFill.UseVisualStyleBackColor = true;
            this.btnScanlineFill.Click += new System.EventHandler(this.btnScanlineFill_Click);
            // 
            // btnBoundaryFill
            // 
            this.btnBoundaryFill.Location = new System.Drawing.Point(20, 364);
            this.btnBoundaryFill.Name = "btnBoundaryFill";
            this.btnBoundaryFill.Size = new System.Drawing.Size(220, 30);
            this.btnBoundaryFill.TabIndex = 5;
            this.btnBoundaryFill.Text = "Boundary Fill (Azul)";
            this.btnBoundaryFill.UseVisualStyleBackColor = true;
            this.btnBoundaryFill.Click += new System.EventHandler(this.btnBoundaryFill_Click);
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.Location = new System.Drawing.Point(20, 328);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(220, 30);
            this.btnFloodFill.TabIndex = 4;
            this.btnFloodFill.Text = "Flood Fill (Rojo)";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            // 
            // btnCerrarFigura
            // 
            this.btnCerrarFigura.Location = new System.Drawing.Point(20, 275);
            this.btnCerrarFigura.Name = "btnCerrarFigura";
            this.btnCerrarFigura.Size = new System.Drawing.Size(220, 30);
            this.btnCerrarFigura.TabIndex = 3;
            this.btnCerrarFigura.Text = "Cerrar Figura";
            this.btnCerrarFigura.UseVisualStyleBackColor = true;
            this.btnCerrarFigura.Click += new System.EventHandler(this.btnCerrarFigura_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 490);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(220, 30);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Haga clic para dibujar la figura:";
            // 
            // lstVertices
            // 
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.ItemHeight = 16;
            this.lstVertices.Location = new System.Drawing.Point(20, 60);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(220, 196);
            this.lstVertices.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picGrafico);
            this.groupBox2.Location = new System.Drawing.Point(277, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 548);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Área de Dibujo";
            // 
            // picGrafico
            // 
            this.picGrafico.BackColor = System.Drawing.Color.White;
            this.picGrafico.Location = new System.Drawing.Point(7, 22);
            this.picGrafico.Name = "picGrafico";
            this.picGrafico.Size = new System.Drawing.Size(485, 515);
            this.picGrafico.TabIndex = 0;
            this.picGrafico.TabStop = false;
            this.picGrafico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGrafico_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPixeles);
            this.groupBox3.Location = new System.Drawing.Point(783, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 548);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Píxeles Pintados";
            // 
            // lstPixeles
            // 
            this.lstPixeles.FormattingEnabled = true;
            this.lstPixeles.ItemHeight = 16;
            this.lstPixeles.Location = new System.Drawing.Point(6, 22);
            this.lstPixeles.Name = "lstPixeles";
            this.lstPixeles.Size = new System.Drawing.Size(205, 516);
            this.lstPixeles.TabIndex = 0;
            // 
            // FrmRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRelleno";
            this.Text = "Relleno de Figuras";
            this.Load += new System.EventHandler(this.FrmRelleno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGrafico)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picGrafico;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstPixeles;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnFloodFill;
        private System.Windows.Forms.Button btnCerrarFigura;
        private System.Windows.Forms.Button btnBoundaryFill;
        private System.Windows.Forms.Button btnScanlineFill;
    }
}
