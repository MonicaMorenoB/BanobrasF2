using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HerramientaAD.Models;

namespace HerramientaAD.Controllers
{
    public class TablerosController : Controller
    {
        // GET: Tableros
        public ActionResult Index()
        {
            if (Session["UsuarioID"] != null)
            {
                var tableroGeneralModel = new TableroGeneralModel(int.Parse(Session["UsuarioID"].ToString()), 0, 0);

                return View(tableroGeneralModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Inicial(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var tableroInicialModel = new TableroInicialModel(int.Parse(Session["UsuarioID"].ToString()), 0, AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = tableroInicialModel.ResultadoXML.InnerXml.Split('\"')[3]; //MMOB
                return View(tableroInicialModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GrupoBD(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var grupoBDModel = new GrupoBDModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = grupoBDModel.Indicadores.ElementAt(0).NombreApp; //MMOB
                return View(grupoBDModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GrupoBDDetalle(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var grupoBDModel = new GrupoBDModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = grupoBDModel.Indicadores.ElementAt(0).NombreApp; //MMOB
                return PartialView("GrupoBDIndicadores", grupoBDModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult CargaDatosGrupoBD(int BaseDeDatosID, int Tipo)
        {
            var datosGrafica = Json("", JsonRequestBehavior.AllowGet);
            if (Session["UsuarioID"] != null)
            {
                var grupoBDModel = new GrupoBDModel(int.Parse(Session["UsuarioID"].ToString()), BaseDeDatosID);
                switch(Tipo)
                {
                    case 1:
                        datosGrafica = Json(grupoBDModel.ArchivosPie, JsonRequestBehavior.AllowGet);
                        break;
                    case 2:
                        datosGrafica = Json(grupoBDModel.ArchivosColumn, JsonRequestBehavior.AllowGet);
                        break;
                    case 3:
                        datosGrafica = Json(grupoBDModel.MasUsados, JsonRequestBehavior.AllowGet);
                        break;
                };
            }
            else
            {
                RedirectToAction("Index", "Login");
            }
            return datosGrafica;
        }

        public ActionResult AnalisisBD(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var analisisBD = new AnalisisBD(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = analisisBD.Indicadores.ElementAt(0).NombreApp; //MMOB
                return View(analisisBD);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }           
        }

        public ActionResult AnalisisBDDetalle(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var analisisBDModel = new AnalisisBD(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = analisisBDModel.Indicadores.ElementAt(0).NombreApp; //MMOB
                return PartialView("AnalisisBDDetalle", analisisBDModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult CargaDatosAnalisisBD(int BaseDeDatosID, int Tipo)
        {
            var datosGrafica = Json("", JsonRequestBehavior.AllowGet);
            if (Session["UsuarioID"] != null)
            {
                var analisisBDModel = new AnalisisBD(int.Parse(Session["UsuarioID"].ToString()), BaseDeDatosID);
                switch (Tipo)
                {
                    case 1:
                        datosGrafica = Json(analisisBDModel.LlavePrimaria, JsonRequestBehavior.AllowGet);
                        break;
                    case 2:
                        datosGrafica = Json(analisisBDModel.LlaveForanea, JsonRequestBehavior.AllowGet);
                        break;
                    case 3:
                        datosGrafica = Json(analisisBDModel.Indexes, JsonRequestBehavior.AllowGet);
                        break;
                    case 4:
                        datosGrafica = Json(analisisBDModel.TipoObjeto, JsonRequestBehavior.AllowGet);
                        break;
                    case 5:
                        datosGrafica = Json(analisisBDModel.TamanoTabla, JsonRequestBehavior.AllowGet);
                        break;
                    case 6:
                        datosGrafica = Json(analisisBDModel.LineasEfectivas, JsonRequestBehavior.AllowGet);
                        break;
                    case 7:
                        datosGrafica = Json(analisisBDModel.LineasComentadas, JsonRequestBehavior.AllowGet);
                        break;
                    case 8:
                        datosGrafica = Json(analisisBDModel.Select, JsonRequestBehavior.AllowGet);
                        break;
                    case 9:
                        datosGrafica = Json(analisisBDModel.Insert, JsonRequestBehavior.AllowGet);
                        break;
                    case 10:
                        datosGrafica = Json(analisisBDModel.Update, JsonRequestBehavior.AllowGet);
                        break;
                    case 11:
                        datosGrafica = Json(analisisBDModel.Delete, JsonRequestBehavior.AllowGet);
                        break;
                    case 12:
                        datosGrafica = Json(analisisBDModel.Siif, JsonRequestBehavior.AllowGet);
                        break;
                    case 13:
                        datosGrafica = Json(analisisBDModel.Loop, JsonRequestBehavior.AllowGet);
                        break;
                    case 14:
                        datosGrafica = Json(analisisBDModel.Select2, JsonRequestBehavior.AllowGet);
                        break;
                    case 15:
                        datosGrafica = Json(analisisBDModel.Excepcion, JsonRequestBehavior.AllowGet);
                        break;
                };
            }
            else
            {
                RedirectToAction("Index", "Login");
            }
            return datosGrafica;
        }

        public ActionResult GrupoWS(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var grupoWSModel = new GrupoWSModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = grupoWSModel.Indicadores.ElementAt(0).NombreApp; //MMOB
                return View(grupoWSModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GrupoCM(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var grupoCMModel = new GrupoCMModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                ViewBag.NombreAplicacion = grupoCMModel.Indicadores.ElementAt(0).NombreApp; //MMOB
                return View(grupoCMModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult DiagramaUML(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var diagramaUMLModel = new DiagramaUMLModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.Aplicacion = AplicacionID;
                return View(diagramaUMLModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AnalisisCM(int AplicacionID)
        {
            if (Session["UsuarioID"] != null)
            {
                var analisisCMModel = new AnalisisCMModel(int.Parse(Session["UsuarioID"].ToString()), AplicacionID);
                ViewBag.NombreAplicacion = analisisCMModel.Aplicacion; //MMOB
                ViewBag.Aplicacion = AplicacionID;
                return View(analisisCMModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}