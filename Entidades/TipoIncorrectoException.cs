using System;
using System.Text;

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
            StringBuilder texto = new StringBuilder();
            texto.AppendFormat("Excepción en el método {0} de la clase {1}.\n", this.nombreMetodo, this.nombreClase);
            texto.AppendLine("Algo salió mal, revisa los detalles.");
            texto.AppendFormat("Detalles: {0}", this.InnerException?.Message ?? "No hay detalles adicionales.");
            return texto.ToString();
        }

        public string NombreClase { get => nombreClase; }
        public string NombreMetodo { get => nombreMetodo; }
    }
}
