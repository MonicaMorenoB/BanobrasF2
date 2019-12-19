using HerramientaAD.com.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace HerramientaAD.com.Datos
{
    public class DatosObjetosMetricas : GestionBD
    {
        const string ResultadoMetricas = "sp_PruebaMetricas";

        private XmlDocument resultadoXML;
        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
        }

        public bool PruebaMetricas(int UsuarioID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(ResultadoMetricas);               
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("ResultadosMetricas");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Resulatdos de las Métricas");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Resulatdos de las Métricas");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosObjetosMetricas.PruebaMetricas" + Err.Message.ToString());
            }
            return respuesta;
        }
    }
}