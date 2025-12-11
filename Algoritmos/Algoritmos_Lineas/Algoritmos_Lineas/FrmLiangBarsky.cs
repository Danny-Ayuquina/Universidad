using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_Lineas
{
    public partial class FrmLiangBarsky : Form
    {
        private List<Tuple<PointF, PointF>> lineas;
        private RectangleF ventanaRecorte;
        private List<LineaRecortada> lineasRecortadas;
        private Bitmap bitmap;
        private Graphics g;
        private bool dibujandoLinea;
        private bool dibujandoVentana;
        private PointF puntoInicial;
        private int pasoVentana;

        public FrmLiangBarsky()
        {
            InitializeComponent();
            lineas = new List<Tuple<PointF, PointF>>();
            lineasRecortadas = new List<LineaRecortada>();
            dibujandoLinea = false;
            dibujandoVentana = false;
            pasoVentana = 0;
        }

        private void FrmLiangBarsky_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(picGrafico.Width, picGrafico.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            picGrafico.Image = bitmap;
        }

        private void btnDibujarLinea_Click(object sender, EventArgs e)
        {
            dibujandoLinea = true;
            dibujandoVentana = false;
            MessageBox.Show("Haga clic en el área de dibujo para definir el punto inicial de la línea.\nLuego haga clic nuevamente para el punto final.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDibujarVentana_Click(object sender, EventArgs e)
        {
            dibujandoLinea = false;
            dibujandoVentana = true;
            pasoVentana = 0;
            MessageBox.Show("Haga clic en el área de dibujo para definir la esquina superior izquierda de la ventana.\nLuego haga clic nuevamente para la esquina inferior derecha.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picGrafico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dibujandoLinea)
                {
                    if (puntoInicial == PointF.Empty)
                    {
                        puntoInicial = e.Location;
                        // Dibujar punto inicial
                        g.FillEllipse(Brushes.Blue, e.X - 3, e.Y - 3, 6, 6);
                        picGrafico.Invalidate();
                    }
                    else
                    {
                        PointF puntoFinal = e.Location;
                        lineas.Add(new Tuple<PointF, PointF>(puntoInicial, puntoFinal));
                        lstLineas.Items.Add($"Línea {lineas.Count}: ({puntoInicial.X:F0}, {puntoInicial.Y:F0}) → ({puntoFinal.X:F0}, {puntoFinal.Y:F0})");
                        
                        puntoInicial = PointF.Empty;
                        dibujandoLinea = false;
                        DibujarTodo();
                    }
                }
                else if (dibujandoVentana)
                {
                    if (pasoVentana == 0)
                    {
                        puntoInicial = e.Location;
                        pasoVentana = 1;
                        // Dibujar punto inicial
                        g.FillRectangle(Brushes.Black, e.X - 3, e.Y - 3, 6, 6);
                        picGrafico.Invalidate();
                    }
                    else
                    {
                        PointF puntoFinal = e.Location;
                        float x = Math.Min(puntoInicial.X, puntoFinal.X);
                        float y = Math.Min(puntoInicial.Y, puntoFinal.Y);
                        float width = Math.Abs(puntoFinal.X - puntoInicial.X);
                        float height = Math.Abs(puntoFinal.Y - puntoInicial.Y);
                        
                        ventanaRecorte = new RectangleF(x, y, width, height);
                        lstVentana.Items.Clear();
                        lstVentana.Items.Add($"Esquina superior izquierda: ({ventanaRecorte.Left:F2}, {ventanaRecorte.Top:F2})");
                        lstVentana.Items.Add($"Esquina inferior derecha: ({ventanaRecorte.Right:F2}, {ventanaRecorte.Bottom:F2})");
                        lstVentana.Items.Add($"Ancho: {ventanaRecorte.Width:F2}");
                        lstVentana.Items.Add($"Alto: {ventanaRecorte.Height:F2}");
                        
                        pasoVentana = 0;
                        puntoInicial = PointF.Empty;
                        dibujandoVentana = false;
                        DibujarTodo();
                    }
                }
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (lineas.Count == 0)
            {
                MessageBox.Show("Debe dibujar al menos una línea.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ventanaRecorte.IsEmpty || ventanaRecorte.Width == 0 || ventanaRecorte.Height == 0)
            {
                MessageBox.Show("Debe definir una ventana de recorte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LiangBarsky liangBarsky = new LiangBarsky(ventanaRecorte);
            lineasRecortadas.Clear();
            lstRecortado.Items.Clear();

            int lineaNumero = 1;
            foreach (var linea in lineas)
            {
                LineaRecortada resultado = liangBarsky.RecortarLinea(linea.Item1, linea.Item2);
                lineasRecortadas.Add(resultado);

                lstRecortado.Items.Add($"═══ Línea {lineaNumero} ═══");
                lstRecortado.Items.Add($"Original: ({linea.Item1.X:F0}, {linea.Item1.Y:F0}) → ({linea.Item2.X:F0}, {linea.Item2.Y:F0})");
                
                if (resultado.Aceptada)
                {
                    lstRecortado.Items.Add($"Estado: ACEPTADA");
                    lstRecortado.Items.Add($"Recortada: ({resultado.P1Recortado.X:F2}, {resultado.P1Recortado.Y:F2}) → ({resultado.P2Recortado.X:F2}, {resultado.P2Recortado.Y:F2})");
                }
                else
                {
                    lstRecortado.Items.Add($"Estado: RECHAZADA");
                }

                lstRecortado.Items.Add("Pasos del algoritmo:");
                foreach (string paso in resultado.Pasos)
                {
                    lstRecortado.Items.Add($"  {paso}");
                }
                lstRecortado.Items.Add("");
                
                lineaNumero++;
            }

            DibujarTodo();
        }

        private void DibujarTodo()
        {
            g.Clear(Color.White);

            // Dibujar líneas originales en azul claro
            foreach (var linea in lineas)
            {
                using (Pen pen = new Pen(Color.LightBlue, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(pen, linea.Item1, linea.Item2);
                }
                // Dibujar puntos extremos
                g.FillEllipse(Brushes.Blue, linea.Item1.X - 3, linea.Item1.Y - 3, 6, 6);
                g.FillEllipse(Brushes.Blue, linea.Item2.X - 3, linea.Item2.Y - 3, 6, 6);
            }

            // Dibujar ventana de recorte en negro
            if (!ventanaRecorte.IsEmpty && ventanaRecorte.Width > 0 && ventanaRecorte.Height > 0)
            {
                using (Pen pen = new Pen(Color.Black, 3))
                {
                    g.DrawRectangle(pen, ventanaRecorte.X, ventanaRecorte.Y, ventanaRecorte.Width, ventanaRecorte.Height);
                }
                // Dibujar esquinas
                g.FillRectangle(Brushes.Black, ventanaRecorte.Left - 4, ventanaRecorte.Top - 4, 8, 8);
                g.FillRectangle(Brushes.Black, ventanaRecorte.Right - 4, ventanaRecorte.Top - 4, 8, 8);
                g.FillRectangle(Brushes.Black, ventanaRecorte.Left - 4, ventanaRecorte.Bottom - 4, 8, 8);
                g.FillRectangle(Brushes.Black, ventanaRecorte.Right - 4, ventanaRecorte.Bottom - 4, 8, 8);
            }

            // Dibujar líneas recortadas en rojo (solo las aceptadas)
            foreach (var resultado in lineasRecortadas)
            {
                if (resultado.Aceptada)
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        g.DrawLine(pen, resultado.P1Recortado, resultado.P2Recortado);
                    }
                    // Dibujar puntos extremos de la línea recortada
                    g.FillEllipse(Brushes.Red, resultado.P1Recortado.X - 4, resultado.P1Recortado.Y - 4, 8, 8);
                    g.FillEllipse(Brushes.Red, resultado.P2Recortado.X - 4, resultado.P2Recortado.Y - 4, 8, 8);
                }
            }

            picGrafico.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lineas.Clear();
            lineasRecortadas.Clear();
            ventanaRecorte = RectangleF.Empty;
            lstLineas.Items.Clear();
            lstVentana.Items.Clear();
            lstRecortado.Items.Clear();
            dibujandoLinea = false;
            dibujandoVentana = false;
            pasoVentana = 0;
            puntoInicial = PointF.Empty;
            g.Clear(Color.White);
            picGrafico.Invalidate();
        }
    }
}
