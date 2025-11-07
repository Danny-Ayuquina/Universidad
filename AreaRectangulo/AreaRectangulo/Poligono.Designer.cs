namespace AreaRectangulo
{
    partial class Poligono
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
            this.lblLado = new System.Windows.Forms.Label();
            this.lblApotema = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.txtApotema = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblNumeroDeLados = new System.Windows.Forms.Label();
            this.txtNumeroDeLados = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(233, 109);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(177, 16);
            this.lblLado.TabIndex = 0;
            this.lblLado.Text = "Ingrese el lado del polígono:";
            // 
            // lblApotema
            // 
            this.lblApotema.AutoSize = true;
            this.lblApotema.Location = new System.Drawing.Point(206, 215);
            this.lblApotema.Name = "lblApotema";
            this.lblApotema.Size = new System.Drawing.Size(204, 16);
            this.lblApotema.TabIndex = 1;
            this.lblApotema.Text = "Ingrese la apotéma del polígono:";
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(485, 109);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 22);
            this.txtLado.TabIndex = 2;
            this.txtLado.TextChanged += new System.EventHandler(this.txtLado_TextChanged);
            this.txtLado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLado_KeyPress);
            // 
            // txtApotema
            // 
            this.txtApotema.Location = new System.Drawing.Point(485, 209);
            this.txtApotema.Name = "txtApotema";
            this.txtApotema.Size = new System.Drawing.Size(100, 22);
            this.txtApotema.TabIndex = 3;
            this.txtApotema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApotema_KeyPress);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(368, 276);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblNumeroDeLados
            // 
            this.lblNumeroDeLados.AutoSize = true;
            this.lblNumeroDeLados.Location = new System.Drawing.Point(237, 165);
            this.lblNumeroDeLados.Name = "lblNumeroDeLados";
            this.lblNumeroDeLados.Size = new System.Drawing.Size(173, 16);
            this.lblNumeroDeLados.TabIndex = 5;
            this.lblNumeroDeLados.Text = "Ingrese el número de lados:";
            // 
            // txtNumeroDeLados
            // 
            this.txtNumeroDeLados.Location = new System.Drawing.Point(485, 165);
            this.txtNumeroDeLados.Name = "txtNumeroDeLados";
            this.txtNumeroDeLados.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroDeLados.TabIndex = 6;
            this.txtNumeroDeLados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDeLados_KeyPress);
            // 
            // Poligono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumeroDeLados);
            this.Controls.Add(this.lblNumeroDeLados);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtApotema);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblApotema);
            this.Controls.Add(this.lblLado);
            this.Name = "Poligono";
            this.Text = "Poligono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.Label lblApotema;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.TextBox txtApotema;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblNumeroDeLados;
        private System.Windows.Forms.TextBox txtNumeroDeLados;
    }
}