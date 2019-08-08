using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.com.Utilerias
{
    public class ElementosDeGrupo
    {
        public class Indicadores
        {
            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private int usados;
            public int Usados
            {
                get { return usados; }
                set { usados = value; }
            }

            private int noUsados;
            public int NoUsados
            {
                get { return noUsados; }
                set { noUsados = value; }
            }

            private string porcentaje;

            public string Porcentaje
            {
                get { return porcentaje; }
                set { porcentaje = value; }
            }

            //MMOB - Se agregó nuevo atributo "Nombreapp"
            private string nombreApp;
            public string NombreApp
            {
                get { return nombreApp; }
                set { nombreApp = value; }
            }

            public Indicadores(string Nombre, int Usados, int NoUsados, string Porcentaje, string NombreApp)
            {
                nombre = Nombre;
                usados = Usados;
                noUsados = NoUsados;
                porcentaje = Porcentaje;
                nombreApp = NombreApp; //MMOB - Se agregó nuevo atributo "Nombreapp"
            }
        }

        public class GraficaPie
        {
            private int porcentaje;
            public int Porcentaje
            {
                get { return porcentaje; }
                set { porcentaje = value; }
            }
            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public GraficaPie (int Porcentaje, string Nombre)
            {
                porcentaje = Porcentaje;
                nombre = Nombre;
            }
        }

        public class GraficaBarra
        {
            private int ejeY;

            public int EjeY
            {
                get { return ejeY; }
                set { ejeY = value; }
            }

            private string etiqueta;
            
            public string Etiqueta
            {
                get { return etiqueta; }
                set { etiqueta = value; }
            }

            public GraficaBarra (int EjeY, string Etiqueta)
            {
                ejeY = EjeY;
                etiqueta = Etiqueta;
            }
        }

        public class GraficaColumnas
        {
            private float ejeY;

            public float EjeY
            {
                get { return ejeY; }
                set { ejeY = value; }
            }

            private string etiqueta;

            public string Etiqueta
            {
                get { return etiqueta; }
                set { etiqueta = value; }
            }

            private string color;

            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            public GraficaColumnas(float EjeY, string Etiqueta, string Color)
            {
                ejeY = EjeY;
                etiqueta = Etiqueta;
                color = Color;
            }
        }

        public class GraficaPie3V
        {
            private string nombre;
            private int valor;
            private float porcentaje;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }


            public int Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            public float Porcentaje
            {
                get { return porcentaje; }
                set { porcentaje = value; }
            }

            public GraficaPie3V (string Nombre, int Valor, float Porcentaje)
            {
                nombre = Nombre;
                valor = Valor;
                porcentaje = Porcentaje;

            }

           



        }

    }
}