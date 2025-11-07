namespace AreaRombo
{
    partial class Rombo
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
            this.lblDiagonalMayor = new System.Windows.Forms.Label();
            this.lblDiagonalMenor = new System.Windows.Forms.Label();
            this.txtDiagonalMayor = new System.Windows.Forms.TextBox();
            this.txtDiagonalMenor = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblLado = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDiagonalMayor
            // 
            this.lblDiagonalMayor.AutoSize = true;
            this.lblDiagonalMayor.Location = new System.Drawing.Point(267, 99);
            this.lblDiagonalMayor.Name = "lblDiagonalMayor";
            this.lblDiagonalMayor.Size = new System.Drawing.Size(166, 16);
            this.lblDiagonalMayor.TabIndex = 0;
            this.lblDiagonalMayor.Text = "Ingrese la diagonal mayor:";
            // 
            // lblDiagonalMenor
            // 
            this.lblDiagonalMenor.AutoSize = true;
            this.lblDiagonalMenor.Location = new System.Drawing.Point(267, 133);
            this.lblDiagonalMenor.Name = "lblDiagonalMenor";
            this.lblDiagonalMenor.Size = new System.Drawing.Size(166, 16);
            this.lblDiagonalMenor.TabIndex = 1;
            this.lblDiagonalMenor.Text = "Ingrese la diagonal menor:";
            // 
            // txtDiagonalMayor
            // 
            this.txtDiagonalMayor.Location = new System.Drawing.Point(460, 99);
            this.txtDiagonalMayor.Name = "txtDiagonalMayor";
            this.txtDiagonalMayor.Size = new System.Drawing.Size(100, 22);
            this.txtDiagonalMayor.TabIndex = 2;
            this.txtDiagonalMayor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiagonalMayor_KeyPress);
            // 
            // txtDiagonalMenor
            // 
            this.txtDiagonalMenor.Location = new System.Drawing.Point(460, 127);
            this.txtDiagonalMenor.Name = "txtDiagonalMenor";
            this.txtDiagonalMenor.Size = new System.Drawing.Size(100, 22);
            this.txtDiagonalMenor.TabIndex = 3;
            this.txtDiagonalMenor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiagonalMenor_KeyPress);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(380, 273);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(334, 164);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(99, 16);
            this.lblLado.TabIndex = 5;
            this.lblLado.Text = "Ingrese el lado:";
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(460, 158);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 22);
            this.txtLado.TabIndex = 6;
            this.txtLado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLado_KeyPress);
            // 
            // Rombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtDiagonalMenor);
            this.Controls.Add(this.txtDiagonalMayor);
            this.Controls.Add(this.lblDiagonalMenor);
            this.Controls.Add(this.lblDiagonalMayor);
            this.Name = "Rombo";
            this.Text = "Rombo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiagonalMayor;
        private System.Windows.Forms.Label lblDiagonalMenor;
        private System.Windows.Forms.TextBox txtDiagonalMayor;
        private System.Windows.Forms.TextBox txtDiagonalMenor;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtLado;
    }
}