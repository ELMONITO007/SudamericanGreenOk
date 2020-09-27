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


        #region Composite
        public List<Roles> ObtenerPermisosORolesDeUnRol(int id)
        {
            RolesDAC rolesDAC = new RolesDAC();
            return rolesDAC.ObtenerPermisosORolesDeUnRol(id);


        }
        public Roles ObtenerComposite(Roles entity)
        {
            Roles roles = new Roles();
            RolesDAC rolesDAC = new RolesDAC();
            roles = entity;
            
            foreach (Roles item in ObtenerPermisosORolesDeUnRol(entity.Id))
            {

                if (rolesDAC.VerificarSiEsUnPermiso(item.Id)!=null)
                {
                    roles.listaRol.Add(item);
                }
                else if (rolesDAC.VerificarSiEsUnRol(item.Id) !=null)
                {
                    Roles roles1 = new Roles();
                    roles1 = ObtenerComposite(item);
                    roles.listaRol.Add(roles1);
                }
              

            }

            

            return roles;
        
        
        }

        #endregion

        #region ABM Composite

        public Roles CreateComposite(Roles entity)
        {
            RolesDAC rolesDAC = new RolesDAC();
            return rolesDAC.CreateComposite(entity);

        }

        public void UpdateComposite(Roles entity, Roles update)
        {
            RolesDAC rolesDAC = new RolesDAC();
            rolesDAC.UpdateComposite(entity, update);
        }
        public void DeleteComposite(Roles entity)
        {
            RolesDAC rolesDAC = new RolesDAC();
            rolesDAC.DeleteComposite(entity);
        }


        public Roles RolesDiponibles(int id)
        {
            Roles roles = new Roles();
            RolesDAC rolesDAC = new RolesDAC();
            roles = rolesDAC.ReadBy(id);
            Roles rolesBase = new Roles();
            PermisoDAC permisoDAC = new PermisoDAC();

            rolesBase.listaRol = rolesDAC.Read();
            rolesBase.listaRol.AddRange(permisoDAC.Read());


            Roles result = new Roles();
            result= rolesDAC.ReadBy(id);
            roles.listaRol = ObtenerPermisosORolesDeUnRol(id);
            


            foreach (Roles item in rolesBase.listaRol)
            {
                int a = 0;

                foreach (Roles subItem in roles.listaRol)
                {
                    if (subItem.Id==item.Id)
                    {
                        a = 1;
                    }
                   
                }
                if (result.Id ==item.Id)
                {
                    a = 1;
                }
                if (a==0)
                {
                    result.listaRol.Add(item);
                }


            }


            return result;

        }
 
        #endregion
    }
}
