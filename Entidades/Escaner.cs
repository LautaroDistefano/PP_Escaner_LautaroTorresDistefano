using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        // Enumeración para el departamento
        public enum Departamento
        {nulo, mapoteca, procesosTecnicos}

        // Enumeración para el tipo de documento
        public enum TipoDoc
        {libro, mapa}

        // Constructor de la clase Escaner
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            listaDocumentos = new List<Documento>();

            // Asignar la locacion según el tipo de documento
            if (this.tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        // Propiedades de solo lectura para acceder a los atributos privados
        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        // Método para cambiar el estado de un documento en la lista
        public bool CambiarEstadoDocumento(Documento d)
        {
            foreach (Documento doc in listaDocumentos)
            {
                // Si el documento es un libro y es igual al documento en la lista
                if (d is Libro libro && ((Libro)d == (Libro)doc))
                {
                    return doc.AvanzarEstado(); // Avanzar el estado del documento
                }
                // Si el documento es un mapa y es igual al documento en la lista
                else if (d is Mapa mapa && doc is Mapa mapaExistente && mapa == mapaExistente)
                {
                    return doc.AvanzarEstado(); 
                }
            }

            return false; 
        }

        // Sobrecarga del operador '+' para agregar un documento a la lista
        public static bool operator +(Escaner e, Documento d)
        {
            try
            {
                if (e != d && d.Estado == Documento.Paso.Inicio && e.locacion == Departamento.procesosTecnicos && d is Libro)
                {
                    d.AvanzarEstado();
                    e.listaDocumentos.Add(d);
                    return true;
                }
                else
                {
                    if (e != d && d.Estado == Documento.Paso.Inicio && e.locacion == Departamento.mapoteca && d is Mapa)
                    {
                        d.AvanzarEstado();
                        e.listaDocumentos.Add(d);
                        return true;
                    }
                }
                return false;
            }
            catch (TipoIncorrectoException ex)
            {
                throw new TipoIncorrectoException("El documento no se pudo añadir a la lista", nameof(Escaner), "+", ex);
            }
        }

        // Sobrecarga del operador '==' para verificar si un documento está en la lista
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento doc in e.listaDocumentos)
            {
                if (d is Libro && doc is Libro && ((Libro)d) == ((Libro)doc))
                {
                    return true;
                }
                else if (d is Mapa && doc is Mapa && ((Mapa)d) == ((Mapa)doc))
                {
                    return true;
                }
            }
            throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", nameof(Escaner), "==");
        }


        // Sobrecarga del operador '!=' para verificar si un documento no está en la lista
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d); // Negación del operador '=='
        }
    }
}
