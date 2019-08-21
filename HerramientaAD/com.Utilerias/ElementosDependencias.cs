using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.com.Utilerias
{
    public class ElementosDependencias
    {
        public class EleDependencias
        {
            private int iRegistro;
            public int IRegistro
            {
                get { return iRegistro; }
                set { iRegistro = value; }
            }

            private string text;
            public string Text
            {
                get { return text; }
                set { text = value; }
            }

            public EleDependencias(int IRegistro, string Text)
            {
                iRegistro = IRegistro;
                text = Text;
            }
        }
            

        public class EleTablaUsos
        {
            private string id;
            public string Id
            {
                get { return id; }
                set { id = value; }
            }
            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string uso;
            public string Uso
            {
                get { return uso; }
                set { uso = value; }
            }

            private string tipo;
            public string Tipo
            {
                get { return tipo; }
                set { tipo = value; }
            }
            public EleTablaUsos(string Id, string Nombre, string Uso, string Tipo)
            {
                id = Id;
                nombre = Nombre;
                uso = Uso;
                tipo = Tipo;
            }
        }

        public class Cuadros
        {
            private int numero;
            public int Numero
            {
                get { return numero; }
                set { numero = value; }
            }

            private string tabla;
            public string Tabla
            {
                get { return tabla; }
                set { tabla = value; }
            }

            public Cuadros(int Numero, string Tabla)
            {
                numero = Numero;
                tabla = Tabla;
            }
        }

        public class Relaciones
        {
            private int desde;
            public int Desde
            {
                get { return desde; }
                set { desde = value; }
            }

            private int para;
            public int Para
            {
                get { return para; }
                set { para = value; }
            }

            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public Relaciones(int Desde, int Para, string Nombre)
            {
                desde = Desde;
                para = Para;
                nombre = Nombre;
            }
        }

    }
    
}