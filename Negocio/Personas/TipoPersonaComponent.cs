using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoPersonaComponent : IRepository2<TipoPersona>
    {
        public TipoPersona Create(TipoPersona entity)
        {
            if (Verificar(entity))
            {
                TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
                return tipoPersonaDAC.Create(entity);

            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
            tipoPersonaDAC.Delete(id);
        }

        public List<TipoPersona> Read()
        {
            TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
            return tipoPersonaDAC.Read();
        }

        public TipoPersona ReadBy(int id)
        {
            TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
            return tipoPersonaDAC.ReadBy(id);
        }

        public TipoPersona ReadBy(string id)
        {
            TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
            return tipoPersonaDAC.ReadBy(id);
        }

        public void Update(TipoPersona entity)
        {
            TipoPersonaDAC tipoPersonaDAC = new TipoPersonaDAC();
            tipoPersonaDAC.Update(entity);
        }

        public bool Verificar(TipoPersona entity)
        {
            if (ReadBy(entity.tipoPersona)==null)
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
