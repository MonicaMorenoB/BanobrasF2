using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;

namespace HerramientaAD.Models
{
    public class DiagramaUMLModel
    {
        Aplicaciones aplicaciones = new Aplicaciones(); //MMOB- NUEVO
        private List<ElementosDeGrupo.Indicadores> indicadores = new List<ElementosDeGrupo.Indicadores>();
        
        public List<ElementosDeGrupo.Indicadores> Indicadores
        {
            get { return indicadores; }
            set { indicadores = value; }
        }

        public DiagramaUMLModel(int UsuarioID, int AplicacionID)
        {
            //MMOB - Se creo código para la optención del nombre de la aplicación
            if (aplicaciones.AplicacionesConsulta(UsuarioID, 0, AplicacionID))
            {
                XmlNode xmlApp = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                foreach (XmlNode elementoapp in xmlApp.SelectNodes("row"))
                {
                    indicadores.Add(new ElementosDeGrupo.Indicadores(
                   "",
                   0,
                   0, "",
                   elementoapp.Attributes["Aplicacion"].Value.ToString()) //MMOB - Se agregó nuevo atributo "Nombreapp"
                   );
                }
            }
        }
    }
}
