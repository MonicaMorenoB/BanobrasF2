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
    public class DatosDependencias : GestionBD
    {
        const string obtenIndicadores = "Sp_ObtenIndicadores";
        const string obtenTablaUsos = "Sp_ObtenTablaUsos";
        private XmlDocument resultadoXML;
        public XmlDocument ResultadoXML
        {
            get { return resultadoXML; }
        }

        public bool IndicadoresConsulta(int UsuarioID, int TipoID, int AplicacionID, int ProcesoID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(obtenIndicadores);
                CargaParametro("@UsuarioID", SqlDbType.Int, 8, ParameterDirection.Input, UsuarioID);
                CargaParametro("@TipoID", SqlDbType.Int, 8, ParameterDirection.Input, TipoID);
                CargaParametro("@AplicacionID", SqlDbType.Int, 8, ParameterDirection.Input, AplicacionID);
                CargaParametro("@ProcesoID", SqlDbType.Int, 8, ParameterDirection.Input, ProcesoID);
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("Indicadores");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Indicadores");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Indicadores");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosDependecias.IndicadoresConsulta " + Err.Message.ToString());
            }
            return respuesta;
        }

        public bool TablaUsosConsulta(int UsuarioID, int AplicacionID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(obtenTablaUsos);
                CargaParametro("@UsuarioID", SqlDbType.Int, 8, ParameterDirection.Input, UsuarioID);
                CargaParametro("@AplicacionID", SqlDbType.Int, 8, ParameterDirection.Input, AplicacionID);
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("Objetos");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Tabla usos");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Tabla usos");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosDependecias.TablaUsosConsulta " + Err.Message.ToString());
            }
            return respuesta;
        }
    }
}