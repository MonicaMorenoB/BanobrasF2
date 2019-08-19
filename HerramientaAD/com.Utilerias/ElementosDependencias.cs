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
        
        }
    
}