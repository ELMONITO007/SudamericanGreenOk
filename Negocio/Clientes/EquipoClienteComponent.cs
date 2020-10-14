using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Negocio
{
    public class EquipoClienteComponent : IRepository2<EquipoCliente>
    {
        public EquipoCliente Create(EquipoCliente entity)
        {
            if (Verificar(entity))
            {
                EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
                return equipoClienteDAC.Create(entity);

            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
            equipoClienteDAC.Delete(id);
        }

        public List<EquipoCliente> Read()
        {
            EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
            List<EquipoCliente> equipoClientes = new List<EquipoCliente>();
            equipoClientes = equipoClienteDAC.Read();
            List<EquipoCliente> result = new List<EquipoCliente>();

            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            MarcaComponent marcaComponent = new MarcaComponent();
            foreach (EquipoCliente item in equipoClientes)
            {
                EquipoCliente equipoCliente = new EquipoCliente();
                equipoCliente = item;
                equipoCliente.persona = personaComponent.ReadBy(item.persona.Id);
                equipoCliente.marca = marcaComponent.ReadBy(item.marca.Id);
                equipoCliente.tipoEquipo = tipoEquipoComponent.ReadBy(item.tipoEquipo.Id);

                result.Add(equipoCliente);

            }


            return result;
        }

        public EquipoCliente ReadBy(int id)
        {
            EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
            EquipoCliente equipoCliente = new EquipoCliente();
            equipoCliente = equipoClienteDAC.ReadBy(id);
           
            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            MarcaComponent marcaComponent = new MarcaComponent();
           
               
                equipoCliente.persona = personaComponent.ReadBy(equipoCliente.persona.Id);
                equipoCliente.marca = marcaComponent.ReadBy(equipoCliente.marca.Id);
                equipoCliente.tipoEquipo = tipoEquipoComponent.ReadBy(equipoCliente.tipoEquipo.Id);

            


            return equipoCliente;
        }

        public EquipoCliente ReadBy(string id)
        {

            EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
            EquipoCliente equipoCliente = new EquipoCliente();
            equipoCliente = equipoClienteDAC.ReadBy(id);

            TipoEquipoComponent tipoEquipoComponent = new TipoEquipoComponent();
            PersonaComponent personaComponent = new PersonaComponent();
            MarcaComponent marcaComponent = new MarcaComponent();


            equipoCliente.persona = personaComponent.ReadBy(equipoCliente.persona.Id);
            equipoCliente.marca = marcaComponent.ReadBy(equipoCliente.marca.Id);
            equipoCliente.tipoEquipo = tipoEquipoComponent.ReadBy(equipoCliente.tipoEquipo.Id);




            return equipoCliente;
        }

        public bool Update(EquipoCliente entity)
        {
            if (Verificar(entity))
            {
                EquipoClienteDAC equipoClienteDAC = new EquipoClienteDAC();
                equipoClienteDAC.Update(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Verificar(EquipoCliente entity)
        {
            if (ReadBy(entity.serial)==null)
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
