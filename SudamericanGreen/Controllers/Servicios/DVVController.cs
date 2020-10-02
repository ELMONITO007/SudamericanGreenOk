using Negocio;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluaciones_Tecnicas.Controllers.Servicios
{
    public class DVVController : Controller
    {
        //
        // GET: /DVV/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DVV/Details/5
        public ActionResult VerificarTabla()
        {

   

            return View();
        }

        //
        // GET: /DVV/Create
      

        //
        // POST: /DVV/Create
        [HttpPost]
        public ActionResult VerificarTabla(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                LoginComponent loginComponent = new LoginComponent();
                bool resultado = loginComponent.VerificarDVV();

                return RedirectToAction("Resultado",new { estado = resultado});
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DVV/Edit/5
        public ActionResult Resultado(bool estado)
        {
            if (!estado)
            {
                BackupComponent backupComponent = new BackupComponent();
                backupComponent.RestaurarBase();
            }
            return View();
        }

        //
        // POST: /DVV/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DVV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DVV/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
