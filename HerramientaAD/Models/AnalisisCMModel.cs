using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;

namespace HerramientaAD.Models
{
    public class AnalisisCMModel
    {
        DatosDiagramaCM datosDiagramaCM = new DatosDiagramaCM();
        Aplicaciones aplicaciones = new Aplicaciones();

        private List<ElementosDiagramaCM.Cuadros> diagramaCM = new List<ElementosDiagramaCM.Cuadros>();
        private XmlDocument resultadoXML;

        private string aplicacion;
        public string Aplicacion
        {
            get { return aplicacion; }
            set { aplicacion = value; }
        }

        public List<ElementosDiagramaCM.Cuadros> DiagramaCM
        {
            get { return diagramaCM; }
            set { diagramaCM = value; }
        }

        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
            set { resultadoXML = value; }
        }

        public AnalisisCMModel(int UsuarioID, int AplicacionID)
        {

            string Nombreapp = "";
            if (datosDiagramaCM.DiagramaCMConsulta(UsuarioID, AplicacionID))
            {
                XmlNode xmlNode = datosDiagramaCM.ResultadoXML.DocumentElement.SelectSingleNode("DiagramaCM");

                if (aplicaciones.AplicacionesConsulta(UsuarioID, 0, AplicacionID))
                {
                    XmlNode xmlApp = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                    foreach (XmlNode elementoapp in xmlApp.SelectNodes("row"))
                    {
                        Nombreapp = elementoapp.Attributes["Aplicacion"].Value.ToString();
                        Aplicacion = elementoapp.Attributes["Aplicacion"].Value.ToString();
                    }
                }

                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    diagramaCM.Add(new ElementosDiagramaCM.Cuadros(
                        elemento.Attributes["llave"].Value.ToString(),
                        elemento.Attributes["padre"].Value.ToString(),
                        elemento.Attributes["nombre"].Value.ToString(),
                        elemento.Attributes["tipo"].Value.ToString(),
                        elemento.Attributes["color"].Value.ToString(),
                        elemento.Attributes["descripcion"].Value.ToString(),
                         Nombreapp
                        ));
                }
            }
            else
            {
                if (aplicaciones.AplicacionesConsulta(UsuarioID, 0, AplicacionID))
                {
                    XmlNode xmlApp = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                    foreach (XmlNode elementoapp in xmlApp.SelectNodes("row"))
                    {
                        Nombreapp = elementoapp.Attributes["Aplicacion"].Value.ToString();
                        Aplicacion = elementoapp.Attributes["Aplicacion"].Value.ToString();
                    }
                }
                diagramaCM.Add(new ElementosDiagramaCM.Cuadros(
                      "",
                      "",
                      "",
                      "",
                      "",
                      "",
                       Nombreapp
                      ));

            }
        }
    }
}