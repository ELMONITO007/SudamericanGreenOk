using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entities;
using Evaluaciones_Tecnicas.Filter;

namespace Evaluaciones_Tecnicas.Controllers.Clientes
{
    public class EquipoClienteController : Controller
    {
        [AuthorizerUser(_roles: "Cliente")]
        public ActionResult EquipoDelCliente(int id)
        {
            EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();
            return View(equipoClienteComponent.ReadByCliente(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /EquipoCliente/
        public ActionResult Index()
        {
            EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();

            return View(equipoClienteComponent.Read());
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /EquipoCliente/Details/5
        public ActionResult ErrorPage(int id)
        {
            EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();

            return View(equipoClienteComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /EquipoCliente/Create
        public ActionResult Create(int id)
        {
            EquipoCliente equipoCliente = new EquipoCliente();
            PersonaComponent personaComponent = new PersonaComponent();
            MarcaComponent marcaComponent = new MarcaComponent();
            TipoEquipoComponent tipoEquipo = new TipoEquipoComponent();
            equipoCliente.persona = personaComponent.ReadBy(id);
            equipoCliente.listaMarca = marcaComponent.Read();
            equipoCliente.listaTipoEquipo = tipoEquipo.Read();

            equipoCliente.listaMarca.Select(y => new
            {
                y.Id,
                y.marca
            }


            );
            ViewBag.listaMarca = new SelectList(equipoCliente.listaMarca, "Id", "marca");

            equipoCliente.listaTipoEquipo.Select(y => new
            {
                y.Id,
                y.tipoEquipo
            }

                );
            ViewBag.listaTipoEquipo = new SelectList(equipoCliente.listaTipoEquipo, "Id", "tipoEquipo");

            return View(equipoCliente);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /EquipoCliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                EquipoCliente equipoCliente = new EquipoCliente();
                EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();
                equipoCliente.antiguedad = int.Parse(collection.Get("antiguedad"));
                equipoCliente.fechaCompra = DateTime.Parse(collection.Get("fechaCompra"));
                equipoCliente.marca.Id = int.Parse(collection.Get("marca.Id"));
                equipoCliente.modelo = collection.Get("modelo");
                equipoCliente.persona.Id = int.Parse(collection.Get("persona.Id"));
                equipoCliente.peso = int.Parse(collection.Get("peso"));
                equipoCliente.serial = collection.Get("serial");
                equipoCliente.tipoEquipo.Id = int.Parse(collection.Get("tipoEquipo.Id"));

                if (equipoClienteComponent.Create(equipoCliente) == null)
                {
                    return RedirectToAction("errorPage", new { id = equipoClienteComponent.ReadBy(equipoCliente.serial).Id });
                }
                else
                {
                    return RedirectToAction("index");
                }

            }
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /EquipoCliente/Edit/5
        public ActionResult Edit(int id)
        {
            EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();
            EquipoCliente equipoCliente = new EquipoCliente();
            PersonaComponent personaComponent = new PersonaComponent();
            MarcaComponent marcaComponent = new MarcaComponent();
            TipoEquipoComponent tipoEquipo = new TipoEquipoComponent();
            equipoCliente = equipoClienteComponent.ReadBy(id);


            equipoCliente.listaMarca = marcaComponent.Read();
            equipoCliente.listaTipoEquipo = tipoEquipo.Read();

            equipoCliente.listaMarca.Select(y => new
            {
                y.Id,
                y.marca
            }


            );
            ViewBag.listaMarca = new SelectList(equipoCliente.listaMarca, "Id", "marca");

            equipoCliente.listaTipoEquipo.Select(y => new
            {
                y.Id,
                y.tipoEquipo
            }

                );
            ViewBag.listaTipoEquipo = new SelectList(equipoCliente.listaTipoEquipo, "Id", "tipoEquipo");

            return View(equipoCliente);
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /EquipoCliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                EquipoCliente equipoCliente = new EquipoCliente();
                EquipoClienteComponent equipoClienteComponent = new EquipoClienteComponent();
                equipoCliente.Id = id;
                equipoCliente.antiguedad = int.Parse(collection.Get("antiguedad"));
                equipoCliente.fechaCompra = DateTime.Parse(collection.Get("fechaCompra"));
                equipoCliente.marca.Id = int.Parse(collection.Get("marca.Id"));
                equipoCliente.modelo = collection.Get("modelo");
                equipoCliente.persona.Id = int.Parse(collection.Get("persona.Id"));
                equipoCliente.peso = int.Parse(collection.Get("peso"));
                equipoCliente.serial = collection.Get("serial");
                equipoCliente.tipoEquipo.Id = int.Parse(collection.Get("tipoEquipo.Id"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /EquipoCliente/Delete/5
        public ActionResult Delete(int id)
        {
            EquipoClienteComponent equipoCliente = new EquipoClienteComponent();
            return View(equipoCliente.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /EquipoCliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                EquipoClienteComponent equipoCliente = new EquipoClienteComponent();
                equipoCliente.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
