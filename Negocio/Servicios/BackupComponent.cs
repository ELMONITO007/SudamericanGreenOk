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

namespace Negocio.Servicios
{
  public  class BackupComponent : IRepository<Backups>
    {
        public static void BackupDatabase(Backups backup)
        {

            ServerConnection con = new ServerConnection(@"DESKTOP-VDU4AC0\SQLEXPRESS02");
            Server server = new Server(con);
            Backup source = new Backup();
            source.Action = BackupActionType.Database;
            source.Database = "GreenElectric";
            string backUpFile = backup.Nombre;
            BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
            source.Devices.Add(destination);
            source.SqlBackup(server);
            con.Disconnect();
        }

        public static void RestoreDatabase(Backups backup)
        {
            ServerConnection con = new ServerConnection(@"DESKTOP-VDU4AC0\SQLEXPRESS02");
            Server server = new Server(con);
            Restore destination = new Restore();
            destination.Action = RestoreActionType.Database;
            destination.Database = "GreenElectric";
            BackupDeviceItem source = new BackupDeviceItem(backup.Nombre, DeviceType.File);
            destination.Devices.Add(source);
            destination.ReplaceDatabase = true;
            destination.SqlRestore(server);
            con.Disconnect();
        }

        public Backups Create(Backups entity)
        {
            BackupDatabase(entity);
            entity.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            entity.Nombre = "Backup-" + entity.Fecha;
            BackupDatabase(entity);
            BackupDAC backupDAC = new BackupDAC();
            return backupDAC.Create(entity);
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
