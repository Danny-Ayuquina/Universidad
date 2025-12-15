using System;

namespace CurvasDeBezier
{
    /// <summary>
    /// Representa un punto en el espacio bidimensional.
    /// Clase fundamental para el cálculo de curvas.
    /// </summary>
    public class Punto2D
    {
        #region Propiedades

        /// <summary>
        /// Coordenada X del punto
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordenada Y del punto
        /// </summary>
        public double Y { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto, inicializa el punto en el origen (0,0)
        /// </summary>
        public Punto2D()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Constructor con coordenadas específicas
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        public Punto2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Calcula la distancia euclidiana entre este punto y otro punto
        /// </summary>
        /// <param name="otro">El otro punto</param>
        /// <returns>La distancia entre los puntos</returns>
        public double DistanciaA(Punto2D otro)
        {
            if (otro == null)
                throw new ArgumentNullException(nameof(otro), "El punto no puede ser nulo");

            double dx = X - otro.X;
            double dy = Y - otro.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Crea una copia del punto actual
        /// </summary>
        /// <returns>Nueva instancia con las mismas coordenadas</returns>
        public Punto2D Clonar()
        {
            return new Punto2D(X, Y);
        }

        /// <summary>
        /// Representación en cadena del punto
        /// </summary>
        /// <returns>Cadena con formato (X, Y)</returns>
        public override string ToString()
        {
            return $"({X:F2}, {Y:F2})";
        }

        /// <summary>
        /// Compara dos puntos para verificar igualdad
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Punto2D otro)
            {
                return Math.Abs(X - otro.X) < 0.0001 && Math.Abs(Y - otro.Y) < 0.0001;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        #endregion
    }
}
