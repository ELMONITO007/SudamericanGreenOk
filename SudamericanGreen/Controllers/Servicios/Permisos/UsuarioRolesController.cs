using Evaluaciones.Models;
using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluaciones_Tecnicas.Filter;
using Negocio.Servicios.Permisos;

namespace Evaluaciones.Controllers
{
   [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class UsuarioRolesController : Controller
    {
        // GET: UsuarioRoles
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Index(int id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
          UsuarioRoles usuarioRoles = new UsuarioRoles();
            usuarioRoles.listaRoles = usuarioRolesComponent.ReadByUsuario(id);
            UsuariosComponent usuarios = new UsuariosComponent();
            usuarioRoles.usuarios = usuarios.ReadBy(id);
            return View(usuarioRoles);
        }

        // GET: UsuarioRoles/Details/5
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Details(int id,string idRol)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Usuario (int Id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadByUsuario(Id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Roles(int Id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadByRoles(Id));
        }

        // GET: UsuarioRoles/Create
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Create(int id)
        {
            UsuarioRoles roles = new UsuarioRoles();
            UsuarioRolesComponent usuarioRoles = new UsuarioRolesComponent();

            roles.listaRoles = usuarioRoles.obtenerRolesDisponiblesDelUsuario(id);
            roles.listaRoles.Select(y =>
                            new
                            {
                                y.roles.id,
                                    y.roles.name
                            });

            ViewBag.RolesLista = new SelectList(roles.listaRoles, "roles.id", "roles.name");

            UsuariosComponent usuarios = new UsuariosComponent();
            roles.usuarios = usuarios.ReadBy(id);


            return View(roles);
        }

        // POST: UsuarioRoles/Create
        [AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
                UsuarioRoles usuarioRoles = new UsuarioRoles();
                usuarioRoles.roles.id = collection.Get("roles.name");
                usuarioRoles.usuarios.Id =int.Parse( collection.Get("usuarios.Id"));
                usuarioRolesComponent.Create(usuarioRoles);
                // TODO: Add insert logic here

                return RedirectToAction("Index",new { id = usuarioRoles.usuarios.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: UsuarioRoles/Edit/5
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Edit(int id_Usuario, int id_Roles)
        {
            try
            {
                UsuarioRolesModels usuarioRoles = new UsuarioRolesModels();
                List<UsuarioRolesModels> result = new List<UsuarioRolesModels>();
                result = usuarioRoles.obtenerRolesDisponiblesDelUsuario(id_Usuario);
                result.Select(y =>
                                new
                                {
                                    id_Rol = y.id_Rol,
                                    name = y.name
                                });

                ViewBag.RolesLista = new SelectList(result, "id_Rol", "name");
                    

                return View(usuarioRoles.ReadBy(id_Roles, id_Usuario));
            }
            catch (Exception e)
            {

                throw;
            }
          
        }

        // POST: UsuarioRoles/Edit/5
        [AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
                UsuarioRoles usuario = new UsuarioRoles();
                usuario.roles.id = collection.Get("id_Rol");
                usuario.usuarios.Id =int.Parse( collection.Get("id_Usuario"));
                usuarioRolesComponent.Update(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioRoles/Delete/5
        [AuthorizerUser(_roles: "Administrador")]
        public ActionResult Delete(int id_Usuario, int id_Roles)
        {
            UsuarioRoles usuarioRoles = new UsuarioRoles();
            UsuariosComponent usuarios = new UsuariosComponent();
            RolesComponent rolesComponent = new RolesComponent();
            
            if (rolesComponent.ReadBy(id_Roles) is null)
            {
                PermisoComponent permisoComponent = new PermisoComponent();
                usuarioRoles.roles = permisoComponent.ReadBy(id_Roles);
            }
            else
            {
                usuarioRoles.roles = rolesComponent.ReadBy(id_Roles);
            }
            usuarioRoles.usuarios = usuarios.ReadBy(id_Usuario);

            return View(usuarioRoles);
        }

        // POST: UsuarioRoles/Delete/5
        [AuthorizerUser(_roles: "Administrador")]
        [HttpPost]
        public ActionResult Delete( FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UsuarioRoles roles = new UsuarioRoles();
                UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
                roles.usuarios.Id = int.Parse(collection.Get("usuarios.Id"));
                roles.roles.Id = int.Parse(collection.Get("roles.Id"));
                usuarioRolesComponent.Delete(roles);
                return RedirectToAction("Index",new { id=roles.usuarios.Id});
            }
            catch
            {
                return View();
            }
        }
    }
}
