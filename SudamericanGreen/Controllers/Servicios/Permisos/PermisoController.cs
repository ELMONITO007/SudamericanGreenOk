using Negocio.Servicios.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluaciones_Tecnicas.Controllers
{
    public class PermisoController : Controller
    {
        //
        // GET: /Permiso/
        public ActionResult Index()
        {
            PermisoComponent permisoComponent = new PermisoComponent();
            return View(permisoComponent.Read());
        }

        //
        // GET: /Permiso/Details/5
        public ActionResult ErroPage(int id)
        {
            PermisoComponent permisoComponent = new PermisoComponent();
            return View(permisoComponent.ReadBy(id));
        }

        //
        // GET: /Permiso/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Permiso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permiso/Edit/5
        public ActionResult Edit(int id)
        {
            PermisoComponent permisoComponent = new PermisoComponent();
            return View(permisoComponent.ReadBy(id));
        }

        //
        // POST: /Permiso/Edit/5
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
        // GET: /Permiso/Delete/5
        public ActionResult Delete(int id)
        {
            PermisoComponent permisoComponent = new PermisoComponent();
            return View(permisoComponent.ReadBy(id));
        }

        //
        // POST: /Permiso/Delete/5
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
