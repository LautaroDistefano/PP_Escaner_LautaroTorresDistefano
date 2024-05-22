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
        public static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            //Busca dentro de la lista de documentos de un escaner datos y los devuelve
            extension = 0;
            cantidad = 0;
            List<string> resumenList = new List<string>();

            foreach (Documento documento in e.ListaDocumentos)
            {
                if (documento.Estado == estado)
                {
                    cantidad++;
                    if (documento is Libro libro)
                    {
                        extension += libro.NumPaginas;
                        resumenList.Add($"Libro: {libro.Titulo}, Autor: {libro.Autor}, Páginas: {libro.NumPaginas}");
                    }
                    else if (documento is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                        resumenList.Add($"Mapa: {mapa.Titulo}, Autor: {mapa.Autor}, Superficie: {mapa.Superficie} cm2");
                    }
                }
            }

            resumen = string.Join("\n", resumenList);
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
