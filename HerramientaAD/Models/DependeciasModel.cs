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

        DatosDependencias datosDependencias = new DatosDependencias();

        private List<ElementosDependencias.Cuadros> cuadros = new List<ElementosDependencias.Cuadros>();
        public List<ElementosDependencias.Cuadros> Cuadros
        {
            get { return cuadros; }
            set { cuadros = value; }
        }
        private List<ListasDesplegables> areasLista = new List<ListasDesplegables>();
        DatosDependencias datosPed = new DatosDependencias();
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

        private List<ElementosDependencias.EleDependencias> ldep = new List<ElementosDependencias.EleDependencias>();
        public List<ElementosDependencias.EleDependencias> Ldep { get => ldep; set => ldep = value; }

        private List<ElementosDependencias.EleTablaUsos> lTabU = new List<ElementosDependencias.EleTablaUsos>();
        public List<ElementosDependencias.EleTablaUsos> LTabU { get => lTabU; set => lTabU = value; }      


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

            if (datosPed.TablaUsosConsulta(0,0))
            {
                detalleXML = datosPed.ResultadoXML;
            }
        }

        public DependeciasModel(int appid, int usuarioid, string nombre)
        {
            //Falta el SP
            //Aplicaciones objapp = new Aplicaciones();
            //objapp.ObtenObjetosDB3(usuarioid, appid, nombre);
            //XobjetosDB = objapp.AplicaionXML;
        }

        public DependeciasModel(int UsuarioID, int TipoID, int AplicacionID, int ProcesoID)
        {
            if (datosDependencias.IndicadoresConsulta(UsuarioID, TipoID, AplicacionID, ProcesoID))
            {
                XmlNode xmlNode = datosDependencias.ResultadoXML.DocumentElement.SelectSingleNode("Indicadores");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    ldep.Add(new ElementosDependencias.EleDependencias(
                        int.Parse(elemento.Attributes["Registros"].Value.ToString()),
                        elemento.Attributes["TipoObjeto"].Value.ToString()));
                }
            }
       
        }

        private XmlDocument detalleXML;
        public XmlDocument DetalleXML
        {
            get { return detalleXML; }
            set { detalleXML = value; }
        }

        /// <summary>
        /// Diagrama
        /// </summary>
        /// <param name="UsuarioID"></param>
        /// <param name="BaseDeDatosID"></param>
        /// <param name="tipo"></param>
        public DependeciasModel(int UsuarioID, int BaseDeDatosID, int tipo)
        {
            if (datosDependencias.DiagramaN1Consulta(UsuarioID, BaseDeDatosID,tipo))
            {
                XmlNode xmlNode = datosDependencias.ResultadoXML.DocumentElement.SelectSingleNode("ObjetosDB");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    cuadros.Add(new ElementosDependencias.Cuadros(
                        int.Parse(elemento.Attributes["ObjetoID"].Value.ToString()),
                        elemento.Attributes["Objeto"].Value.ToString())
                        );
                }
            }
        }

    }
}