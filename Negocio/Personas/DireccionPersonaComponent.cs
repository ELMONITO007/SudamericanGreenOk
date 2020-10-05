using Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DireccionPersonaComponent : IRepository2<DireccionPersona>
    {
        public DireccionPersona Create(DireccionPersona entity)
        {
            if (Verificar(entity))
            {
                DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
                return direccionPersonaDAC.Create(entity);
            }
            else
            {
                return null;
            }

       
        }

        public void Delete(int id)
        {
            DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
             direccionPersonaDAC.Delete(id);
        }

        public void Delete(int dni, int direccion)
        {
            DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
            direccionPersonaDAC.Delete(dni,direccion);
        }
        public List<DireccionPersona> Read()
        {

            DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
           List<DireccionPersona> direccionPersona = new List<DireccionPersona>();
            List<DireccionPersona> result = new List<DireccionPersona>();
            direccionPersona = direccionPersonaDAC.Read();
            foreach (DireccionPersona item in direccionPersona)
            {
                DireccionPersona direccion = new DireccionPersona();
                DireccionComponent direccionComponent = new DireccionComponent();
                PersonaComponent personaComponent = new PersonaComponent();
                direccion.persona = personaComponent.ReadBy(item.persona.Id);
                direccion.direccion = direccionComponent.ReadBy(item.direccion.Id);
                result.Add(direccion);


            }

            return result;
        }


        public List<DireccionPersona> ReadByPersona(int dni)
        {

            DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
            List<DireccionPersona> direccionPersona = new List<DireccionPersona>();
            List<DireccionPersona> result = new List<DireccionPersona>();
            direccionPersona = direccionPersonaDAC.ReadByPersona(dni);
            foreach (DireccionPersona item in direccionPersona)
            {
                DireccionPersona direccion = new DireccionPersona();
                DireccionComponent direccionComponent = new DireccionComponent();
                PersonaComponent personaComponent = new PersonaComponent();
                direccion.persona = personaComponent.ReadBy(item.persona.Id);
                direccion.direccion = direccionComponent.ReadBy(item.direccion.Id);
                result.Add(direccion);


            }

            return result;
        }
            public DireccionPersona ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public DireccionPersona ReadBy(string id)
        {
            throw new NotImplementedException();
        }
        public DireccionPersona ReadBy(int id,int direccion)
        {
            DireccionPersonaDAC direccionPersonaDAC = new DireccionPersonaDAC();
            DireccionPersona direccionPersona = new DireccionPersona();
            direccionPersona = direccionPersonaDAC.ReadBy(id,direccion);
            DireccionComponent direccionComponent = new DireccionComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            if (direccionPersona is null)
            {
                return null;
            }
            else
            {
                direccionPersona.persona = personaComponent.ReadBy(id);
                direccionPersona.direccion = direccionComponent.ReadBy(direccion);
                return direccionPersona;
            }
        
        }
        public bool Update(DireccionPersona entity)
        {
            throw new NotImplementedException();
        }

        public bool Verificar(DireccionPersona entity)
        {
            if (ReadBy(entity.persona.Id,entity.direccion.Id) is null)
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
