using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        // Propiedades
        int alto;
        int ancho;
        int superficie;
        
        //Constructor
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar,
            int ancho, int alto) : base (anio, autor, codebar, numNormalizado, titulo)
        {
            this.alto = alto;
            this.ancho = ancho;
            this.superficie = this.alto * this.ancho;
        }
        //Getters
        public int Alto => alto;
        public int Ancho => ancho;
        public int Superficie => superficie;

        public static bool operator ==(Mapa mapa1, Mapa mapa2)
        {
            //Verifica si dos libros son iguales => true | Si son != => false
            if ((mapa1.Barcode == mapa2.Barcode) || (mapa1.Titulo == mapa2.Titulo && mapa1.Autor == mapa2.Autor 
                && mapa1.Anio == mapa2.Anio && mapa1.Superficie == mapa2.Superficie))
            {
                return true;
            }

            if (mapa1 is null || mapa2 is null)
            {
                return false;
            }
            return false;
        }

        public static bool operator !=(Mapa mapa1, Mapa mapa2)
        {
            //Verifica si dos libros son distintos
            if (mapa1 != mapa2) 
            {
                return true;
            }
            return true;
        }

        public override string ToString()
        {
            //Esta funcion genera un stringbuilder que sera el que se muestre por consola
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.superficie} cm2");
            return texto.ToString();
        }
    }
}
