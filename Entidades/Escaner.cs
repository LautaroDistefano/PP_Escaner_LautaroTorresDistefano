using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    {
        //Propiedades
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        //Enumerados
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }

        //Constructor
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            if (this.tipo == TipoDoc.libro){this.locacion = Departamento.procesosTecnicos;}
            else if (this.tipo == TipoDoc.mapa){this.locacion = Departamento.mapoteca;}
            else{this.locacion = Departamento.nulo;}
            this.listaDocumentos = new List<Documento>();
        }

        //Getters
        public List<Documento> ListaDocumentos { get { return this.listaDocumentos; } }
        public Departamento Locacion { get { return this.locacion; } }
        public string Marca { get { return this.marca; } }
        public TipoDoc Tipo { get { return this.tipo; } }

        //Sobrecargas | == | != | + | - |

        public static bool operator ==(Escaner escaner, Documento documento)
        {
            foreach (Documento doc in escaner.listaDocumentos)
            {
                if (doc == documento) return true;
            }
            return false;
        }

        public static bool operator !=(Escaner escaner, Documento documento)
        {
            if (escaner.listaDocumentos.Contains(documento))
            { 
                return !(escaner == documento);
            }
            return false;
        }

        public static bool operator +(Escaner escaner, Documento documento)
        {
            // Validar el tipo de documento antes de agregarlo
            if ((escaner.tipo == TipoDoc.libro && documento is Libro) ||
                (escaner.tipo == TipoDoc.mapa && documento is Mapa))
            {
                if (!escaner.listaDocumentos.Contains(documento) && documento.Estado == Paso.Inicio)
                {
                    escaner.CambiarEstadoDocumento(documento);
                    escaner.listaDocumentos.Add(documento);
                    return true;
                }
            }
            else
            {
                //En caso de que no se pueda agregar el documento, avisamos
                Console.WriteLine("El documento no se puede agregar");
            }
            return false;
        }

        public static bool operator -(Escaner escaner, Documento documento)
        {
            //Sobrecarga del operador - | remueve documento de la lista de documentos de un escaner
            if (escaner.listaDocumentos.Contains(documento)) 
            {
                escaner.listaDocumentos.Remove(documento);
                return true;
            }
            return false;
        }

        public bool CambiarEstadoDocumento(Documento documento)
        {
            /// Si la lista de documentos contiene x documento, avanza el estado del mismo
            if (listaDocumentos.Contains(documento)) 
            {
                documento.AvanzarEstado();
                return true;
            }
            return false;
        }
    }
}