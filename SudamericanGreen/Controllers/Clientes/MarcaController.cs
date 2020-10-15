using Evaluaciones_Tecnicas.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entities;

namespace Evaluaciones_Tecnicas.Controllers.Clientes
{
    public class MarcaController : Controller
    {
        [AuthorizerUser(_roles: "Administrador")]
        // GET: /Marca/
        public ActionResult Index()
        {
            MarcaComponent marcaComponent = new MarcaComponent();


            return View(marcaComponent.Read());
        }

        [AuthorizerUser(_roles: "Administrador")]
        // GET: /Marca/Details/5
        public ActionResult ErrorPage(int id)
        {

            MarcaComponent marcaComponent = new MarcaComponent();


            return View(marcaComponent.ReadBy(id));
        }

        [AuthorizerUser(_roles: "Administrador")]
        // GET: /Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        [AuthorizerUser(_roles: "Administrador")]
        // POST: /Marca/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                Marca marca = new Marca();
                marca.marca = collection.Get("marca");
                MarcaComponent marcaComponent = new MarcaComponent();
                if (marcaComponent.Create(marca) == null)
                {
                    return RedirectToAction("errorpage", new { id = marcaComponent.ReadBy(marca.marca).Id });
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
        // GET: /Marca/Edit/5
        public ActionResult Edit(int id)
        {
            MarcaComponent marcaComponent = new MarcaComponent();


            return View(marcaComponent.ReadBy(id));
        }

        [AuthorizerUser(_roles: "Administrador")]
        // POST: /Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Marca marca = new Marca();
                marca.marca = collection.Get("marca");
                marca.Id = id;
                MarcaComponent marcaComponent = new MarcaComponent();
                if (marcaComponent.Update(marca))
                {
                  return RedirectToAction("Index");
                }
                else
                { 
                    return RedirectToAction("errorpage", new { id = marcaComponent.ReadBy(marca.marca).Id });
                    
                }
            }
            catch(Exception e)
            {
                return View();
            }
        }

        [AuthorizerUser(_roles: "Administrador")]
        // GET: /Marca/Delete/5
        public ActionResult Delete(int id)
        {
            MarcaComponent marcaComponent = new MarcaComponent();


            return View(marcaComponent.ReadBy(id));
        }

        [AuthorizerUser(_roles: "Administrador")]
        // POST: /Marca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MarcaComponent marcaComponent = new MarcaComponent();
                marcaComponent.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
