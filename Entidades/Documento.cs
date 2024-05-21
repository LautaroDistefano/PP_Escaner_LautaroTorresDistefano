﻿using System;
using System.Text;

namespace Entidades
{
    public abstract class Documento
    {
        //Propiedades
        private int anio;
        private string autor;
        private string barcode;
        private string numNormalizado;
        private string titulo;
        private Paso estado;

        //Constructor
        public Documento(int anio, string autor, string barcode, string numNormalizado, string titulo)
        {
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
            this.estado = Paso.Inicio;
        }

        public bool AvanzarEstado()
        {
            //Esta funcion se encarga de avanzar al siguiente estado de un documento
            if (this.estado == Paso.Terminado)
            {
                return false;
            }
            this.estado++;
            return true;
        }

        public override string ToString()
        {
            //Esta funcion genera un stringbuilder que sera el que se muestre por consola
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"Titulo: {this.titulo}");
            texto.AppendLine($"Autor: {this.autor}");
            texto.AppendLine($"Año: {this.anio}");
            texto.AppendLine($"Cód. de barras: {this.barcode}");
            return texto.ToString();
        }

        //Getters
        public int Anio { get { return this.anio; } }
        public string Autor { get { return this.autor; } }
        public string Barcode { get { return this.barcode; } }
        protected string NumNormalizado { get { return this.numNormalizado; } }
        public string Titulo { get { return this.titulo; } }
        public Paso Estado { get { return this.estado; } }

        //Pasos de los documentos
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
    }
}
