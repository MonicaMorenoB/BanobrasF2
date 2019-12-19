using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.com.Utilerias
{
    public class ElementosMetricas
    {
        //  Confiabilidad="1" ObjBD="10" Ser_Inter="2" />
        public class ResultMetricas
        {
            private string nombreApp;
            public string NombreApp
            {
                get { return nombreApp; }
                set { nombreApp = value; }
            }

            private string nombreAppCompleto;

            public string NombreAppCompleto
            {
                get { return nombreAppCompleto; }
                set { nombreAppCompleto = value; }
            }
            private int tamanio;
            public int Tamanio
            {
                get { return tamanio; }
                set { tamanio = value; }
            }
            private int obsolescencia;
            public int Obsolescencia
            {
                get { return obsolescencia; }
                set { obsolescencia = value; }
            }

            private int mantenibilidad;
            public int Mantenibilidad
            {
                get { return mantenibilidad; }
                set { mantenibilidad = value; }
            }

            private int seguridad;
            public int Seguridad
            {
                get { return seguridad; }
                set { seguridad = value; }
            }

            private int confiabilidad;
            public int Confiabilidad
            {
                get { return confiabilidad; }
                set { confiabilidad = value; }
            }

            private int objBD;
            public int ObjBD
            {
                get { return objBD; }
                set { objBD = value; }
            }

            private int ser_Inter;
            public int Ser_Inter
            {
                get { return ser_Inter; }
                set { ser_Inter = value; }
            }

            public ResultMetricas(string NombreApp, string NombreAppCompleto, int Tamanio, int Obsolescencia, int Mantenibilidad, int Seguridad, int Confiabilidad, int ObjBD, int Ser_Inter)
            {
                nombreApp = NombreApp;
                nombreAppCompleto = NombreAppCompleto;
                tamanio = Tamanio;
                obsolescencia = Obsolescencia;
                mantenibilidad = Mantenibilidad;
                seguridad = Seguridad;
                confiabilidad = Confiabilidad;
                objBD = ObjBD;
                ser_Inter = Ser_Inter;

            }
        }
    }
}