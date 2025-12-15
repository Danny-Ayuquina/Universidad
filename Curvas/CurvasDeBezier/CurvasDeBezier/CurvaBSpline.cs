using System;
using System.Collections.Generic;

namespace CurvasDeBezier
{
    /// <summary>
    /// Implementación del algoritmo de Curvas B-Spline desde cero.
    /// Las B-Splines son curvas suaves definidas por puntos de control y un vector de nudos.
    /// A diferencia de las curvas de Bézier, las B-Splines ofrecen control local:
    /// mover un punto de control solo afecta una porción de la curva.
    /// </summary>
    public class CurvaBSpline
    {
        #region Propiedades

        /// <summary>
        /// Lista de puntos de control que definen la curva B-Spline
        /// </summary>
        public List<Punto2D> PuntosControl { get; private set; }

        /// <summary>
        /// Grado de la curva B-Spline (típicamente 2 para cuadrática, 3 para cúbica)
        /// </summary>
        public int Grado { get; set; }

        /// <summary>
        /// Número de segmentos para discretizar la curva
        /// </summary>
        public int NumeroSegmentos { get; set; }

        /// <summary>
        /// Vector de nudos (knot vector) que controla la parametrización de la curva
        /// </summary>
        private List<double> VectorNudos { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializa la curva B-Spline
        /// </summary>
        /// <param name="grado">Grado de la curva (debe ser >= 1)</param>
        /// <param name="numeroSegmentos">Cantidad de segmentos para la discretización</param>
        public CurvaBSpline(int grado = 3, int numeroSegmentos = 100)
        {
            if (grado < 1)
                throw new ArgumentException("El grado debe ser al menos 1", nameof(grado));

            if (numeroSegmentos <= 0)
                throw new ArgumentException("El número de segmentos debe ser mayor que cero", nameof(numeroSegmentos));

            PuntosControl = new List<Punto2D>();
            Grado = grado;
            NumeroSegmentos = numeroSegmentos;
            VectorNudos = new List<double>();
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Agrega un punto de control a la curva
        /// </summary>
        /// <param name="punto">Punto de control a agregar</param>
        public void AgregarPuntoControl(Punto2D punto)
        {
            if (punto == null)
                throw new ArgumentNullException(nameof(punto), "El punto de control no puede ser nulo");

            PuntosControl.Add(punto.Clonar());
            ActualizarVectorNudos();
        }

        /// <summary>
        /// Limpia todos los puntos de control
        /// </summary>
        public void LimpiarPuntosControl()
        {
            PuntosControl.Clear();
            VectorNudos.Clear();
        }

        /// <summary>
        /// Calcula todos los puntos que conforman la curva B-Spline
        /// </summary>
        /// <returns>Lista de puntos que forman la curva</returns>
        /// <exception cref="InvalidOperationException">Si no hay suficientes puntos de control</exception>
        public List<Punto2D> CalcularCurva()
        {
            // Validación: Se necesitan al menos (grado + 1) puntos para generar la curva
            if (PuntosControl.Count < Grado + 1)
            {
                throw new InvalidOperationException(
                    $"Se necesitan al menos {Grado + 1} puntos de control para una B-Spline de grado {Grado}");
            }

            List<Punto2D> puntosCurva = new List<Punto2D>();

            // Determinar el rango válido del parámetro t
            double tMin = VectorNudos[Grado];
            double tMax = VectorNudos[PuntosControl.Count];

            // Calcular puntos a lo largo de la curva
            for (int i = 0; i <= NumeroSegmentos; i++)
            {
                double t = tMin + (tMax - tMin) * i / NumeroSegmentos;
                
                // Asegurar que t no exceda el límite superior
                if (t > tMax)
                    t = tMax;

                try
                {
                    Punto2D punto = CalcularPuntoEnCurva(t);
                    puntosCurva.Add(punto);
                }
                catch (Exception)
                {
                    // Si hay un error en un punto específico, continuar con el siguiente
                    continue;
                }
            }

            return puntosCurva;
        }

        /// <summary>
        /// Calcula un punto específico en la curva B-Spline para un valor t dado.
        /// Utiliza el algoritmo de Cox-de Boor.
        /// </summary>
        /// <param name="t">Parámetro de la curva</param>
        /// <returns>Punto en la curva correspondiente al parámetro t</returns>
        public Punto2D CalcularPuntoEnCurva(double t)
        {
            if (PuntosControl.Count == 0)
                throw new InvalidOperationException("No hay puntos de control definidos");

            double x = 0;
            double y = 0;

            // Calcular el punto usando las funciones base B-Spline
            for (int i = 0; i < PuntosControl.Count; i++)
            {
                double base_valor = CalcularFuncionBase(i, Grado, t);
                x += PuntosControl[i].X * base_valor;
                y += PuntosControl[i].Y * base_valor;
            }

            return new Punto2D(x, y);
        }

        /// <summary>
        /// Obtiene información sobre la curva actual
        /// </summary>
        /// <returns>Cadena con información de la curva</returns>
        public string ObtenerInformacion()
        {
            return $"Curva B-Spline - Grado: {Grado}, Puntos de control: {PuntosControl.Count}, Segmentos: {NumeroSegmentos}";
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Actualiza el vector de nudos basado en el número actual de puntos de control.
        /// Utiliza un vector de nudos uniforme abierto (clamped).
        /// </summary>
        private void ActualizarVectorNudos()
        {
            VectorNudos.Clear();

            int n = PuntosControl.Count;
            int m = n + Grado + 1; // Número total de nudos

            // Crear vector de nudos uniforme abierto
            for (int i = 0; i < m; i++)
            {
                if (i <= Grado)
                {
                    // Primeros (grado + 1) nudos son 0
                    VectorNudos.Add(0);
                }
                else if (i >= n)
                {
                    // Últimos (grado + 1) nudos son 1
                    VectorNudos.Add(1);
                }
                else
                {
                    // Nudos intermedios distribuidos uniformemente
                    double valor = (double)(i - Grado) / (n - Grado);
                    VectorNudos.Add(valor);
                }
            }
        }

        /// <summary>
        /// Calcula el valor de la función base B-Spline N(i,p)(t) usando el algoritmo de Cox-de Boor.
        /// Este es un algoritmo recursivo que define las funciones base B-Spline.
        /// </summary>
        /// <param name="i">Índice del punto de control</param>
        /// <param name="p">Grado de la función base</param>
        /// <param name="t">Parámetro de evaluación</param>
        /// <returns>Valor de la función base en el parámetro t</returns>
        private double CalcularFuncionBase(int i, int p, double t)
        {
            // Caso base: función de grado 0
            if (p == 0)
            {
                // N(i,0)(t) = 1 si t está en [knot[i], knot[i+1]), 0 en otro caso
                if (t >= VectorNudos[i] && t < VectorNudos[i + 1])
                    return 1.0;
                else if (Math.Abs(t - VectorNudos[i + 1]) < 1e-10 && i == PuntosControl.Count - 1)
                    return 1.0; // Caso especial para el último punto
                else
                    return 0.0;
            }

            // Caso recursivo: aplicar la fórmula de Cox-de Boor
            double denominador1 = VectorNudos[i + p] - VectorNudos[i];
            double denominador2 = VectorNudos[i + p + 1] - VectorNudos[i + 1];

            double termino1 = 0.0;
            double termino2 = 0.0;

            // Primer término: (t - knot[i]) / (knot[i+p] - knot[i]) * N(i,p-1)(t)
            if (Math.Abs(denominador1) > 1e-10)
            {
                termino1 = ((t - VectorNudos[i]) / denominador1) * CalcularFuncionBase(i, p - 1, t);
            }

            // Segundo término: (knot[i+p+1] - t) / (knot[i+p+1] - knot[i+1]) * N(i+1,p-1)(t)
            if (Math.Abs(denominador2) > 1e-10)
            {
                termino2 = ((VectorNudos[i + p + 1] - t) / denominador2) * CalcularFuncionBase(i + 1, p - 1, t);
            }

            return termino1 + termino2;
        }

        #endregion
    }
}
