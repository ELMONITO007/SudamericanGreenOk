﻿using Evaluaciones.Models;
using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluaciones_Tecnicas.Filter;

namespace Evaluaciones.Controllers
{
    //[Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class UsuarioRolesController : Controller
    {
        // GET: UsuarioRoles
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        public ActionResult Index(int id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            List<UsuarioRoles> usuarioRoles = new List<UsuarioRoles>();
            usuarioRoles = usuarioRolesComponent.ReadByUsuario(id);
            

            return View(usuarioRoles);
        }

        // GET: UsuarioRoles/Details/5
        /* [AuthorizerUser(_roles: "Administrador,RRHH")]*/
        public ActionResult Details(int id,string idRol)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadBy(id));
        }

        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        public ActionResult Usuario (int Id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadByUsuario(Id));
        }
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        public ActionResult Roles(int Id)
        {
            UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
            return View(usuarioRolesComponent.ReadByRoles(Id));
        }

        // GET: UsuarioRoles/Create
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        public ActionResult Create(int id)
        {
            UsuarioRolesModels usuarioRoles = new UsuarioRolesModels();
            List<UsuarioRolesModels> result = new List<UsuarioRolesModels>();
            result = usuarioRoles.obtenerRolesDisponiblesDelUsuario(id);
            result.Select(y =>
                            new
                            {
                                id_Rol = y.id_Rol,
                                name = y.name
                            });

            ViewBag.RolesLista = new SelectList(result, "id_Rol", "name");




            return View(usuarioRoles.ReadyBy(id));
        }

        // POST: UsuarioRoles/Create
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UsuarioRolesComponent usuarioRolesComponent = new UsuarioRolesComponent();
                UsuarioRoles usuarioRoles = new UsuarioRoles();
                usuarioRoles.roles.id = collection.Get("id_Rol");
                usuarioRoles.usuarios.Id =int.Parse( collection.Get("id_Usuario"));
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
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
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
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
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
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
        public ActionResult Delete(string id_Usuario, String id_Roles)
        {
            return View();
        }

        // POST: UsuarioRoles/Delete/5
        //[AuthorizerUser(_roles: "Administrador,RRHH")]
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
