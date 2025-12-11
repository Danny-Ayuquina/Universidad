namespace Algoritmos_Lineas
{
    partial class FrmPuntoMedio
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
            System.Windows.Forms.Button btnAnterior;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPFinalY = new System.Windows.Forms.TextBox();
            this.txtPFinalX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.txtPInicialY = new System.Windows.Forms.TextBox();
            this.txtPInicialX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picGrafico = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPuntos = new System.Windows.Forms.ListBox();
            btnAnterior = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGrafico)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new System.Drawing.Point(40, 337);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new System.Drawing.Size(75, 23);
            btnAnterior.TabIndex = 5;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPFinalY);
            this.groupBox1.Controls.Add(this.txtPFinalX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(btnAnterior);
            this.groupBox1.Controls.Add(this.btnDibujar);
            this.groupBox1.Controls.Add(this.txtPInicialY);
            this.groupBox1.Controls.Add(this.txtPInicialX);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(131, 280);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ingrese el punto final:";
            // 
            // txtPFinalY
            // 
            this.txtPFinalY.Location = new System.Drawing.Point(150, 228);
            this.txtPFinalY.Name = "txtPFinalY";
            this.txtPFinalY.Size = new System.Drawing.Size(49, 22);
            this.txtPFinalY.TabIndex = 12;
            // 
            // txtPFinalX
            // 
            this.txtPFinalX.Location = new System.Drawing.Point(67, 227);
            this.txtPFinalX.Name = "txtPFinalX";
            this.txtPFinalX.Size = new System.Drawing.Size(49, 22);
            this.txtPFinalX.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ingrese el punto inicial:";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(132, 337);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(40, 280);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(75, 23);
            this.btnDibujar.TabIndex = 4;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // txtPInicialY
            // 
            this.txtPInicialY.Location = new System.Drawing.Point(152, 119);
            this.txtPInicialY.Name = "txtPInicialY";
            this.txtPInicialY.Size = new System.Drawing.Size(49, 22);
            this.txtPInicialY.TabIndex = 1;
            // 
            // txtPInicialX
            // 
            this.txtPInicialX.Location = new System.Drawing.Point(69, 118);
            this.txtPInicialX.Name = "txtPInicialX";
            this.txtPInicialX.Size = new System.Drawing.Size(49, 22);
            this.txtPInicialX.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picGrafico);
            this.groupBox2.Location = new System.Drawing.Point(277, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 548);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfico";
            // 
            // picGrafico
            // 
            this.picGrafico.Location = new System.Drawing.Point(7, 22);
            this.picGrafico.Name = "picGrafico";
            this.picGrafico.Size = new System.Drawing.Size(710, 520);
            this.picGrafico.TabIndex = 0;
            this.picGrafico.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPuntos);
            this.groupBox3.Location = new System.Drawing.Point(13, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 161);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Puntos";
            // 
            // lstPuntos
            // 
            this.lstPuntos.FormattingEnabled = true;
            this.lstPuntos.ItemHeight = 16;
            this.lstPuntos.Location = new System.Drawing.Point(6, 22);
            this.lstPuntos.Name = "lstPuntos";
            this.lstPuntos.Size = new System.Drawing.Size(246, 132);
            this.lstPuntos.TabIndex = 0;
            // 
            // FrmPuntoMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPuntoMedio";
            this.Text = "FrmPuntoMedio";
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.TextBox txtPInicialY;
        private System.Windows.Forms.TextBox txtPInicialX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPFinalY;
        private System.Windows.Forms.TextBox txtPFinalX;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstPuntos;
    }
}