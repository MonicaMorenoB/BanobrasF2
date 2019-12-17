using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.com.Utilerias
{
    public class ElementosHallazgosBD
    {
        public class ResultBD
        {
            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
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

            public ResultBD(string Nombre,  string Porcentaje, string NombreApp)
            {
                nombre = Nombre;
                porcentaje = Porcentaje;
                nombreApp = NombreApp; //MMOB - Se agregó nuevo atributo "Nombreapp"
            }
        }


        public class ResultBDpartdos
        {
            private string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string valor_Resultado;

            public string Valor_Resultado
            {
                get { return valor_Resultado; }
                set { valor_Resultado = value; }
            }

          
            public ResultBDpartdos(string Nombre, string Valor_Resultado)
            {
                nombre = Nombre;
                valor_Resultado = Valor_Resultado;
            }
        }
    }
}