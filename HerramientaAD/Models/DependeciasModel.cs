using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HerramientaAD.Models
{
    public class DependeciasModel
    {
        Areas areas = new Areas();

        private List<ListasDesplegables> areasLista = new List<ListasDesplegables>();
        DatosDetalleTecnico datosDetalle = new DatosDetalleTecnico();
        public List<ListasDesplegables> AreasLista
        {
            get { return areasLista; }
            set { areasLista = value; }
        }

        private List<ListasDesplegables> aplicacionesLista = new List<ListasDesplegables>();
        public List<ListasDesplegables> AplicacionesLista
        {
            get { return aplicacionesLista; }
            set { aplicacionesLista = value; }
        }
        private int areaID;
        public int AreaID
        {
            get { return areaID; }
            set { areaID = value; }
        }

        private int aplicacionID;
        public int AplicacionID
        {
            get { return aplicacionID; }
            set { aplicacionID = value; }
        }

        private XmlDocument detalleXML;
        public XmlDocument DetalleXML
        {
            get { return detalleXML; }
            set { detalleXML = value; }
        }

        public DependeciasModel()
        {

        }
        public DependeciasModel(int UsuarioID)
        {
            if (areas.AreasConsulta(UsuarioID))
            {
                XmlNode xmlNode = areas.ResultadoXML.DocumentElement.SelectSingleNode("Areas");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    areasLista.Add(new ListasDesplegables(
                        int.Parse(elemento.Attributes["AreaID"].Value.ToString()),
                        elemento.Attributes["Descripcion"].Value.ToString()));
                }
            }

            if (datosDetalle.ConsultaDetalleFiltro("BD", 0, string.Empty, string.Empty, string.Empty, string.Empty))
            {
                detalleXML = datosDetalle.ResultadoXML;
            }
        }

        public DependeciasModel(int appid, int usuarioid, string nombre)
        {
            //Falta el SP
            //Aplicaciones objapp = new Aplicaciones();
            //objapp.ObtenObjetosDB3(usuarioid, appid, nombre);
            //XobjetosDB = objapp.AplicaionXML;
        }

    }
}