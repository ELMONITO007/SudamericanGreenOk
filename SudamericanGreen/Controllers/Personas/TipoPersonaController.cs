using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Negocio;

namespace Evaluaciones_Tecnicas.Controllers.Personas
{
    public class TipoPersonaController : Controller
    {
        //
        // GET: /TipoPersona/
        public ActionResult Index()
        {
            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.Read());
        }
       
      
        public ActionResult ErrorPage(int id)
        {

            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.ReadBy(id));
        }

        //
        // GET: /TipoPersona/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoPersona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
                TipoPersona tipoPersona = new TipoPersona();
                tipoPersona.tipoPersona = collection.Get("tipoPersona");
                if (tipoPersonaComponent.Create(tipoPersona)is null)
                {
                    tipoPersona = tipoPersonaComponent.ReadBy(tipoPersona.tipoPersona);
                    return RedirectToAction("ErrorPage", new { id = tipoPersona.Id });
                }
                else
                {
                    return RedirectToAction("Index");
                }

               
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TipoPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TipoPersona/Edit/5
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
        // GET: /TipoPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TipoPersona/Delete/5
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
