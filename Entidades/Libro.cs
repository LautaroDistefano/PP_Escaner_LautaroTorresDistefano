using System;
using System.Text;

namespace Entidades
{
    public class Libro : Documento
    {
        //Propiedades
        private int numPaginas;
        //Constructor
        public Libro(int anio, string autor, string barcode, string numNormalizado, string titulo, int numPaginas)
            : base(anio, autor, barcode, numNormalizado, titulo)
        {
            this.numPaginas = numPaginas;
        }
        //Getters
        public string ISBN => NumNormalizado;
        public int NumPaginas => numPaginas;

        public override string ToString()
        {
            //Esta funcion genera un stringbuilder que sera el que se muestre por consola
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"Titulo: {this.Titulo}");
            texto.AppendLine($"Autor: {this.Autor}");
            texto.AppendLine($"Año: {this.Anio}");
            texto.AppendLine($"ISBN: {this.ISBN}");
            texto.AppendLine($"Cód. de barras: {this.Barcode}");
            texto.AppendLine($"Número de páginas: {this.NumPaginas}.");
            return texto.ToString();
        }

        public static bool operator ==(Libro libro1, Libro libro2)
        {
            //Verifica si dos libros son iguales
            if ((libro1.Barcode == libro2.Barcode) || (libro1.ISBN == libro2.ISBN) ||
                ((libro1.Titulo == libro2.Titulo) && (libro1.Autor == libro2.Autor)))
            {
                return true;
            }

            if (libro1 is null || libro2 is null)
            {
                return false;
            }
            return false;
        }

        public static bool operator !=(Libro libro1, Libro libro2)
        {
            //Verifica si dos libros son distintos
            if (libro1 != libro2)
            {
                return true;
            }
            return true;
        }
    }
}
