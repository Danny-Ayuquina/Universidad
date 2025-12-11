namespace Algoritmos_Lineas
{
    partial class FrmCirculoFormulaGeneral
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCentroY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCentroX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picGrafico = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPuntos = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGrafico)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.btnAnterior);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnDibujar);
            this.groupBox1.Controls.Add(this.txtRadio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCentroY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCentroX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(17, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "💡 Haz clic en el área de dibujo para seleccionar el centro";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(20, 470);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(210, 60);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "Ingrese los parámetros y presione Dibujar";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(20, 380);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(210, 35);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.Text = "← Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(20, 330);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(210, 35);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.Text = "Siguiente →";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 270);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(210, 35);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(20, 220);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(210, 35);
            this.btnDibujar.TabIndex = 6;
            this.btnDibujar.Text = "Dibujar Círculo";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // txtRadio
            // 
            this.txtRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadio.Location = new System.Drawing.Point(20, 180);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(210, 26);
            this.txtRadio.TabIndex = 5;
            this.txtRadio.Text = "80";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Radio:";
            // 
            // txtCentroY
            // 
            this.txtCentroY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentroY.Location = new System.Drawing.Point(20, 80);
            this.txtCentroY.Name = "txtCentroY";
            this.txtCentroY.Size = new System.Drawing.Size(210, 26);
            this.txtCentroY.TabIndex = 3;
            this.txtCentroY.Text = "250";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Centro Y:";
            // 
            // txtCentroX
            // 
            this.txtCentroX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentroX.Location = new System.Drawing.Point(20, 30);
            this.txtCentroX.Name = "txtCentroX";
            this.txtCentroX.Size = new System.Drawing.Size(210, 26);
            this.txtCentroX.TabIndex = 1;
            this.txtCentroX.Text = "250";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Centro X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picGrafico);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 548);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Área de Dibujo";
            // 
            // picGrafico
            // 
            this.picGrafico.BackColor = System.Drawing.Color.White;
            this.picGrafico.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picGrafico.Location = new System.Drawing.Point(6, 21);
            this.picGrafico.Name = "picGrafico";
            this.picGrafico.Size = new System.Drawing.Size(515, 515);
            this.picGrafico.TabIndex = 0;
            this.picGrafico.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPuntos);
            this.groupBox3.Location = new System.Drawing.Point(804, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 548);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Puntos Calculados";
            // 
            // lstPuntos
            // 
            this.lstPuntos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPuntos.FormattingEnabled = true;
            this.lstPuntos.ItemHeight = 18;
            this.lstPuntos.Location = new System.Drawing.Point(6, 21);
            this.lstPuntos.Name = "lstPuntos";
            this.lstPuntos.Size = new System.Drawing.Size(268, 508);
            this.lstPuntos.TabIndex = 0;
            // 
            // FrmCirculoFormulaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 572);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCirculoFormulaGeneral";
            this.Text = "Círculos - Fórmula General";
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
        private System.Windows.Forms.ListBox lstPuntos;
        private System.Windows.Forms.TextBox txtCentroX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCentroY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label4;
    }
}