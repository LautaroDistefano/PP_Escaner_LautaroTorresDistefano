using System;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo)
            : base(mensaje)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public override string ToString()
        {
            string innerExceptionMessage = this.InnerException != null ? this.InnerException.Message : "No hay detalles adicionales.";
            return $"Excepción en el método {nombreMetodo} de la clase {nombreClase}.\n" +
                   "Algo salió mal, revisa los detalles.\n" +
                   $"Detalles: {innerExceptionMessage}";
        }

        public string NombreClase { get => nombreClase; }
        public string NombreMetodo { get => nombreMetodo; }
    }
}
