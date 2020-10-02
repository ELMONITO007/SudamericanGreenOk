using Data;
using Entities;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Negocio.Servicios
{
  public  class BackupComponent : IRepository<Backups>
    {
        public static void BackupDatabase(Backups backup)
        {

            Entities.Backups backupRestore = new Entities.Backups();
            BackupDAC backupDAC = new BackupDAC();
            backupRestore = backup;
            backupRestore.Path= HostingEnvironment.MapPath("~/Backup/" + backup.Nombre + "/.bak");
            backupDAC.CreateBackup(backupRestore);

        }

        public void RestaurarBase()
        {
            Entities.Backups backupRestore = new Entities.Backups();
            BackupDAC backupDAC = new BackupDAC();
            backupRestore = backupDAC.ReadBy();
            RestoreDatabase(backupRestore);


        }


        public  void RestoreDatabase(Backups backup)
        {
            Entities.Backups backupRestore = new Entities.Backups();
            BackupDAC backupDAC = new BackupDAC();
            backupRestore = backup;
            backupRestore.Path = HostingEnvironment.MapPath("~/Backup/" + backup.Nombre + "/.bak");
            backupDAC.Restore(backupRestore);
        }

        public Backups Create(Backups entity)
        {
            BackupDatabase(entity);
            entity.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            entity.Nombre = "Backup-" + entity.Fecha;
            BackupDatabase(entity);
            BackupDAC backupDAC = new BackupDAC();
            Entities.Backups backups = new Backups();
            backups = backupDAC.Create(entity);
            BackupDatabase(entity);
              
            return backups;
        }
        public Backups Create()
        {
            Backups entity = new Backups();
            entity.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            entity.Nombre = "Backup-" + entity.Fecha;
            BackupDAC backupDAC = new BackupDAC();
            return backupDAC.Create(entity);
        }
        public void Delete(int id)
        {
            BackupDAC backupDAC = new BackupDAC();
            backupDAC.Delete(id);
        }

        public List<Backups> Read()
        {
            BackupDAC backupDAC = new BackupDAC();
            return backupDAC.Read();
        }

        public Backups ReadBy(int id)
        {
            BackupDAC backupDAC = new BackupDAC();
            return backupDAC.ReadBy(id);
        }

        public void Update(Backups entity)
        {
            throw new NotImplementedException();
        }
    }
}
