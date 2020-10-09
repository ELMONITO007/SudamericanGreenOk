﻿using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluaciones_Tecnicas.Controllers.Personas
{
    public class PersonaController : Controller
    {
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /Persona/
        public ActionResult Index()
        {
            PersonaComponent personaComponent = new PersonaComponent();


            return View(personaComponent.Read());
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /Persona/Details/5
        public ActionResult ErrorPage(int id)
        {
            PersonaComponent personaComponent = new PersonaComponent();
            return View(personaComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /Persona/Create
        public ActionResult Create()
        {
            Persona persona = new Persona();
            TipoPersonaComponent personaComponent = new TipoPersonaComponent();
            persona.listaTipoPersona = personaComponent.Read();

           persona.listaTipoPersona.Select(y =>
                            new
                            {
                                y.Id,
                                y.tipoPersona
                            });

            ViewBag.RolesLista = new SelectList(persona.listaTipoPersona, "Id", "tipoPersona");

            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /Persona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Persona persona = new Persona();
                PersonaComponent personaComponent = new PersonaComponent();
                persona.Id = int.Parse(collection.Get("Id"));
                persona.cuil = collection.Get("cuil");
                persona.email = collection.Get("email");
                persona.telefono = collection.Get("telefono");
                persona.tipoPersona.Id =int.Parse( collection.Get("tipoPersona.Id"));
                if (personaComponent.Create(persona)is null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ErrorPage",new { id= persona.Id});
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /Persona/Edit/5
        public ActionResult Edit(int id)
        {
            Persona persona = new Persona();
            PersonaComponent personaComponent = new PersonaComponent();
            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            persona = personaComponent.ReadBy(id);
            persona = personaComponent.ObtenerTipoPersonaDiponible(id);

            persona.listaTipoPersona.Select(y =>
                             new
                             {
                                 y.Id,
                                 y.tipoPersona
                             });

            ViewBag.RolesLista = new SelectList(persona.listaTipoPersona, "Id", "tipoPersona");

            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Persona persona = new Persona();
                PersonaComponent personaComponent = new PersonaComponent();
                persona.Id = id;
                persona.cuil = collection.Get("cuil");
                persona.email = collection.Get("email");
                persona.telefono = collection.Get("telefono");
                persona.tipoPersona.Id = int.Parse(collection.Get("tipoPersona.Id"));
                if (personaComponent.Update(persona))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ErrorPage", new { id = persona.Id });
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /Persona/Delete/5
        public ActionResult Delete(int id)
        {
            PersonaComponent personaComponent = new PersonaComponent();
            return View(personaComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PersonaComponent personaComponent = new PersonaComponent();
                personaComponent.Delete(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
