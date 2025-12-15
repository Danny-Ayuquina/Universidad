using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CurvasDeBezier
{
    public partial class FormBSpline : Form
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
        
        // Grado de la curva B-Spline
        private int grado = 3; // Por defecto cúbica
        
        // Colores
        private readonly Color colorPuntos = Color.Red;
        private readonly Color colorLineasControl = Color.Blue;
        private readonly Color colorCurva = Color.DarkCyan;
        private readonly Color colorAnimacion = Color.Orange;
        private readonly Color colorPuntoSeleccionado = Color.DarkRed;
        
        public FormBSpline()
        {
            InitializeComponent();
            // Activar doble buffer para evitar parpadeo
            this.pictureBox.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(this.pictureBox, true, null);
        }

        private void FormBSpline_Load(object sender, EventArgs e)
        {
            // Configurar el combo box de grados
            cboGrado.Items.Add("Grado 1 (Lineal)");
            cboGrado.Items.Add("Grado 2 (Cuadrática)");
            cboGrado.Items.Add("Grado 3 (Cúbica)");
            cboGrado.SelectedIndex = 2; // Por defecto grado 3
            
            ActualizarInstrucciones();
        }

        private void cboGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            grado = cboGrado.SelectedIndex + 1;
            ActualizarInstrucciones();
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (arrastrandoPunto)
                return;

            int indicePunto = ObtenerIndicePuntoCercano(e.Location);
            if (indicePunto >= 0)
                return;

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
            if (animando && puntosControl.Count >= grado + 1)
            {
                DibujarCurvaBSplineParcial(g, parametroT);
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
            int puntosMinimos = grado + 1;
            
            if (puntosControl.Count < puntosMinimos)
            {
                MessageBox.Show($"Para B-Spline de grado {grado} necesitas al menos {puntosMinimos} puntos de control.", 
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

                DibujarCurvaBSplineCompleta(g);

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
            int puntosMinimos = grado + 1;
            
            if (puntosControl.Count < puntosMinimos)
            {
                MessageBox.Show($"Para B-Spline de grado {grado} necesitas al menos {puntosMinimos} puntos de control.", 
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

        private void DibujarCurvaBSplineCompleta(Graphics g)
        {
            if (puntosControl.Count < grado + 1)
                return;

            List<PointF> puntosCurva = new List<PointF>();
            List<float> vectorNudos = GenerarVectorNudos();

            float tMin = vectorNudos[grado];
            float tMax = vectorNudos[puntosControl.Count];

            try
            {
                for (float t = tMin; t <= tMax; t += 0.01f)
                {
                    PointF punto = CalcularPuntoBSpline(t, vectorNudos);
                    
                    // Validar que el punto es válido
                    if (!float.IsNaN(punto.X) && !float.IsNaN(punto.Y) &&
                        !float.IsInfinity(punto.X) && !float.IsInfinity(punto.Y))
                    {
                        puntosCurva.Add(punto);
                    }
                }

                // Asegurar que se incluye el punto final
                PointF puntoFinal = CalcularPuntoBSpline(tMax, vectorNudos);
                
                if (!float.IsNaN(puntoFinal.X) && !float.IsNaN(puntoFinal.Y) &&
                    !float.IsInfinity(puntoFinal.X) && !float.IsInfinity(puntoFinal.Y))
                {
                    puntosCurva.Add(puntoFinal);
                }
            }
            catch (Exception)
            {
                // En caso de error, trabajamos con los puntos que tenemos
            }

            if (puntosCurva.Count > 1)
            {
                using (Pen penCurva = new Pen(colorCurva, 3))
                {
                    g.DrawLines(penCurva, puntosCurva.ToArray());
                }
            }
        }

        private void DibujarCurvaBSplineParcial(Graphics g, float tMaxParam)
        {
            if (puntosControl.Count < grado + 1)
                return;

            List<PointF> puntosCurva = new List<PointF>();
            List<float> vectorNudos = GenerarVectorNudos();

            float tMin = vectorNudos[grado];
            float tMax = vectorNudos[puntosControl.Count];
            
            // Asegurar que tMaxParam está en [0, 1]
            if (tMaxParam < 0) tMaxParam = 0;
            if (tMaxParam > 1) tMaxParam = 1;
            
            float tActual = tMin + (tMax - tMin) * tMaxParam;
            
            // Asegurar que tActual está en el rango válido
            if (tActual < tMin) tActual = tMin;
            if (tActual > tMax) tActual = tMax;

            try
            {
                for (float t = tMin; t <= tActual; t += 0.01f)
                {
                    PointF punto = CalcularPuntoBSpline(t, vectorNudos);
                    
                    // Validar que el punto es válido antes de agregarlo
                    if (!float.IsNaN(punto.X) && !float.IsNaN(punto.Y) &&
                        !float.IsInfinity(punto.X) && !float.IsInfinity(punto.Y))
                    {
                        puntosCurva.Add(punto);
                    }
                }

                if (tMaxParam > 0)
                {
                    PointF puntoFinal = CalcularPuntoBSpline(tActual, vectorNudos);
                    
                    if (!float.IsNaN(puntoFinal.X) && !float.IsNaN(puntoFinal.Y) &&
                        !float.IsInfinity(puntoFinal.X) && !float.IsInfinity(puntoFinal.Y))
                    {
                        puntosCurva.Add(puntoFinal);
                    }
                }
            }
            catch (Exception)
            {
                // En caso de error, simplemente no dibujamos más
                return;
            }

            if (puntosCurva.Count > 1)
            {
                using (Pen penCurva = new Pen(colorAnimacion, 3))
                {
                    g.DrawLines(penCurva, puntosCurva.ToArray());
                }
            }

            if (tMaxParam > 0 && puntosCurva.Count > 0)
            {
                PointF puntoActual = puntosCurva[puntosCurva.Count - 1];
                DibujarPunto(g, puntoActual, Color.Purple, 10);
            }
        }

        // Generar vector de nudos uniforme abierto (clamped)
        private List<float> GenerarVectorNudos()
        {
            List<float> nudos = new List<float>();
            int n = puntosControl.Count;
            int m = n + grado + 1; // Número total de nudos

            for (int i = 0; i < m; i++)
            {
                if (i <= grado)
                {
                    nudos.Add(0);
                }
                else if (i >= n)
                {
                    nudos.Add(1);
                }
                else
                {
                    float valor = (float)(i - grado) / (n - grado);
                    nudos.Add(valor);
                }
            }

            return nudos;
        }

        // Calcular punto en la curva B-Spline usando el algoritmo de Cox-de Boor
        private PointF CalcularPuntoBSpline(float t, List<float> nudos)
        {
            // Asegurar que t está en el rango válido
            float tMin = nudos[grado];
            float tMax = nudos[puntosControl.Count];
            
            if (t < tMin) t = tMin;
            if (t > tMax) t = tMax;

            float x = 0;
            float y = 0;

            for (int i = 0; i < puntosControl.Count; i++)
            {
                float base_valor = CalcularFuncionBase(i, grado, t, nudos);
                
                // Validar que el valor de la base es válido
                if (!float.IsNaN(base_valor) && !float.IsInfinity(base_valor))
                {
                    x += puntosControl[i].X * base_valor;
                    y += puntosControl[i].Y * base_valor;
                }
            }

            return new PointF(x, y);
        }

        // Función base B-Spline usando fórmula recursiva de Cox-de Boor
        private float CalcularFuncionBase(int i, int p, float t, List<float> nudos)
        {
            // Validar índices para evitar acceso fuera de rango
            if (i < 0 || i >= puntosControl.Count)
                return 0.0f;
                
            if (i + p + 1 >= nudos.Count)
                return 0.0f;

            // Caso base: grado 0
            if (p == 0)
            {
                if (i + 1 >= nudos.Count)
                    return 0.0f;
                    
                if (t >= nudos[i] && t < nudos[i + 1])
                    return 1.0f;
                else if (Math.Abs(t - nudos[i + 1]) < 1e-6 && i == puntosControl.Count - 1)
                    return 1.0f; // Caso especial para el último punto
                else
                    return 0.0f;
            }

            // Caso recursivo
            float denominador1 = nudos[i + p] - nudos[i];
            float denominador2 = nudos[i + p + 1] - nudos[i + 1];

            float termino1 = 0.0f;
            float termino2 = 0.0f;

            if (Math.Abs(denominador1) > 1e-6)
            {
                float base1 = CalcularFuncionBase(i, p - 1, t, nudos);
                if (!float.IsNaN(base1) && !float.IsInfinity(base1))
                {
                    termino1 = ((t - nudos[i]) / denominador1) * base1;
                }
            }

            if (Math.Abs(denominador2) > 1e-6 && i + 1 < puntosControl.Count)
            {
                float base2 = CalcularFuncionBase(i + 1, p - 1, t, nudos);
                if (!float.IsNaN(base2) && !float.IsInfinity(base2))
                {
                    termino2 = ((nudos[i + p + 1] - t) / denominador2) * base2;
                }
            }

            float resultado = termino1 + termino2;
            
            // Validar el resultado final
            if (float.IsNaN(resultado) || float.IsInfinity(resultado))
                return 0.0f;
                
            return resultado;
        }

        private void ActualizarInstrucciones()
        {
            int puntos = puntosControl.Count;
            int puntosMinimos = grado + 1;
            
            string nombreGrado = grado == 1 ? "lineal" : grado == 2 ? "cuadrática" : "cúbica";
            
            if (puntos == 0)
            {
                lblInstrucciones.Text = $"B-Spline {nombreGrado} (grado {grado}). Necesitas {puntosMinimos}+ puntos. Haz click para agregar. Arrastra para mover.";
            }
            else if (puntos < puntosMinimos)
            {
                lblInstrucciones.Text = $"Puntos: {puntos}/{puntosMinimos}+. B-Spline {nombreGrado}. Agrega {puntosMinimos - puntos} punto(s) más para dibujar.";
            }
            else
            {
                lblInstrucciones.Text = $"Puntos: {puntos}. B-Spline {nombreGrado} (grado {grado}) lista. Puedes agregar más puntos, arrastrarlos o dibujar.";
            }
        }
    }
}
