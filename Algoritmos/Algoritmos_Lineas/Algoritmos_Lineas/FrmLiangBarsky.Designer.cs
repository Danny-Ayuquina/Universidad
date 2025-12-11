namespace Algoritmos_Lineas
{
    partial class FrmLiangBarsky
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
            this.lstVentana = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLineas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnDibujarVentana = new System.Windows.Forms.Button();
            this.btnDibujarLinea = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picGrafico = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRecortado = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGrafico)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstVentana);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstLineas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnRecortar);
            this.groupBox1.Controls.Add(this.btnDibujarVentana);
            this.groupBox1.Controls.Add(this.btnDibujarLinea);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // lstVentana
            // 
            this.lstVentana.FormattingEnabled = true;
            this.lstVentana.ItemHeight = 16;
            this.lstVentana.Location = new System.Drawing.Point(20, 310);
            this.lstVentana.Name = "lstVentana";
            this.lstVentana.Size = new System.Drawing.Size(220, 100);
            this.lstVentana.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ventana de recorte:";
            // 
            // lstLineas
            // 
            this.lstLineas.FormattingEnabled = true;
            this.lstLineas.ItemHeight = 16;
            this.lstLineas.Location = new System.Drawing.Point(20, 160);
            this.lstLineas.Name = "lstLineas";
            this.lstLineas.Size = new System.Drawing.Size(220, 100);
            this.lstLineas.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Líneas dibujadas:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 490);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(220, 30);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(20, 440);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(220, 30);
            this.btnRecortar.TabIndex = 2;
            this.btnRecortar.Text = "Recortar Líneas";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnDibujarVentana
            // 
            this.btnDibujarVentana.Location = new System.Drawing.Point(20, 80);
            this.btnDibujarVentana.Name = "btnDibujarVentana";
            this.btnDibujarVentana.Size = new System.Drawing.Size(220, 30);
            this.btnDibujarVentana.TabIndex = 1;
            this.btnDibujarVentana.Text = "Dibujar Ventana de Recorte";
            this.btnDibujarVentana.UseVisualStyleBackColor = true;
            this.btnDibujarVentana.Click += new System.EventHandler(this.btnDibujarVentana_Click);
            // 
            // btnDibujarLinea
            // 
            this.btnDibujarLinea.Location = new System.Drawing.Point(20, 30);
            this.btnDibujarLinea.Name = "btnDibujarLinea";
            this.btnDibujarLinea.Size = new System.Drawing.Size(220, 30);
            this.btnDibujarLinea.TabIndex = 0;
            this.btnDibujarLinea.Text = "Dibujar Línea";
            this.btnDibujarLinea.UseVisualStyleBackColor = true;
            this.btnDibujarLinea.Click += new System.EventHandler(this.btnDibujarLinea_Click);
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
            this.groupBox3.Controls.Add(this.lstRecortado);
            this.groupBox3.Location = new System.Drawing.Point(783, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 548);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultado del Recorte";
            // 
            // lstRecortado
            // 
            this.lstRecortado.FormattingEnabled = true;
            this.lstRecortado.ItemHeight = 16;
            this.lstRecortado.Location = new System.Drawing.Point(6, 22);
            this.lstRecortado.Name = "lstRecortado";
            this.lstRecortado.Size = new System.Drawing.Size(205, 516);
            this.lstRecortado.TabIndex = 0;
            // 
            // FrmLiangBarsky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLiangBarsky";
            this.Text = "Recorte de Líneas - Liang-Barsky";
            this.Load += new System.EventHandler(this.FrmLiangBarsky_Load);
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
        private System.Windows.Forms.ListBox lstRecortado;
        private System.Windows.Forms.Button btnDibujarLinea;
        private System.Windows.Forms.Button btnDibujarVentana;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lstLineas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstVentana;
        private System.Windows.Forms.Label label2;
    }
}
