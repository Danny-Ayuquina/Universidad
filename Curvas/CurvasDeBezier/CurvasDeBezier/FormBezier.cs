using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CurvasDeBezier
{
    public partial class FormBezier : Form
    {
        // Lista de puntos de control
        private List<PointF> puntosControl = new List<PointF>();
        
        // Para la animación
        private bool animando = false;
        private float parametroT = 0f;
        private const float incrementoT = 0.02f;
        
        // Para arrastrar puntos
        private bool arrastrandoPunto = false;
        private int indicePuntoArrastrado = -1;
        private const float radioDeteccion = 10f;
        
        // Colores
        private readonly Color colorPuntos = Color.Red;
        private readonly Color colorLineasControl = Color.Blue;
        private readonly Color colorCurva = Color.Green;
        private readonly Color colorAnimacion = Color.Orange;
        private readonly Color colorPuntoSeleccionado = Color.DarkRed;
        
        public FormBezier()
        {
            InitializeComponent();
            // Activar doble buffer para evitar parpadeo
            this.pictureBox.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(this.pictureBox, true, null);
        }

        private void FormBezier_Load(object sender, EventArgs e)
        {
            ActualizarInstrucciones();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Solo agregar puntos si no estamos arrastrando
            if (arrastrandoPunto)
                return;

            // Verificar si hicimos clic cerca de un punto existente
            int indicePunto = ObtenerIndicePuntoCercano(e.Location);
            if (indicePunto >= 0)
                return;

            // Agregar punto sin límite
            puntosControl.Add(new PointF(e.X, e.Y));
            pictureBox.Invalidate();
            ActualizarInstrucciones();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            int indicePunto = ObtenerIndicePuntoCercano(e.Location);
            
            if (indicePunto >= 0)
            {
                arrastrandoPunto = true;
                indicePuntoArrastrado = indicePunto;
                pictureBox.Cursor = Cursors.Hand;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrandoPunto && indicePuntoArrastrado >= 0)
            {
                puntosControl[indicePuntoArrastrado] = new PointF(e.X, e.Y);
                pictureBox.Invalidate();
            }
            else
            {
                int indicePunto = ObtenerIndicePuntoCercano(e.Location);
                pictureBox.Cursor = indicePunto >= 0 ? Cursors.SizeAll : Cursors.Default;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (arrastrandoPunto)
            {
                arrastrandoPunto = false;
                indicePuntoArrastrado = -1;
                pictureBox.Cursor = Cursors.Default;
            }
        }

        private int ObtenerIndicePuntoCercano(Point posicionMouse)
        {
            for (int i = 0; i < puntosControl.Count; i++)
            {
                float distancia = CalcularDistancia(posicionMouse, puntosControl[i]);
                if (distancia <= radioDeteccion)
                    return i;
            }
            return -1;
        }

        private float CalcularDistancia(Point p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dibujar líneas entre puntos de control
            if (puntosControl.Count > 1)
            {
                using (Pen penLineas = new Pen(colorLineasControl, 1))
                {
                    penLineas.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    for (int i = 0; i < puntosControl.Count - 1; i++)
                    {
                        g.DrawLine(penLineas, puntosControl[i], puntosControl[i + 1]);
                    }
                }
            }

            // Dibujar puntos de control
            for (int i = 0; i < puntosControl.Count; i++)
            {
                Color colorPunto = (i == indicePuntoArrastrado && arrastrandoPunto) 
                    ? colorPuntoSeleccionado 
                    : colorPuntos;
                DibujarPunto(g, puntosControl[i], colorPunto, 8);
            }

            // Dibujar etiquetas de puntos
            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < puntosControl.Count; i++)
                {
                    g.DrawString($"P{i}", font, brush, 
                        puntosControl[i].X + 10, puntosControl[i].Y - 10);
                }
            }

            // Si estamos animando, dibujar la curva parcial
            if (animando && puntosControl.Count >= 2)
            {
                DibujarCurvaBezierParcial(g, parametroT);
            }
        }

        private void DibujarPunto(Graphics g, PointF punto, Color color, int tamaño)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, punto.X - tamaño / 2, punto.Y - tamaño / 2, tamaño, tamaño);
            }
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, punto.X - tamaño / 2, punto.Y - tamaño / 2, tamaño, tamaño);
            }
        }

        private void btnDibujarCurva_Click(object sender, EventArgs e)
        {
            if (puntosControl.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 puntos de control para dibujar una curva de Bézier.", 
                    "Puntos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            timerAnimacion.Stop();
            animando = false;
            parametroT = 0f;

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                DibujarCurvaBezierCompleta(g);

                // Dibujar líneas de control
                if (puntosControl.Count > 1)
                {
                    using (Pen penLineas = new Pen(colorLineasControl, 1))
                    {
                        penLineas.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        for (int i = 0; i < puntosControl.Count - 1; i++)
                        {
                            g.DrawLine(penLineas, puntosControl[i], puntosControl[i + 1]);
                        }
                    }
                }

                foreach (PointF punto in puntosControl)
                {
                    DibujarPunto(g, punto, colorPuntos, 8);
                }

                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    for (int i = 0; i < puntosControl.Count; i++)
                    {
                        g.DrawString($"P{i}", font, brush, 
                            puntosControl[i].X + 10, puntosControl[i].Y - 10);
                    }
                }
            }

            pictureBox.Image = bmp;
        }

        private void btnAnimarCurva_Click(object sender, EventArgs e)
        {
            if (puntosControl.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 puntos de control para animar una curva de Bézier.", 
                    "Puntos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            parametroT = 0f;
            animando = true;
            pictureBox.Image = null;
            timerAnimacion.Start();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntosControl.Clear();
            timerAnimacion.Stop();
            animando = false;
            parametroT = 0f;
            pictureBox.Image = null;
            pictureBox.Invalidate();
            ActualizarInstrucciones();
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            if (parametroT >= 1.0f)
            {
                timerAnimacion.Stop();
                animando = false;
                parametroT = 0f;
                return;
            }

            parametroT += incrementoT;
            pictureBox.Invalidate();
        }

        private void DibujarCurvaBezierCompleta(Graphics g)
        {
            List<PointF> puntosCurva = new List<PointF>();

            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                PointF punto = CalcularPuntoBezierGeneral(t);
                puntosCurva.Add(punto);
            }

            puntosCurva.Add(CalcularPuntoBezierGeneral(1.0f));

            if (puntosCurva.Count > 1)
            {
                using (Pen penCurva = new Pen(colorCurva, 3))
                {
                    g.DrawLines(penCurva, puntosCurva.ToArray());
                }
            }
        }

        private void DibujarCurvaBezierParcial(Graphics g, float tMax)
        {
            List<PointF> puntosCurva = new List<PointF>();

            for (float t = 0; t <= tMax; t += 0.01f)
            {
                PointF punto = CalcularPuntoBezierGeneral(t);
                puntosCurva.Add(punto);
            }

            if (tMax > 0)
            {
                puntosCurva.Add(CalcularPuntoBezierGeneral(tMax));
            }

            if (puntosCurva.Count > 1)
            {
                using (Pen penCurva = new Pen(colorAnimacion, 3))
                {
                    g.DrawLines(penCurva, puntosCurva.ToArray());
                }
            }

            if (tMax > 0)
            {
                PointF puntoActual = CalcularPuntoBezierGeneral(tMax);
                DibujarPunto(g, puntoActual, Color.Purple, 10);
            }
        }

        // Algoritmo de De Casteljau generalizado para n puntos
        private PointF CalcularPuntoBezierGeneral(float t)
        {
            if (puntosControl.Count == 0)
                return new PointF(0, 0);

            // Copiar puntos de control a un array temporal
            List<PointF> puntosTemp = new List<PointF>(puntosControl);

            // Aplicar el algoritmo de De Casteljau
            while (puntosTemp.Count > 1)
            {
                List<PointF> nuevosPuntos = new List<PointF>();
                
                for (int i = 0; i < puntosTemp.Count - 1; i++)
                {
                    float x = (1 - t) * puntosTemp[i].X + t * puntosTemp[i + 1].X;
                    float y = (1 - t) * puntosTemp[i].Y + t * puntosTemp[i + 1].Y;
                    nuevosPuntos.Add(new PointF(x, y));
                }
                
                puntosTemp = nuevosPuntos;
            }

            return puntosTemp[0];
        }

        private void ActualizarInstrucciones()
        {
            int puntos = puntosControl.Count;
            int grado = Math.Max(0, puntos - 1);
            
            if (puntos == 0)
            {
                lblInstrucciones.Text = "Haz click en el lienzo para agregar puntos de control (sin límite). Arrastra los puntos para moverlos.";
            }
            else if (puntos == 1)
            {
                lblInstrucciones.Text = $"Puntos: {puntos}. Agrega al menos 1 punto más para crear una curva. Arrastra los puntos para moverlos.";
            }
            else
            {
                string tipoGrado = "";
                if (grado == 1) tipoGrado = " (lineal)";
                else if (grado == 2) tipoGrado = " (cuadrática)";
                else if (grado == 3) tipoGrado = " (cúbica)";
                
                lblInstrucciones.Text = $"Puntos: {puntos}. Curva de Bézier de grado {grado}{tipoGrado}. Puedes agregar más puntos, arrastrarlos o dibujar.";
            }
        }
    }
}
