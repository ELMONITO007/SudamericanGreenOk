using Data;
using Entities;
using Negocio.Personas;
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
                //agregar Usuario

                Usuarios usuarios = new Usuarios();
                UsuariosComponent usuariosComponent = new UsuariosComponent();
                usuarios = entity.usuarios;
                usuarios.Email = entity.email;
                usuarios.UserName = entity.email;
                usuariosComponent.Crear(usuarios);
                //Crear persona
                PersonaDAC personaDAC = new PersonaDAC();
                Persona persona = new Persona();
                entity.usuarios = usuariosComponent.ReadByEmail(entity.email);   
                persona = personaDAC.Create(entity);


                //Agrega tipo Persona
                TipoPersonaPersonaComponent tipoPersonaPersonaComponent = new TipoPersonaPersonaComponent();
                TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
                tipoPersonaPersona.persona.Id = entity.Id;
                tipoPersonaPersona.tipoPersona.Id = entity.tipoPersona.Id;
                tipoPersonaPersonaComponent.Create(tipoPersonaPersona);



                //Agrega Direccion
                DireccionComponent direccionComponent = new DireccionComponent();
                direccionComponent.Create(entity.Direccion);

                //Asiganar direccion al usuario
                DireccionPersona direccionPersona = new DireccionPersona();
                direccionPersona.direccion = direccionComponent.ReadBy(entity.Direccion);
                direccionPersona.persona.Id = entity.Id;
                DireccionPersonaComponent direccion = new DireccionPersonaComponent();
                direccion.Create(direccionPersona);


            


                return persona;
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

        public Persona ObtenerTipoPersonaDiponible(int id)
        {
            Persona persona = new Persona();
            PersonaDAC tipoPersonaDAC = new PersonaDAC();
            List<TipoPersona> tipoPersonasBase = new List<TipoPersona>();
            List<TipoPersonaPersona> tipoPersonaPersonas = new List<TipoPersonaPersona>();
        TipoPersonaPersonaComponent tipoPersonaPersonaComponent = new TipoPersonaPersonaComponent();
            TipoPersonaComponent tipoPersonaComponent = new TipoPersonaComponent();
            tipoPersonasBase = tipoPersonaComponent.Read();
            tipoPersonaPersonas = tipoPersonaPersonaComponent.Read(id);
            persona = tipoPersonaDAC.ReadBy(id);
            foreach (TipoPersona item in tipoPersonasBase)
            {
                int a = 0;
                foreach (TipoPersonaPersona subItem in tipoPersonaPersonas)
                {
                    if (subItem.tipoPersona.Id==item.Id)
                    {
                        a = 1;
                    }


                }
                if (a==0)
                {
                    persona.listaTipoPersona.Add(item);
                }
            }



            return persona;
        
        
        }
        public Persona ReadBy(int id)
        {
            Persona persona = new Persona();
            PersonaDAC personaDAC = new PersonaDAC();
            persona = personaDAC.ReadBy(id);
            UsuariosComponent usuariosComponent = new UsuariosComponent();
            
                
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
