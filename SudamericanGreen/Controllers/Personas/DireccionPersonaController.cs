using Evaluaciones_Tecnicas.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entities;
namespace Evaluaciones_Tecnicas.Controllers.Personas
{
    public class DireccionPersonaController : Controller
    {
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /DireccionPersona/
        public ActionResult Index(int id)
        {
            DireccionPersona persona = new DireccionPersona();
            DireccionPersonaComponent direccionPersona = new DireccionPersonaComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            persona.direccionPersona = direccionPersona.ReadByPersona(id);
            persona.persona = personaComponent.ReadBy(id);
            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /DireccionPersona/Details/5
        public ActionResult ErroPage(int id)
        {
            DireccionPersona persona = new DireccionPersona();
           
            persona.persona.Id = id;
            


            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /DireccionPersona/Create
        public ActionResult Create(int id)
        {
            DireccionPersona persona = new DireccionPersona();
            PersonaComponent personaComponent = new PersonaComponent();
            persona.persona = personaComponent.ReadBy(id);

            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /DireccionPersona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here
                DireccionPersona persona = new DireccionPersona();
                DireccionPersonaComponent direccionPersonaComponent = new DireccionPersonaComponent();
                persona.persona.Id = int.Parse(collection.Get("persona.Id"));
                persona.direccion.direccion = collection.Get("direccion.direccion");
                persona.direccion.numero = int.Parse(collection.Get("direccion.numero"));
                persona.direccion.piso = int.Parse(collection.Get("direccion.piso"));
                persona.direccion.departamento = collection.Get("direccion.departamento");
                persona.direccion.localidad = collection.Get("direccion.localidad");
                persona.direccion.codigoPostal = int.Parse(collection.Get("direccion.codigoPostal"));
                persona.direccion.provincia = collection.Get("direccion.provincia");
                if (direccionPersonaComponent.Create(persona)is null)
                {
                    return RedirectToAction("ErrorPage", new { id = persona.persona.Id });
                   
                }
                else
                {
                    return RedirectToAction("Index", new { id = persona.persona.Id });
                }
                
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /DireccionPersona/Edit/5
        public ActionResult Edit(int id,int dni)
        {
            DireccionPersona persona = new DireccionPersona();
            DireccionComponent direccion = new DireccionComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            persona.direccion = direccion.ReadBy(id);
            persona.persona = personaComponent.ReadBy(dni);


            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /DireccionPersona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Direccion persona = new Direccion();
                DireccionComponent direccionPersonaComponent = new DireccionComponent();
                int a = int.Parse(collection.Get("persona.id"));
                persona.Id =int.Parse( collection.Get("direccion.id"));
                persona.direccion = collection.Get("direccion.direccion");
                persona.numero = int.Parse(collection.Get("direccion.numero"));
                persona.piso = int.Parse(collection.Get("direccion.piso"));
                persona.departamento = collection.Get("direccion.departamento");
                persona.localidad = collection.Get("direccion.localidad");
                persona.codigoPostal = int.Parse(collection.Get("direccion.codigoPostal"));
                persona.provincia = collection.Get("direccion.provincia");
                if (direccionPersonaComponent.Update(persona))
                {
                    
                    return RedirectToAction("Index", new { id = a });
                }
                else
                {
                    return RedirectToAction("ErrorPage", new { id = a });
                }
            }
            catch
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /DireccionPersona/Delete/5
        public ActionResult Delete(int id,int dni)
        {

            DireccionPersona persona = new DireccionPersona();
            PersonaComponent personaComponent = new PersonaComponent();
            persona.persona = personaComponent.ReadBy(dni);
            DireccionComponent direccion = new DireccionComponent();
            persona.direccion = direccion.ReadBy(id);
            return View(persona);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /DireccionPersona/Delete/5
        [HttpPost]
        public ActionResult Delete( FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DireccionPersona direccion = new DireccionPersona();
                DireccionPersonaComponent direccionPersona = new DireccionPersonaComponent();

                direccion.persona.Id = int.Parse(collection.Get("persona.Id"));

                direccion.direccion.Id = int.Parse(collection.Get("direccion.Id"));
                direccionPersona.Delete(direccion.persona.Id, direccion.direccion.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
