using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio;

namespace Evaluaciones_Tecnicas.Controllers.Clientes
{
    public class TipoEquipoController : Controller
    {
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoEquipo/
        public ActionResult Index()
        {
            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
            
            return View(tipoEquipoComponent.Read());
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoEquipo/Details/5
        public ActionResult ErrorPage(int id)
        {
            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();

            return View(tipoEquipoComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoEquipo/Create
        public ActionResult Create()
        {


            return View();
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /TipoEquipo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
                TipoEquipo tipoEquipo = new TipoEquipo();
                tipoEquipo.tipoEquipo = collection.Get("tipoEquipo");
                tipoEquipo.descripcion = collection.Get("descripcion");
                if (tipoEquipoComponent.Create(tipoEquipo)==null)
                {
                    
                    return RedirectToAction("ErrorPage",new { id=tipoEquipoComponent.ReadBy(tipoEquipo.tipoEquipo).Id });
                }
                // TODO: Add insert logic here
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
        // GET: /TipoEquipo/Edit/5
        public ActionResult Edit(int id)
        {
            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();

            return View(tipoEquipoComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /TipoEquipo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
                TipoEquipo tipoEquipo = new TipoEquipo();
                tipoEquipo.tipoEquipo = collection.Get("tipoEquipo");
                tipoEquipo.descripcion = collection.Get("descripcion");
                tipoEquipo.Id = id;
                if (tipoEquipoComponent.Update(tipoEquipo))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("ErrorPage",new {id=id });
                }
            
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // GET: /TipoEquipo/Delete/5
        public ActionResult Delete(int id)
        {

            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();

            return View(tipoEquipoComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        //
        // POST: /TipoEquipo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
                tipoEquipoComponent.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
