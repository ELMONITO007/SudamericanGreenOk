using Entities;
using Evaluaciones_Tecnicas.Filter;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluaciones_Tecnicas.Controllers.Servicios
{
    public class BackupController : Controller
    {
        [AuthorizerUser(_roles: "Administrador")]
        // GET: Backup
        public ActionResult Index()
        {
            BackupComponent backupComponent = new BackupComponent();
            return View(backupComponent.Read());
        }
        [AuthorizerUser(_roles: "Administrador")]
        // GET: Backup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [AuthorizerUser(_roles: "Administrador")]
        // GET: Backup/Create
        public ActionResult Create()
        {
            BackupComponent backupComponent = new BackupComponent();
            backupComponent.Create();
            return RedirectToAction("index");
        }
        [AuthorizerUser(_roles: "Administrador")]
        // POST: Backup/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BackupComponent backupComponent = new BackupComponent();
                backupComponent.Create();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        // GET: Backup/Edit/5
        public ActionResult Restore(int id)
        {
            BackupComponent backupComponent = new BackupComponent();
            return View(backupComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        // POST: Backup/Edit/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Backups backups = new Backups();
                backups.Nombre = collection.Get("Nombre");
                BackupComponent.RestoreDatabase(backups);
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AuthorizerUser(_roles: "Administrador")]
        // GET: Backup/Delete/5
        public ActionResult Delete(int id)
        {
            BackupComponent backupComponent = new BackupComponent();
            return View(backupComponent.ReadBy(id));
        }
        [AuthorizerUser(_roles: "Administrador")]
        // POST: Backup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                BackupComponent backupComponent = new BackupComponent();
                backupComponent.Delete(id);
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
