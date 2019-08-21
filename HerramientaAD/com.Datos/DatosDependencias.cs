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
        const string obtenDiagramaNivel1 = "Sp_ObtenDiagramaNivel1"; 
            const string obtenDiagramaNivel2 = "Sp_ObtenDiagramaNivel2";

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

        public bool DiagramaN1Consulta(int UsuarioID, int AplicacionID, int TipoID)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(obtenDiagramaNivel1);
                CargaParametro("@UsuarioID", SqlDbType.Int, 8, ParameterDirection.Input, UsuarioID);
                CargaParametro("@AplicacionID", SqlDbType.Int, 8, ParameterDirection.Input, AplicacionID);
                CargaParametro("@TipoID", SqlDbType.Int, 8, ParameterDirection.Input, TipoID);
           
                SqlDataReader Lector = AlmacenarStoredProcedureDataReader();
                if (Lector.Read())
                {
                    resultadoXML = new XmlDocument();
                    string Document = "<xml>" + Lector[0].ToString() + "</xml>";
                    resultadoXML.LoadXml(Document);
                    XmlNode xmlNode = resultadoXML.DocumentElement.SelectSingleNode("ObjetosDB");
                    respuesta = xmlNode.HasChildNodes;
                }
                CerrarConexion();
                if (respuesta)
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Objetos de Base de Datos N1");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Objetos de Base de Datos N1");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosDependecias.DiagramaN1Consulta " + Err.Message.ToString());
            }
            return respuesta;
        }

        public bool DiagramaN2Consulta(int UsuarioID, int AplicacionID, string ObjetoNombre)
        {
            bool respuesta = false;
            try
            {
                PreparaStoredProcedure(obtenDiagramaNivel2);
                CargaParametro("@UsuarioID", SqlDbType.Int, 8, ParameterDirection.Input, UsuarioID);
                CargaParametro("@AplicacionID", SqlDbType.Int, 8, ParameterDirection.Input, AplicacionID);
                CargaParametro("@ObjNombre", SqlDbType.VarChar, 20, ParameterDirection.Input, ObjetoNombre);

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
                    EscribeLog("Correcto: Usuario: " + UsuarioID + " Consulto Objetos de Base de Datos N2");
                else
                    EscribeLog("Error: Usuario: " + UsuarioID + " No Consulto Objetos de Base de Datos N2");
            }
            catch (Exception Err)
            {
                EscribeLog("Excepcion: DatosDependecias.DiagramaN2Consulta " + Err.Message.ToString());
            }
            return respuesta;
        }
    }
}