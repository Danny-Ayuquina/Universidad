using System;
using System.Collections.Generic;

namespace CurvasDeBezier
{
    /// <summary>
    /// Implementación del algoritmo de Curvas de Bézier desde cero.
    /// Las curvas de Bézier son curvas paramétricas definidas por puntos de control.
    /// Utiliza el algoritmo de De Casteljau para calcular puntos sobre la curva.
    /// </summary>
    public class CurvaBezier
    {
        #region Propiedades

        /// <summary>
        /// Lista de puntos de control que definen la curva de Bézier
        /// </summary>
        public List<Punto2D> PuntosControl { get; private set; }

        /// <summary>
        /// Número de segmentos para discretizar la curva (mayor = más suave)
        /// </summary>
        public int NumeroSegmentos { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializa la curva de Bézier
        /// </summary>
        /// <param name="numeroSegmentos">Cantidad de segmentos para la discretización</param>
        public CurvaBezier(int numeroSegmentos = 100)
        {
            if (numeroSegmentos <= 0)
                throw new ArgumentException("El número de segmentos debe ser mayor que cero", nameof(numeroSegmentos));

            PuntosControl = new List<Punto2D>();
            NumeroSegmentos = numeroSegmentos;
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
        }

        /// <summary>
        /// Limpia todos los puntos de control
        /// </summary>
        public void LimpiarPuntosControl()
        {
            PuntosControl.Clear();
        }

        /// <summary>
        /// Calcula todos los puntos que conforman la curva de Bézier
        /// </summary>
        /// <returns>Lista de puntos que forman la curva</returns>
        /// <exception cref="InvalidOperationException">Si no hay suficientes puntos de control</exception>
        public List<Punto2D> CalcularCurva()
        {
            // Validación: Se necesitan al menos 2 puntos para trazar una curva
            if (PuntosControl.Count < 2)
            {
                throw new InvalidOperationException("Se necesitan al menos 2 puntos de control para generar una curva de Bézier");
            }

            List<Punto2D> puntosCurva = new List<Punto2D>();

            // Calcular puntos a lo largo de la curva usando el parámetro t
            for (int i = 0; i <= NumeroSegmentos; i++)
            {
                double t = (double)i / NumeroSegmentos;
                Punto2D punto = CalcularPuntoEnCurva(t);
                puntosCurva.Add(punto);
            }

            return puntosCurva;
        }

        /// <summary>
        /// Calcula un punto específico en la curva de Bézier para un valor t dado.
        /// Implementa el algoritmo de De Casteljau recursivo.
        /// </summary>
        /// <param name="t">Parámetro de la curva (debe estar entre 0 y 1)</param>
        /// <returns>Punto en la curva correspondiente al parámetro t</returns>
        /// <exception cref="ArgumentException">Si t está fuera del rango [0, 1]</exception>
        public Punto2D CalcularPuntoEnCurva(double t)
        {
            // Validación del parámetro t
            if (t < 0 || t > 1)
                throw new ArgumentException("El parámetro t debe estar entre 0 y 1", nameof(t));

            if (PuntosControl.Count == 0)
                throw new InvalidOperationException("No hay puntos de control definidos");

            // Implementación del algoritmo de De Casteljau
            return AlgoritmoDeCasteljau(PuntosControl, t);
        }

        /// <summary>
        /// Obtiene información sobre la curva actual
        /// </summary>
        /// <returns>Cadena con información de la curva</returns>
        public string ObtenerInformacion()
        {
            return $"Curva de Bézier - Grado: {PuntosControl.Count - 1}, Puntos de control: {PuntosControl.Count}, Segmentos: {NumeroSegmentos}";
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Implementación recursiva del algoritmo de De Casteljau.
        /// Este algoritmo calcula un punto en la curva de Bézier mediante
        /// interpolación lineal recursiva entre los puntos de control.
        /// </summary>
        /// <param name="puntos">Lista de puntos de control</param>
        /// <param name="t">Parámetro de interpolación</param>
        /// <returns>Punto interpolado</returns>
        private Punto2D AlgoritmoDeCasteljau(List<Punto2D> puntos, double t)
        {
            // Caso base: si solo hay un punto, ese es el resultado
            if (puntos.Count == 1)
                return puntos[0].Clonar();

            // Lista para almacenar los puntos interpolados
            List<Punto2D> puntosInterpolados = new List<Punto2D>();

            // Interpolar linealmente entre cada par de puntos consecutivos
            for (int i = 0; i < puntos.Count - 1; i++)
            {
                // Interpolación lineal: P(t) = (1-t)*P0 + t*P1
                double x = (1 - t) * puntos[i].X + t * puntos[i + 1].X;
                double y = (1 - t) * puntos[i].Y + t * puntos[i + 1].Y;
                puntosInterpolados.Add(new Punto2D(x, y));
            }

            // Llamada recursiva con los puntos interpolados
            return AlgoritmoDeCasteljau(puntosInterpolados, t);
        }

        #endregion
    }
}
