using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Windows;

namespace HerramientaAD.Controllers
{
    public class ProcesosController : Controller
    {
        // GET: Procesos
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Procesos");
        }
    }
}