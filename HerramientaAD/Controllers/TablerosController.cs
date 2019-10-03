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