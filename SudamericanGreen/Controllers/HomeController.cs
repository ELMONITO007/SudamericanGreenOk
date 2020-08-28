using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Evaluaciones.Controllers
{
    [ExceptionFilter]
    public class HomeController : Controller
    {
       
        [ExceptionFilter]
        [HttpPost]
        public ActionResult TestExamen(FormCollection formCollection)
        {
            return View();
        }
        [ExceptionFilter]
        public ActionResult Index()
        {
            return View();
        }

    }
}