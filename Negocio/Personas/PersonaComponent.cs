using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonaComponent : IRepository2<Persona>
    {
        public Persona Create(Persona entity)
        {
            if (Verificar(entity))
            {
                PersonaDAC personaDAC = new PersonaDAC();
                return personaDAC.Create(entity);
            }
            else
            {
                return null;
            }
      
        }

        public void Delete(int id)
        {
            PersonaDAC personaDAC = new PersonaDAC();
             personaDAC.Delete(id);
        }

        public List<Persona> Read()
        {
            PersonaDAC personaDAC = new PersonaDAC();
           List< Persona> listaPersona = new List<Persona>();
            List<Persona> result = new List<Persona>();
            listaPersona = personaDAC.Read();
            foreach (Persona item in listaPersona)
            {
                UsuariosComponent usuariosComponent = new UsuariosComponent();
                Persona persona = new Persona();
                persona = item;
                persona.usuarios = usuariosComponent.ReadBy(item.usuarios.Id);
                result.Add(persona);
            }
       



            return result;
        }

        public Persona ReadBy(int id)
        {
            Persona persona = new Persona();
            PersonaDAC personaDAC = new PersonaDAC();
            persona = personaDAC.ReadBy(id);
            UsuariosComponent usuariosComponent = new UsuariosComponent();
            persona.usuarios = usuariosComponent.ReadBy(persona.usuarios.Id);


            return persona;
        }

        public Persona ReadBy(string id)
        {
            Persona persona = new Persona();
            PersonaDAC personaDAC = new PersonaDAC();
            persona = personaDAC.ReadBy(id);
            UsuariosComponent usuariosComponent = new UsuariosComponent();
            persona.usuarios = usuariosComponent.ReadBy(persona.usuarios.Id);
              return persona;
        }

        public bool Update(Persona entity)
        {
            PersonaDAC personaDAC = new PersonaDAC();
            personaDAC.Update(entity);
            return true;
        }

        public bool Verificar(Persona entity)
        {
            if (ReadBy(entity.Id)==null)
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
