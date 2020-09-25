using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios.Permisos
{
    public class PermisoComponent : IRepository<Permiso>
    {

        public bool  Verificar(Permiso entity)

        {
            PermisoDAC permisoDAC = new PermisoDAC();
            Permiso permiso = new Permiso();
            permiso = permisoDAC.ReadBy(entity.name);
            if (permiso is null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Permiso Create(Permiso entity)
        {
            if (Verificar(entity))
            {
                PermisoDAC permisoDAC = new PermisoDAC();
                Permiso permiso = new Permiso();
                Permiso permisoBase = new Permiso();
                permiso = permisoDAC.Create(entity);
                permisoBase = permisoDAC.ReadBy(entity.name);
                permisoDAC.CreateEtapa2(permisoBase);
               


                return permisoBase;
            }
            else
            {
                return null;
            }

        }

        public void Delete(int id)
        {
            PermisoDAC permisoDAC = new PermisoDAC();
            permisoDAC.Delete(id);
        }

        public List<Permiso> Read()
        {
            PermisoDAC permisoDAC = new PermisoDAC();
            return permisoDAC.Read();
        }

        public Permiso ReadBy(int id)
        {
            PermisoDAC permisoDAC = new PermisoDAC();
            return permisoDAC.ReadBy(id);
        }
        public Permiso ReadBy(string id)
        {
            PermisoDAC permisoDAC = new PermisoDAC();
            return permisoDAC.ReadBy(id);
        }
        public void Update(Permiso entity)
        {
            PermisoDAC permisoDAC = new PermisoDAC();
            permisoDAC.Update(entity);
        }
    }
}
