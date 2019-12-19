using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HerramientaAD.Models
{
    public class MetricasModel
    {
        DatosObjetosMetricas datosObjetosMetricas = new DatosObjetosMetricas();
        Aplicaciones aplicaciones = new Aplicaciones();
        private List<ElementosMetricas.ResultMetricas> resulMetricas = new List<ElementosMetricas.ResultMetricas>();
        public List<ElementosMetricas.ResultMetricas> ResulMetricas
        {
            get { return resulMetricas; }
            set { resulMetricas = value; }
        }

        private XmlDocument detalleXML;
        public XmlDocument DetalleXML
        {
            get { return detalleXML; }
            set { detalleXML = value; }
        }
        public MetricasModel(int UsuarioID)
        {

            if (datosObjetosMetricas.PruebaMetricas(UsuarioID))
            {
                XmlNode xmlNode = datosObjetosMetricas.ResultadoXML.DocumentElement.SelectSingleNode("ResultadosMetricas");

                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    
                    resulMetricas.Add(new ElementosMetricas.ResultMetricas(
                     elemento.Attributes["NombreApp"].Value.ToString(),
                     elemento.Attributes["NombreAppCompleto"].Value.ToString(),
                     int.Parse(elemento.Attributes["Tamaño"].Value.ToString()),
                     int.Parse(elemento.Attributes["Obsolescencia"].Value.ToString()),
                     int.Parse(elemento.Attributes["Mantenibilidad"].Value.ToString()),
                     int.Parse(elemento.Attributes["Seguridad"].Value.ToString()),
                     int.Parse(elemento.Attributes["Confiabilidad"].Value.ToString()),
                     int.Parse(elemento.Attributes["ObjBD"].Value.ToString()),
                     int.Parse(elemento.Attributes["Ser_Inter"].Value.ToString())));

                }
                detalleXML = datosObjetosMetricas.ResultadoXML;
            }

        }
       
    }
}
