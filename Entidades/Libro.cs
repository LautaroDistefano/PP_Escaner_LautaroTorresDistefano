using System;
using System.Text;

namespace Entidades
{
    public class Libro : Documento
    {
        //Propiedades
        private int numPaginas;
        //Constructor
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(anio, autor, codebar, numNormalizado, titulo)
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

        public static bool operator ==(Libro l1, Libro l2)
        {
            if (l1 is Libro && l2 is Libro)
            {
                return (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN ||
                    (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
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
            return false;
        }
    }
}
