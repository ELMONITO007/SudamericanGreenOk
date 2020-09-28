using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using Negocio.Servicios.Permisos;

namespace Negocio
{
    public class UsuarioRolesComponent : Component<UsuarioRoles>
    {
        public override UsuarioRoles Create(UsuarioRoles objeto)
        {
            UsuarioRoles result = default(UsuarioRoles);
            var  usuarioRolesDAC= new UsuarioRolesDAC();

            result = usuarioRolesDAC.Create(objeto);
            return result;
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public  void Delete(UsuarioRoles objeto)
        {
            var usuarioRolesDAC = new UsuarioRolesDAC();
            usuarioRolesDAC.Delete(objeto);
        }

        public override List<UsuarioRoles> Read()
        {

            List<UsuarioRoles> result = default(List<UsuarioRoles>);
            var usuarioRolesDAC = new UsuarioRolesDAC();
            result = usuarioRolesDAC.Read();
            return result;
        }

        public override UsuarioRoles ReadBy(int id)
        {
            throw new NotImplementedException();
        }
        public  UsuarioRoles ReadBy(int id_role, int id_Usuario)
        {
            UsuarioRoles result = default(UsuarioRoles);
            var usuarioRolesDAC = new UsuarioRolesDAC();
            result = usuarioRolesDAC.ReadBy(id_role);
            return result;
        }
        public List< UsuarioRoles> ReadByUsuario(int id_Usuario)
        {
            List<UsuarioRoles> result = default(List<UsuarioRoles>);
            var usuarioRolesDAC = new UsuarioRolesDAC();
            List<UsuarioRoles> roles =new List<UsuarioRoles>();

            result = usuarioRolesDAC.ReadByUsuario(id_Usuario);
            foreach (var item in result)
            {
                UsuarioRoles roles1 = new UsuarioRoles();
                             UsuariosComponent usuarios = new UsuariosComponent();
               
                RolesDAC rolesDAC = new RolesDAC();

                if (rolesDAC.VerificarSiEsUnPermiso(item.roles.Id) != null)
                {
                    roles1.Id = 1;
                    PermisoComponent permisoComponent = new PermisoComponent();
                    roles1.roles = permisoComponent.ReadBy(item.roles.Id);
                }
                else
                {
                    RolesComponent rolesComponent = new RolesComponent();
                    roles1.roles = rolesComponent.ReadBy(item.roles.Id);
                    roles1.Id = 0;

                }
                roles1.usuarios = usuarios.ReadBy(item.usuarios.Id);
               

                

                roles.Add(roles1);
            }
            return roles;
        }
        public List<UsuarioRoles> ReadByRoles(int id_Roles)
        {
            List<UsuarioRoles> result = default(List<UsuarioRoles>);
            var usuarioRolesDAC = new UsuarioRolesDAC();
            result = usuarioRolesDAC.ReadByRol(id_Roles);
            return result;
        }
        public override void Update(UsuarioRoles objeto)
        {
            var usuarioRolesDAC = new UsuarioRolesDAC();
           
            
            usuarioRolesDAC.Update(objeto);
        }

        public List<UsuarioRoles> obtenerRolesDisponiblesDelUsuario(int id_Usuario)
        {

            RolesComponent rolesComponent = new RolesComponent();
            List<Roles> roles = new List<Roles>();
            roles = rolesComponent.Read();

            PermisoComponent permisoComponent = new PermisoComponent();
            List<Permiso> permisos = new List<Permiso>();
            permisos = permisoComponent.Read();

            roles.AddRange(permisos);

            List<UsuarioRoles> usuarioRoles = new List<UsuarioRoles>();
            usuarioRoles = ReadByUsuario(id_Usuario);
            List<UsuarioRoles> result = new List<UsuarioRoles>();


            foreach (Roles item in roles)
            {
                int aux = 0;

                foreach (UsuarioRoles itemRoles in usuarioRoles)
                {
                    if (item.Id==itemRoles.roles.Id)
                    {
                        aux = 1;
                        break;
                    }

                }
                if (aux==0)
                {
                    UsuarioRoles usuario = new UsuarioRoles();
                    usuario.roles = item;
                    result.Add(usuario);
                }


            }


            return result;


        }







        public  bool VerificarSiTieneElRol(Usuarios usuarios,List<Roles> roles)


        {
            bool aux = false;
            if (usuarios is null)
            {
                aux = false;
            }
            else
            {

           
            Usuarios unUsuario = new Usuarios();
            UsuarioDac usuarioDac = new UsuarioDac();
            unUsuario = usuarioDac.ReadByEmail(usuarios.Email);
            List<UsuarioRoles> usuarioRoles = new List<UsuarioRoles>();
            usuarioRoles = obtenerRolesDisponiblesDelUsuario(unUsuario.Id);
          
            if (usuarioRoles.Count == 0)
            {
                aux = false;
            }
            else
            {

           
              foreach (Roles item in roles)
              {

                    if (aux)
                    {
                        break;
                    }
                foreach (UsuarioRoles subItem in usuarioRoles)
                {
                        if (subItem.roles.name==item.name)
                        {
                            aux = true;
                            break;
                        }

                }

              }
            }
            }

            return aux;


        }


    }
}
