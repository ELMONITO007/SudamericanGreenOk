using Entities;
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
        public ActionResult ErroPage(String id)
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
                Permiso permiso = new Permiso();
                permiso.name = collection.Get("name");
                PermisoComponent permisoComponent = new PermisoComponent();
                if (permisoComponent.Create(permiso) is null)
                {
                    return RedirectToAction("ErroPage", new { id = permiso.name});
                }
                else
                {
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                
            }
            catch (Exception e)
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
                Permiso permiso = new Permiso();
                permiso.name = collection.Get("name");
                permiso.Id = id;
                PermisoComponent permisoComponent = new PermisoComponent();
                if (permisoComponent.Verificar(permiso))
                {
                    permisoComponent.Update(permiso);
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("ErroPage", new { id = permiso.name });
                }
               
            }
            catch (Exception e)
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
                PermisoComponent permisoComponent = new PermisoComponent();
                permisoComponent.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
