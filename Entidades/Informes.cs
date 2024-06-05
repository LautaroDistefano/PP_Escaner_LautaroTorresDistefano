using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            List<Documento> listaDistribuidos = new List<Documento>();

            // Extension: el total de paginas en el caso de los libros y el total de cm2 en el caso de los
            // mapas.
            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (doc is Libro)
                    {
                        Libro libro = (Libro)doc;
                        extension += libro.NumPaginas;
                    }
                    else
                    {
                        if (doc is Mapa mapa)
                        {
                            //Mapa mapa = (Mapa)doc;
                            extension += mapa.Superficie;
                        }
                    }
                    cantidad++;
                    listaDistribuidos.Add(doc);
                    resumen += doc.ToString();
                }
            }

            if (listaDistribuidos.Count == 0)
            {
                resumen = "";
            }

        }

        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Devuelve datos en paso "Distribuidos"
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Devuelve datos en paso "EnEscaner"
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Devuelve datos en paso "EnRevision"
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            ////Devuelve datos en paso "Terminados"
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
