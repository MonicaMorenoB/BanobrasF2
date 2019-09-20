using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using HerramientaAD.com.BaseDatos;

namespace HerramientaAD.com.Datos
{
    public class DatosDiagramaCM : GestionBD
    {
        const string obtenDiagramaCM = "sp_ObtenDiagramaCM";

        private XmlDocument resultadoXML;
        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
        }

        public bool DiagramaCMConsulta(int UsuarioID, int AplicacionID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(obtenDiagramaCM);
                CargaParametro("@aplicacionid", SqlDbType.Int, 8, ParameterDirection.Input, AplicacionID);
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("DiagramaCM");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Diagrama CM");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto DiagramaCM");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosDiagramaCM.DiagramaCMConsulta" + Err.Message.ToString());
            }
            return respuesta;
        }      
    }
}