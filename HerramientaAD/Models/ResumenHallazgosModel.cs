using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HerramientaAD.Models
{
    public class ResumenHallazgosModel
    {

        DatosObjetosResumenHallazgos datosObjetosResumenHallazgos = new DatosObjetosResumenHallazgos();
        Aplicaciones aplicaciones = new Aplicaciones();
        const int TipoConsulta1 = 1;
        const int TipoConsulta2 = 2;
        const int TipoConsulta3 = 3;

        private List<ListasDesplegables> basesLista = new List<ListasDesplegables>();
        public List<ListasDesplegables> BasesLista
        {
            get => basesLista;
            set => basesLista = value;
        }

        private string baseID;
        public string BaseID
        {
            get { return baseID; }
            set { baseID = value; }
        }
        private List<ElementosHallazgosBD.ResultBD> hallazgosBD = new List<ElementosHallazgosBD.ResultBD>();
        public List<ElementosHallazgosBD.ResultBD>  HallazgosBD
        {
            get { return hallazgosBD; }
            set { hallazgosBD = value; }
        }

        private List<ElementosHallazgosBD.ResultBDpartdos> resultBDpartdos = new List<ElementosHallazgosBD.ResultBDpartdos>();
        public List<ElementosHallazgosBD.ResultBDpartdos> ResultBDpartdos
        {
            get { return resultBDpartdos; }
            set { resultBDpartdos = value; }
        }

        public ResumenHallazgosModel(int UsuarioID, int BDID, int AplicacionID)
        {
            String Nombreapp = ""; //MMOB - Se agregó variable
            if (datosObjetosResumenHallazgos.ObjetosResultBDConsulta(TipoConsulta1, UsuarioID, BDID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosResumenHallazgos.ResultadoXML.DocumentElement.SelectSingleNode("ResultadosBD");
                if (aplicaciones.AplicacionesConsulta(UsuarioID, 0, AplicacionID))
                {
                    XmlNode xmlApp = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                    foreach (XmlNode elementoapp in xmlApp.SelectNodes("row"))
                    {
                        Nombreapp = elementoapp.Attributes["Aplicacion"].Value.ToString();
                    }
                }
                int contador = 0;
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    contador = contador + 1;
                }
                if (contador == 6)
                {
                    hallazgosBD.Add(new ElementosHallazgosBD.ResultBD("PRIMARY KEY", "0%", Nombreapp));
                    hallazgosBD.Add(new ElementosHallazgosBD.ResultBD("FOREIGN KEY", "0%", Nombreapp));
                    hallazgosBD.Add(new ElementosHallazgosBD.ResultBD("INDEXES", "0%", Nombreapp));
                }
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    hallazgosBD.Add(new ElementosHallazgosBD.ResultBD(
                        elemento.Attributes["Nombre"].Value.ToString()
                        ,
                        elemento.Attributes["Valor"].Value.ToString()
                        , Nombreapp)); //MMOB - Se agregó nuevo atributo "Nombreapp"
                }
            }
            if (datosObjetosResumenHallazgos.ObjetosResultBDConsulta(TipoConsulta2, UsuarioID, BDID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosResumenHallazgos.ResultadoXML.DocumentElement.SelectSingleNode("ResultadosBD");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    ResultBDpartdos.Add(new ElementosHallazgosBD.ResultBDpartdos(
                        elemento.Attributes["resultado"].Value.ToString()
                        ,elemento.Attributes["Valor_Resultado"].Value.ToString())); //MMOB - Se agregó nuevo atributo "Nombreapp"
                }
            }
            if (datosObjetosResumenHallazgos.ObjetosResultBDConsulta(TipoConsulta3, UsuarioID, BDID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosResumenHallazgos.ResultadoXML.DocumentElement.SelectSingleNode("ResultadosBD");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    basesLista.Add(new ListasDesplegables(
                        int.Parse(elemento.Attributes["BaseDatosID"].Value.ToString()),
                        elemento.Attributes["BaseDatos"].Value.ToString())
                        );
                }
            }
        }
    }
}