using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio;

namespace Evaluaciones_Tecnicas.Controllers.Personas
{
    public class TipoPersonaController : Controller
    {
        //
        // GET: /TipoPersona/
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Index()
        {
            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.Read());
        }

        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult ErrorPage(int id)
        {

            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoPersona/Create
        public ActionResult Create()
        {
            return View();
        }
        [AuthorizerUser(_roles: "Administrador")]

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
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoPersona/Edit/5
        public ActionResult Edit(int id)
        {

            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /TipoPersona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
                TipoPersona tipoPersona = new TipoPersona();
                tipoPersona.tipoPersona = collection.Get("tipoPersona");
                tipoPersona.Id = id;
                if (tipoPersonaComponent.Update(tipoPersona))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    tipoPersona = tipoPersonaComponent.ReadBy(tipoPersona.tipoPersona);
                    return RedirectToAction("ErrorPage", new { id });
                   
                }
            }
            catch
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoPersona/Delete/5
        public ActionResult Delete(int id)
        {
            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            return View(tipoPersonaComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /TipoPersona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
                tipoPersonaComponent.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
