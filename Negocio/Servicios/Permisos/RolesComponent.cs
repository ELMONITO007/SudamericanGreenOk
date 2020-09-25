using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;


namespace Negocio
{
    public class RolesComponent : Component<Roles>
    {
        public override Roles Create(Roles objeto)
        {
            if (Verificar(objeto))
            {
                Roles result = default(Roles);
                var roles = new RolesDAC();
                Roles rolesBase = new Roles();
                result = roles.Create(objeto);
                rolesBase = roles.ReadBy(objeto.name);
                roles.CreateEtapa2(rolesBase);
          
                return result;
            }
            else
            {
                return null;
            }
        }

        public override void Delete(int id)
        {
            var roles = new RolesDAC();
            roles.Delete(id);
        }

        public override List<Roles> Read()
        {
            List<Roles> result = default(List<Roles>);
            var roles = new RolesDAC();
            result = roles.Read();
            return result;
        }

        public override Roles ReadBy(int id)
        {
            Roles result = default(Roles);
            var roles = new RolesDAC();

            result = roles.ReadBy(id);
            return result;
        }
        public  Roles ReadBy(string id)
        {
            Roles result = default(Roles);
            var roles = new RolesDAC();

            result = roles.ReadBy(id);
            return result;
        }
        public  Roles ReadByNombreRol(string name)
        {
            Roles result = default(Roles);
            var roles = new RolesDAC();

            result = roles.ReadByNombreRol(name);
            return result;
        }

        public override void Update(Roles objeto)
        {
         
            var roles = new RolesDAC();

          roles.Update(objeto);
          
        }

        public bool Verificar(Roles entity)

        {
            RolesDAC rolesDAC = new RolesDAC();
            Roles roles = new Roles();
            roles = rolesDAC.ReadBy(entity.name);
            if (roles is null)
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
