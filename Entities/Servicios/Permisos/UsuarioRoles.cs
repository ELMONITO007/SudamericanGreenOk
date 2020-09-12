using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public  class UsuarioRoles : EntityBase
    {
        public override int Id { get; set; }
        public Roles roles { get; set; }
        public Usuarios usuarios { get; set; }
        public List<Permiso> ListaPermisos { get; set; }
        public List<UsuarioRoles> listaUsuarios = new List<UsuarioRoles>();
        public List<UsuarioRoles> listaRoles = new List<UsuarioRoles>();
     
        public UsuarioRoles(Roles _roles,Usuarios _usuarios)
        {
            roles = new Roles();
            roles = _roles;
            usuarios = new Usuarios();
            usuarios = _usuarios;
            ListaPermisos = new List<Permiso>();
        }
    
    public UsuarioRoles()
        {
            roles = new Roles();
            usuarios = new Usuarios();
            ListaPermisos = new List<Permiso>();
        }
    }
}
