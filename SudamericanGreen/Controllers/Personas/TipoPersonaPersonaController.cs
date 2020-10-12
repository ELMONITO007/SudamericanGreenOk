using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Negocio;
using Negocio.Personas;

namespace Evaluaciones_Tecnicas.Controllers.Personas
{
    public class TipoPersonaPersonaController : Controller
    {
        //
        // GET: /TipoPersonaPersona/
        public ActionResult Index(int id)
        {
            TipoPersonaPersonaComponent tipoPersonaPersonaComponent = new TipoPersonaPersonaComponent();
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
            tipoPersonaPersona.tipoPersonaPersona = tipoPersonaPersonaComponent.Read(id);
            PersonaComponent personaComponent = new PersonaComponent();
            tipoPersonaPersona.persona = personaComponent.ReadBy(id);
            return View(tipoPersonaPersona);
        }

        //
        // GET: /TipoPersonaPersona/Details/5
        public ActionResult ErroPage(int id)
        {
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
            tipoPersonaPersona.persona.Id = id;
            return View(tipoPersonaPersona);
        }

        //
        // GET: /TipoPersonaPersona/Create
        public ActionResult Create(int id)
        {
            TipoPersonaPersonaComponent personaComponent = new TipoPersonaPersonaComponent();
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
            tipoPersonaPersona=personaComponent.ObtenerTipoDisponible(id);

            tipoPersonaPersona.tipoPersonaPersona.Select(y =>
                            new
                            {
                                y.tipoPersona.Id,
                                y.tipoPersona.tipoPersona
                            });

            ViewBag.RolesLista = new SelectList(tipoPersonaPersona.tipoPersonaPersona, "tipoPersona.Id", "tipoPersona.tipoPersona");

            if (tipoPersonaPersona.tipoPersonaPersona.Count==0)
            {
            tipoPersonaPersona=personaComponent.ObtenerTipoDisponible(id);
                return RedirectToAction("ErroPage", new { id = tipoPersonaPersona.persona.Id });
            }
            else
            {
                return View(tipoPersonaPersona);
            }
            
           
        }

        //
        // POST: /TipoPersonaPersona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
                TipoPersonaPersonaComponent tipoPersona = new TipoPersonaPersonaComponent();
                tipoPersonaPersona.persona.Id = int.Parse(collection.Get("persona.id"));
                tipoPersonaPersona.tipoPersona.Id = int.Parse(collection.Get("tipoPersona.tipoPersona"));
                if (tipoPersona.Create(tipoPersonaPersona) is null)
                {
                    return RedirectToAction("ErroPage", new { id = tipoPersonaPersona.persona.Id });
                }
                else
                {
                    return RedirectToAction("Index", new { id = tipoPersonaPersona.persona.Id });
                }
               
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /TipoPersonaPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TipoPersonaPersona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /TipoPersonaPersona/Delete/5
        public ActionResult Delete(int id,int tipo)
        {
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
            PersonaComponent personaComponent = new PersonaComponent();
            tipoPersonaPersona.persona = personaComponent.ReadBy(id);
            TipoPersonaComponent tipoPersona = new TipoPersonaComponent();
            tipoPersonaPersona.tipoPersona = tipoPersona.ReadBy(tipo);
            return View(tipoPersonaPersona);
        }

        //
        // POST: /TipoPersonaPersona/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
                TipoPersonaPersonaComponent tipoPersona = new TipoPersonaPersonaComponent();
                tipoPersonaPersona.persona.Id = int.Parse(collection.Get("persona.id"));
                tipoPersonaPersona.tipoPersona.Id = int.Parse(collection.Get("tipoPersona.id"));
                tipoPersona.Delete(tipoPersonaPersona.persona.Id, tipoPersonaPersona.tipoPersona.Id);
                return RedirectToAction("Index", new { id = tipoPersonaPersona.persona.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
