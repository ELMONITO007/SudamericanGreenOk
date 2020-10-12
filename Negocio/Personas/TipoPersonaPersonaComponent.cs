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
        public List<TipoPersonaPersona> Read(int id)
        {
            TipoPersonaPersonaDAC tipoPersonaPersonaDAC = new TipoPersonaPersonaDAC();
            List<TipoPersonaPersona> tipoPersonaPersonas = new List<TipoPersonaPersona>();
            List<TipoPersonaPersona> result = new List<TipoPersonaPersona>();

            tipoPersonaPersonas = tipoPersonaPersonaDAC.Read(id);
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
        public TipoPersonaPersona ObtenerTipoDisponible(int id)
        {
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
           List< TipoPersona> tipoPersonaPersonaBase = new List<TipoPersona>();
            TipoPersonaPersona result = new TipoPersonaPersona();
            TipoPersonaComponent tipoPersona = new TipoPersonaComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            
            tipoPersonaPersona.tipoPersonaPersona = Read(id);
            tipoPersonaPersonaBase = tipoPersona.Read();
            foreach (TipoPersona subItem in tipoPersonaPersonaBase)
               
            {
                TipoPersonaPersona tipo = new TipoPersonaPersona();
                int a = 0;
                foreach (TipoPersonaPersona item in tipoPersonaPersona.tipoPersonaPersona)

                {
                    tipo = item;
                    if (subItem.Id==item.tipoPersona.Id)
                    {
                        a = 1;
                    }
                }

                if (a==0)
                {
                    result.listaTipoPersona.Add(subItem);
                }

            }


            TipoPersonaPersona resultado = new TipoPersonaPersona();
            resultado.persona = personaComponent.ReadBy(id);
            foreach (TipoPersona item in result.listaTipoPersona)
            {
                TipoPersonaPersona tipo = new TipoPersonaPersona();
                tipo.tipoPersona = item;
                resultado.tipoPersonaPersona.Add(tipo);
            }

            return resultado;
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
            TipoPersonaPersona tipo = new TipoPersonaPersona();
            tipo= ReadBy(entity.persona.Id,entity.tipoPersona.Id);
            if (tipo is null)
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
