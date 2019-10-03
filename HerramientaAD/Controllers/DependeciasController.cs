﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using HerramientaAD.Models;
using HerramientaAD.com.Datos;
using HerramientaAD.com.Utilerias;


namespace HerramientaAD.Controllers
{
    public class DependeciasController : Controller
    {
        DependeciasModel datosDependeciasM = new DependeciasModel();
        List<ListasDesplegables> aplicacionesLista = new List<ListasDesplegables>();
        DatosDependencias datosDependeciasSQL = new DatosDependencias();
        public ActionResult Index()
        {
            if (Session["UsuarioID"] != null)
            {
                var detalleDependeciasModel = new DependeciasModel(int.Parse(Session["UsuarioID"].ToString()));
                return View(detalleDependeciasModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }
        public JsonResult ActualizarAplicaciones(int AreaID)
        {
            Aplicaciones aplicaciones = new Aplicaciones();

            if (aplicaciones.AplicacionesConsulta(1, AreaID, 0))
            {
                aplicacionesLista.Add(new ListasDesplegables(0, "Selecciona"));
                XmlNode xmlNode = aplicaciones.ResultadoXML.DocumentElement.SelectSingleNode("Aplicaciones");
                foreach (XmlNode elemento in xmlNode.SelectNodes("row"))
                {
                    aplicacionesLista.Add(new ListasDesplegables(
                        int.Parse(elemento.Attributes["AplicacionID"].Value.ToString()),
                        elemento.Attributes["Aplicacion"].Value.ToString())
                        );
                }
            }

            return Json(new SelectList(aplicacionesLista, "Indice", "Texto"), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// carga tabla
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public ActionResult ActualizaDetalle(int appid, string nombre)
        {
            if (Session["usuid"] != null)
            {
                DependeciasModel objdep = new DependeciasModel(appid, int.Parse(Session["usuid"].ToString()), nombre);
                return PartialView("Detalle", objdep);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult GeneraDiagrama(int appid, int maxe, int tipoid, string nomapp)
        {
            string diagramahtml = string.Empty;
            return Json(diagramahtml, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ActualizaIndicadores(int TipoID, int AplicacionID, int ProcesoID)
        {
            var grupoDepModel = new DependeciasModel(1, TipoID, AplicacionID, ProcesoID);
            var cc = Json(grupoDepModel.Ldep, JsonRequestBehavior.AllowGet);
            return cc;
        }



        public ActionResult ActualizaTablaUsos(int AplicacionID)
        {
            datosDependeciasM.DetalleXML = TabUsodel(1, AplicacionID);
            return PartialView("Detalle", datosDependeciasM);
        }

        public XmlDocument TabUsodel(int UsuarioID, int AplicacionID)
        {
            XmlDocument detalleXML = new XmlDocument();
            if (datosDependeciasSQL.TablaUsosConsulta(UsuarioID, AplicacionID))
            {
                detalleXML = datosDependeciasSQL.ResultadoXML;
            }
            return detalleXML;
        }


        //diagrama
        public JsonResult ArregloCuadroC(int BaseDeDatosID, int Tipo)
        {
            var cc = Json("", JsonRequestBehavior.AllowGet);
            if (Session["UsuarioID"] != null)
            {
                var grupoDepModel = new DependeciasModel(int.Parse(Session["UsuarioID"].ToString()), BaseDeDatosID, Tipo);
                cc = Json(grupoDepModel.Cuadros, JsonRequestBehavior.AllowGet);
                return cc;
            }
            else
            {
                 RedirectToAction("Index", "Login");
                cc = Json("", JsonRequestBehavior.AllowGet);
            }
            return cc;
        }

        public JsonResult ArregloCuadroCN2(int Aplicacion, string NombreObj)
        {
            var cc = Json("", JsonRequestBehavior.AllowGet);
            if (Session["UsuarioID"] != null)
            {
                var grupoDepModel = new DependeciasModel(int.Parse(Session["UsuarioID"].ToString()), Aplicacion, NombreObj);
                cc = Json(grupoDepModel.Cuadros, JsonRequestBehavior.AllowGet);
                return cc;
            }
            else
            {
                RedirectToAction("Index", "Login");
                cc = Json("", JsonRequestBehavior.AllowGet);
            }
            return cc;            
        }

        public ActionResult ActualizaTablaUsosN2(int AplicacionID, string ObjNombre)
        {
            datosDependeciasM.DetalleXML = TabUsodelN2(1, AplicacionID, ObjNombre);
            return PartialView("Detalle", datosDependeciasM);
        }

        public XmlDocument TabUsodelN2(int UsuarioID, int AplicacionID, string ObjNombre)
        {
            XmlDocument detalleXML = new XmlDocument();
            if (datosDependeciasSQL.DiagramaN2Consulta(UsuarioID, AplicacionID, ObjNombre))
            {
                detalleXML = datosDependeciasSQL.ResultadoXML;
            }
            return detalleXML;
        }

    }
}