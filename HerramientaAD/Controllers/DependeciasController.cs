using System;
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
       DependeciasModel datosDependecias = new DependeciasModel();
        List<ListasDesplegables> aplicacionesLista = new List<ListasDesplegables>();
        public ActionResult Index()
        {
            var detalleDependeciasModel = new DependeciasModel(int.Parse(Session["UsuarioID"].ToString()));
            return View(detalleDependeciasModel);
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

        public ActionResult ActualizaDetalle(int appid, string nombre)
        {
            DependeciasModel objdep = new DependeciasModel(appid, int.Parse(Session["usuid"].ToString()), nombre);
            return PartialView("Detalle", objdep);
        }
    }
}