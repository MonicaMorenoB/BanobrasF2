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
    public class DatosObjetosResumenHallazgos : GestionBD
    {
        const string ResultadosBaseDatos = "sp_ResultadosBaseDatos";

        private XmlDocument resultadoXML;
        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
        }

        public bool ObjetosResultBDConsulta(int Tipo, int UsuarioID, int BaseDAtosID, int AppliID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(ResultadosBaseDatos);
                CargaParametro("@tipo", SqlDbType.Int, 8, ParameterDirection.Input, Tipo); 
                CargaParametro("@AppliID", SqlDbType.Int, 8, ParameterDirection.Input, AppliID);
                CargaParametro("@basedatosid", SqlDbType.Int, 8, ParameterDirection.Input, BaseDAtosID);
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("ResultadosBD");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Resulatdos de Base de Datos");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Resulatdos de Base de Datos");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosObjetosResumenHallazgos.ObjetosWSConsulta" + Err.Message.ToString());
            }
            return respuesta;
        }
    }
}