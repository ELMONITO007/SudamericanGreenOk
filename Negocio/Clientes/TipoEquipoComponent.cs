using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
namespace Negocio
{
    public class TipoEquipoComponent : IRepository2<TipoEquipo>
    {
        public TipoEquipo Create(TipoEquipo entity)
        {

            if (Verificar(entity))
            {
                TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
                return tipoEquipo.Create(entity);

            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
            tipoEquipo.Delete(id);
        }

        public List<TipoEquipo> Read()
        {
            TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
            return tipoEquipo.Read();
        }

        public TipoEquipo ReadBy(int id)
        {
            TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
            return tipoEquipo.ReadBy(id);
        }

        public TipoEquipo ReadBy(string id)
        {
            TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
            return tipoEquipo.ReadBy(id);
        }

        public bool Update(TipoEquipo entity)
        {

            if (Verificar(entity))
            {
                TipoEquipoDAC tipoEquipo = new TipoEquipoDAC();
                tipoEquipo.Update(entity);
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Verificar(TipoEquipo entity)
        {
            if (ReadBy(entity.tipoEquipo) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}