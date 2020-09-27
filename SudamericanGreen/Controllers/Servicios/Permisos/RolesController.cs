using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio;
using Negocio.Servicios.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluaciones.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        //[AuthorizerUser(_roles: "Administrador")]
        public ActionResult Index()
        {
            RolesComponent roles = new RolesComponent();
         
            return View(roles.Read());
        }

        // GET: Roles/Details/5
        //[AuthorizerUser(_roles: "Administrador")]
        public ActionResult Details(int id)
        {
            RolesComponent roles = new RolesComponent();
            return View(roles.ReadBy(id));
        }

        // GET: Roles/Create
        //[AuthorizerUser(_roles: "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        //[AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                RolesComponent rolesComponent = new RolesComponent();
                Roles roles = new Roles();
                roles.name = collection.Get("name");
                if (rolesComponent.Create(roles) is null)
                {
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ErrorPage",new { id=roles.name});
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult VerPermisos(int id)
        {
            RolesComponent roles = new RolesComponent();
            Roles roles1 = new Roles();
      
           roles1= roles.ReadBy(id);
            roles.ObtenerComposite(roles1);
            return View(roles1);
        }
       
        // GET: Roles/Edit/5
        //[AuthorizerUser(_roles: "Administrador")]
        public ActionResult Edit(int id)
        {
            RolesComponent rolesComponent = new RolesComponent();
            return View(rolesComponent.ReadBy(id));
        }

        // POST: Roles/Edit/5
        //[AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                RolesComponent rolesComponent = new RolesComponent();
                Roles roles = new Roles();
                roles.name = collection.Get("name");
                roles.id = id;
                Roles rolBase = new Roles();
                if (rolesComponent.Verificar(roles))
                {
                    rolesComponent.Update(roles);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ErrorPage",new { id=roles.name});
                }


            
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        //[AuthorizerUser(_roles: "Administrador")]
        public ActionResult Delete(int id)
        {

            RolesComponent rolesComponent = new RolesComponent();
            return View(rolesComponent.ReadBy(id));
        }

        // POST: Roles/Delete/5
        //[AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                RolesComponent rolesComponent = new RolesComponent();
                rolesComponent.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ErrorPage(String id)
        {
            RolesComponent roles = new RolesComponent();
            return View(roles.ReadBy(id));
        }
        #region ABM COmposite

        public ActionResult Agregar(int id)
        {
            RolesComponent rolesComponent = new RolesComponent();

            Roles roles = new Roles();
            roles = rolesComponent.RolesDiponibles(id);

            roles.listaRol.Select(y =>
                                new
                                {
                                    y.Id,
                                    y.name
                                });

            ViewBag.ListaSedes = new SelectList(roles.listaRol, "Id", "name");

                
                
                
            return View(roles);
        }

        // POST: Roles/Create
        //[AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Agregar(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                RolesComponent rolesComponent = new RolesComponent();
                Roles roles = new Roles();
                Roles roles1 = new Roles();

                roles1.Id =int.Parse( collection.Get("name"));
                roles.Id = int.Parse(collection.Get("id"));
                roles.permiso = roles1;
                rolesComponent.CreateComposite(roles);
                return RedirectToAction("VerPermisos", new { id = int.Parse(collection.Get("id")) });

            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult DeleteComposite(int id)
        {

            RolesComponent rolesComponent = new RolesComponent();

            Roles roles = new Roles();
            roles = rolesComponent.ReadBy(id);
            roles.listaRol = rolesComponent.ObtenerPermisosORolesDeUnRol(id);

            roles.listaRol.Select(y =>
                                new
                                {
                                    y.Id,
                                    y.name
                                });

            ViewBag.ListaSedes = new SelectList(roles.listaRol, "Id", "name");
            return View(roles);
        }

        // POST: Roles/Delete/5
        //[AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult DeleteComposite(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                RolesComponent rolesComponent = new RolesComponent();
                Roles roles = new Roles();
                Roles roles1 = new Roles();
                roles1.Id = int.Parse(collection.Get("name"));
                roles.Id = int.Parse(collection.Get("id"));
                roles.permiso = roles1;
                rolesComponent.DeleteComposite(roles);
                return RedirectToAction("VerPermisos", new { id = int.Parse(collection.Get("id")) });
            }
            catch (Exception e)
            {
                return View();
            }
        }
        #endregion

    }
}
