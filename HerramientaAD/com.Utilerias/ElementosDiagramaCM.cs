using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.com.Utilerias
{
    public class ElementosDiagramaCM
    {
        public class Cuadros
        {
            private string llave;
            public string Llave
            {
                get { return llave; }
                set { llave = value; }
            }

            private string padre;
            public string Padre
            {
                get { return padre; }
                set { padre = value; }
            }

            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string tipo;
            public string Tipo
            {
                get { return tipo; }
                set { Tipo = value; }
            }

            private string color;
            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            private string descripcion;
            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            private string nombreApp;
            public string NombreApp
            {
                get { return nombreApp; }
                set { nombreApp = value; }
            }

            public Cuadros(string Llave, string Padre, string Nombre, string Tipo, string Color, string Descripcion, string NombreApp)
            {
                llave = Llave;
                padre = Padre;
                nombre = Nombre;
                tipo = Tipo;
                color = Color;
                descripcion = Descripcion;
                nombreApp = NombreApp;
            }
        }
    }
}