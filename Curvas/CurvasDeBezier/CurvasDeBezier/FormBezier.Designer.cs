namespace CurvasDeBezier
{
    partial class FormBezier
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
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 98);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1600, 764);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnDibujarCurva
            // 
            this.btnDibujarCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDibujarCurva.Location = new System.Drawing.Point(20, 49);
            this.btnDibujarCurva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDibujarCurva.Name = "btnDibujarCurva";
            this.btnDibujarCurva.Size = new System.Drawing.Size(200, 43);
            this.btnDibujarCurva.TabIndex = 1;
            this.btnDibujarCurva.Text = "Dibujar Curva";
            this.btnDibujarCurva.UseVisualStyleBackColor = true;
            this.btnDibujarCurva.Click += new System.EventHandler(this.btnDibujarCurva_Click);
            // 
            // btnAnimarCurva
            // 
            this.btnAnimarCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimarCurva.Location = new System.Drawing.Point(233, 49);
            this.btnAnimarCurva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnimarCurva.Name = "btnAnimarCurva";
            this.btnAnimarCurva.Size = new System.Drawing.Size(200, 43);
            this.btnAnimarCurva.TabIndex = 2;
            this.btnAnimarCurva.Text = "Animar Curva";
            this.btnAnimarCurva.UseVisualStyleBackColor = true;
            this.btnAnimarCurva.Click += new System.EventHandler(this.btnAnimarCurva_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(447, 49);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 43);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.LightGreen;
            this.panelControl.Controls.Add(this.lblInstrucciones);
            this.panelControl.Controls.Add(this.btnDibujarCurva);
            this.panelControl.Controls.Add(this.btnLimpiar);
            this.panelControl.Controls.Add(this.btnAnimarCurva);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1600, 98);
            this.panelControl.TabIndex = 4;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.Location = new System.Drawing.Point(20, 12);
            this.lblInstrucciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(109, 20);
            this.lblInstrucciones.TabIndex = 4;
            this.lblInstrucciones.Text = "Instrucciones";
            // 
            // timerAnimacion
            // 
            this.timerAnimacion.Interval = 20;
            this.timerAnimacion.Tick += new System.EventHandler(this.timerAnimacion_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // FormBezier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormBezier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curvas de Bézier - Generalizado para N puntos";
            this.Load += new System.EventHandler(this.FormBezier_Load);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
