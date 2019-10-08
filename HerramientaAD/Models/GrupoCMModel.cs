using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;

namespace HerramientaAD.Models
{
    public class GrupoCMModel
    {
        DatosObjetosCM datosObjetosCM = new DatosObjetosCM();
        Aplicaciones aplicaciones = new Aplicaciones(); //MMOB- NUEVO

        const int TipoConsulta1 = 1;
        const int TipoConsulta2 = 2;
        const int TipoConsulta3 = 3;
        const int TipoConsulta4 = 4;

        private List<ElementosDeGrupo.Indicadores> indicadores = new List<ElementosDeGrupo.Indicadores>();
        private List<ElementosDeGrupo.GraficaPie> archivosPie = new List<ElementosDeGrupo.GraficaPie>();
        private List<ElementosDeGrupo.GraficaColumnas> archivosColumnas = new List<ElementosDeGrupo.GraficaColumnas>();
        private List<ElementosDeGrupo.GraficaBarra> masUsados = new List<ElementosDeGrupo.GraficaBarra>();
        private List<ElementosDeGrupo.GraficaPie> componentesPie = new List<ElementosDeGrupo.GraficaPie>();
        private List<ElementosDeGrupo.GraficaColumnas> componentesColumnas = new List<ElementosDeGrupo.GraficaColumnas>();
        private XmlDocument resultadoXML;

        public List<ElementosDeGrupo.Indicadores> Indicadores
        {
            get { return indicadores; }
            set { indicadores = value; }
        }

        public List<ElementosDeGrupo.GraficaPie> ArchivosPie
        {
            get { return archivosPie; }
            set { archivosPie = value; }
        }

        public List<ElementosDeGrupo.GraficaColumnas> ArchivosColumnas
        {
            get { return archivosColumnas; }
            set { archivosColumnas = value; }
        }

        public List<ElementosDeGrupo.GraficaBarra> MasUsados
        {
            get { return masUsados; }
            set { masUsados = value; }
        }

        public List<ElementosDeGrupo.GraficaPie> ComponentesPie
        {
            get { return componentesPie; }
            set { componentesPie = value; }
        }

        public List<ElementosDeGrupo.GraficaColumnas> ComponentesColumnas
        {
            get { return componentesColumnas; }
            set { componentesColumnas = value; }
        }

        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
            set { resultadoXML = value; }
        }

        public GrupoCMModel(int UsuarioID, int AplicacionID)
        {
            String Nombreapp = ""; //MMOB - Se agregó variable
            if (datosObjetosCM.ObjetosCMConsulta(TipoConsulta1, UsuarioID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosCM.ResultadoXML.DocumentElement.SelectSingleNode("DatosCM");
                //MMOB - Se creo código para la optención del nombre de la aplicación
                if (aplicaciones.AplicacionesConsulta(UsuarioID, 0, AplicacionID))
                {
                    XmlNode xmlApp = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                    foreach (XmlNode elementoapp in xmlApp.SelectNodes("row"))
                    {
                        Nombreapp = elementoapp.Attributes["Aplicacion"].Value.ToString();
                    }
                }
                //MMOB
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    indicadores.Add(new ElementosDeGrupo.Indicadores(
                        elemento.Attributes["TipoObjeto"].Value.ToString(),
                        int.Parse(elemento.Attributes["Total"].Value.ToString()),
                        0, "", Nombreapp) //MMOB - Se agregó nuevo atributo "Nombreapp"
                        );
                }
            }

            if (datosObjetosCM.ObjetosCMConsulta(TipoConsulta2, UsuarioID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosCM.ResultadoXML.DocumentElement.SelectSingleNode("DatosCM");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    archivosPie.Add(new ElementosDeGrupo.GraficaPie(
                        int.Parse(elemento.Attributes["Porcentaje"].Value.ToString()),
                        elemento.Attributes["Descripcion"].Value.ToString())
                        );

                    archivosColumnas.Add(new ElementosDeGrupo.GraficaColumnas(
                        int.Parse(elemento.Attributes["Registros"].Value.ToString()),
                        elemento.Attributes["Descripcion"].Value.ToString(),
                        "")
                        );
                }
            }

            if (datosObjetosCM.ObjetosCMConsulta(TipoConsulta3, UsuarioID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosCM.ResultadoXML.DocumentElement.SelectSingleNode("DatosCM");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    masUsados.Add(new ElementosDeGrupo.GraficaBarra(
                        int.Parse(elemento.Attributes["Registros"].Value.ToString()),
                        elemento.Attributes["Objeto"].Value.ToString())
                        );
                }
            }

            if (datosObjetosCM.ObjetosCMConsulta(TipoConsulta4, UsuarioID, AplicacionID))
            {
                XmlNode xmlNode = datosObjetosCM.ResultadoXML.DocumentElement.SelectSingleNode("DatosCM");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    componentesPie.Add(new ElementosDeGrupo.GraficaPie(
                        int.Parse(elemento.Attributes["Porcentaje"].Value.ToString()),
                        elemento.Attributes["TipoHijo"].Value.ToString())
                        );

                    componentesColumnas.Add(new ElementosDeGrupo.GraficaColumnas(
                        int.Parse(elemento.Attributes["Registros"].Value.ToString()),
                        elemento.Attributes["TipoHijo"].Value.ToString(),
                        "")
                        );
                }
            }
        }
    }
}