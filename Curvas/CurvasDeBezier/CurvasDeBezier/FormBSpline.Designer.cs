namespace CurvasDeBezier
{
    partial class FormBSpline
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnDibujarCurva = new System.Windows.Forms.Button();
            this.btnAnimarCurva = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.cboGrado = new System.Windows.Forms.ComboBox();
            this.lblGrado = new System.Windows.Forms.Label();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 80);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1200, 620);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // btnDibujarCurva
            // 
            this.btnDibujarCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDibujarCurva.Location = new System.Drawing.Point(210, 40);
            this.btnDibujarCurva.Name = "btnDibujarCurva";
            this.btnDibujarCurva.Size = new System.Drawing.Size(150, 35);
            this.btnDibujarCurva.TabIndex = 1;
            this.btnDibujarCurva.Text = "Dibujar Curva";
            this.btnDibujarCurva.UseVisualStyleBackColor = true;
            this.btnDibujarCurva.Click += new System.EventHandler(this.btnDibujarCurva_Click);
            // 
            // btnAnimarCurva
            // 
            this.btnAnimarCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimarCurva.Location = new System.Drawing.Point(370, 40);
            this.btnAnimarCurva.Name = "btnAnimarCurva";
            this.btnAnimarCurva.Size = new System.Drawing.Size(150, 35);
            this.btnAnimarCurva.TabIndex = 2;
            this.btnAnimarCurva.Text = "Animar Curva";
            this.btnAnimarCurva.UseVisualStyleBackColor = true;
            this.btnAnimarCurva.Click += new System.EventHandler(this.btnAnimarCurva_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(530, 40);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 35);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.LightCyan;
            this.panelControl.Controls.Add(this.cboGrado);
            this.panelControl.Controls.Add(this.lblGrado);
            this.panelControl.Controls.Add(this.lblInstrucciones);
            this.panelControl.Controls.Add(this.btnDibujarCurva);
            this.panelControl.Controls.Add(this.btnLimpiar);
            this.panelControl.Controls.Add(this.btnAnimarCurva);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1200, 80);
            this.panelControl.TabIndex = 4;
            // 
            // cboGrado
            // 
            this.cboGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrado.FormattingEnabled = true;
            this.cboGrado.Location = new System.Drawing.Point(70, 45);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(130, 24);
            this.cboGrado.TabIndex = 6;
            this.cboGrado.SelectedIndexChanged += new System.EventHandler(this.cboGrado_SelectedIndexChanged);
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrado.Location = new System.Drawing.Point(12, 48);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(57, 17);
            this.lblGrado.TabIndex = 5;
            this.lblGrado.Text = "Grado:";
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.Location = new System.Drawing.Point(15, 10);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(500, 17);
            this.lblInstrucciones.TabIndex = 4;
            this.lblInstrucciones.Text = "Instrucciones";
            // 
            // timerAnimacion
            // 
            this.timerAnimacion.Interval = 20;
            this.timerAnimacion.Tick += new System.EventHandler(this.timerAnimacion_Tick);
            // 
            // FormBSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelControl);
            this.Name = "FormBSpline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curvas B-Spline - Grados 1-3 con N puntos";
            this.Load += new System.EventHandler(this.FormBSpline_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnDibujarCurva;
        private System.Windows.Forms.Button btnAnimarCurva;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Timer timerAnimacion;
        private System.Windows.Forms.ComboBox cboGrado;
        private System.Windows.Forms.Label lblGrado;
    }
}
