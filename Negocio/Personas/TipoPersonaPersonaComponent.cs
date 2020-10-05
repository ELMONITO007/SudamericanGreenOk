using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Negocio.Personas
{
    public class TipoPersonaPersonaComponent : IRepository2<TipoPersonaPersona>
    {
        public TipoPersonaPersona Create(TipoPersonaPersona entity)
        {
            if (Verificar(entity))
            {
                TipoPersonaPersonaDAC tipoPersonaPersonaDAC = new TipoPersonaPersonaDAC();
                return tipoPersonaPersonaDAC.Create(entity);
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, int TipoPersona)
        {

            TipoPersonaPersonaDAC tipoPersonaPersonaDAC = new TipoPersonaPersonaDAC();
             tipoPersonaPersonaDAC.Delete(id,TipoPersona);
        }
        public List<TipoPersonaPersona> Read()
        {
            TipoPersonaPersonaDAC tipoPersonaPersonaDAC = new TipoPersonaPersonaDAC();
            List<TipoPersonaPersona> tipoPersonaPersonas = new List<TipoPersonaPersona>();
            List<TipoPersonaPersona> result = new List<TipoPersonaPersona>();

            tipoPersonaPersonas = tipoPersonaPersonaDAC.Read();
            foreach (TipoPersonaPersona item in tipoPersonaPersonas)
            {
                TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
                PersonaComponent personaComponent = new PersonaComponent();
                TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
                tipoPersonaPersona.tipoPersona = tipoPersonaComponent.ReadBy(item.tipoPersona.Id);
                tipoPersonaPersona.persona = personaComponent.ReadBy(item.persona.Id);
                result.Add(tipoPersonaPersona);

            }



            return result;
        }

        public TipoPersonaPersona ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPersonaPersona ReadBy(string id)
        {
            throw new NotImplementedException();
        }

        public TipoPersonaPersona ReadBy(int id,int tp)
        {
            TipoPersonaPersonaDAC tipoPersonaPersonaDAC = new TipoPersonaPersonaDAC();
        
            return tipoPersonaPersonaDAC.ReadBy(id, tp);

        }

        public bool Update(TipoPersonaPersona entity)
        {

            throw new NotImplementedException();
        }

        public bool Verificar(TipoPersonaPersona entity)
        {
            if (ReadBy(entity.persona.Id,entity.tipoPersona.Id)is null)
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
