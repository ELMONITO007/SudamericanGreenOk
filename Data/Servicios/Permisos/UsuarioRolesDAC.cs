using Microsoft.Practices.EnterpriseLibrary.Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsuarioRolesDAC : DataAccessComponent, IRepository<UsuarioRoles>
    {
        private UsuarioRoles LoadUsuarioRoles(IDataReader dr)
        {
            try
            {
                UsuarioRoles usuarioRoles = new UsuarioRoles();
                usuarioRoles.usuarios.Id = GetDataValue<int>(dr, "UserId");
                usuarioRoles.roles.Id = GetDataValue<int>(dr, "RoleId");
          


 
    
                return usuarioRoles;
            }
            catch (Exception e)
            {

                throw;
            }
  
        }

        
        public UsuarioRoles Create(UsuarioRoles entity)
        {
            const string SQL_STATEMENT = "insert into AspNetUserRoles(RoleId,UserId)values(@RoleId, @UserId) ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId", DbType.Int32, entity.usuarios.Id);
                db.AddInParameter(cmd, "@RoleId", DbType.String, entity.roles.id);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }
    

        public void Delete(UsuarioRoles entity)
        {
            const string SQL_STATEMENT = "delete from AspNetUserRoles where UserId=@UserId and RoleId=@RoleId";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, entity.usuarios.Id);
                db.AddInParameter(cmd, "@UserId", DbType.String, entity.roles.id);
                db.ExecuteNonQuery(cmd);
            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioRoles> Read()
        {
            const string SQL_STATEMENT = "select * from AspNetUserRoles where activo=1";

            List<UsuarioRoles> result = new List<UsuarioRoles>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UsuarioRoles usuarioRoles = LoadUsuarioRoles(dr);
                        result.Add(usuarioRoles);
                    }
                }
            }
            return result;
        }

        public UsuarioRoles ReadBy(int id)
        {

            const string SQL_STATEMENT = "select * from AspNetUserRoles where UserId=1";
           

            UsuarioRoles roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, id);
               
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadUsuarioRoles(dr);
                    }
                }
            }
            return roles;
        }

     
   

      
        public List<UsuarioRoles> ReadByRol(int Id_roles)
        {
            const string SQL_STATEMENT = "select * from AspNetUserRoles where RoleId=@RoleId";
            List<UsuarioRoles> result = new List<UsuarioRoles>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, Id_roles);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UsuarioRoles usuarioRoles = LoadUsuarioRoles(dr);
                        result.Add(usuarioRoles);
                    }
                }
            }
            return result;
        }
        public List<UsuarioRoles> ReadByUsuario(int ID_Usuario)
        {
            const string SQL_STATEMENT = "select * from AspNetUserRoles where UserId=@RoleId";
            List<UsuarioRoles> result = new List<UsuarioRoles>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@RoleId", DbType.Int32, ID_Usuario);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UsuarioRoles usuarioRoles = LoadUsuarioRoles(dr);
                        result.Add(usuarioRoles);
                    }
                }
            }
            return result;
        }
        public void Update(UsuarioRoles entity)
        {
            const string SQL_STATEMENT = "update AspNetUserRoles set RoleId=@RoleId where RoleId=@RoleId and UserId=@UserId ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId ", DbType.Int32, entity.usuarios.Id);
                db.AddInParameter(cmd, "@RoleId", DbType.String, entity.roles.id);
               
            }

        }

        public UsuarioRoles ReadBy(string id)
        {
            throw new NotImplementedException();
        }
    }
}
