using Microsoft.Practices.EnterpriseLibrary.Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Data
{
    public class RolesDAC : DataAccessComponent, IRepository<Roles>
    {
        private Roles LoadRoles(IDataReader dr)
        {
            Roles roles = new Roles();
            roles.Id = GetDataValue<int>(dr, "Id");
            roles.name = GetDataValue<string>(dr, "name");   
            return roles;
        }

      

        public Roles Create(Roles entity)
        {
            const string SQL_STATEMENT = "insert into AspNetRoles(name,activo)values(@name,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@name", DbType.String, entity.name);
             
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }
        public Roles CreateEtapa2(Roles entity)
        {
            const string SQL_STATEMENT = "insert into RolesComposite(ID_CompositeRol)values(@ID_CompositeRol)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ID_CompositeRol", DbType.Int32, entity.Id);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update AspNetRoles set Activo=0 where id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
      

        public List<Roles> Read()
        {
            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositeRol where ID_CompositeRol   is not null and activo=1";

            List<Roles> result = new List<Roles>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Roles roles = LoadRoles(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Roles ReadBy(int id)
        {
            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositeRol where ID_CompositeRol   is not null and activo=1 and id=@Id";
            Roles    roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRoles(dr);
                    }
                }
            }
            return roles;
        }
        public Roles ReadBy(string id)
        {
            const string SQL_STATEMENT = "select   * from AspNetRoles where Name=@Id and activo=1";
            Roles roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRoles(dr);
                    }
                }
            }
            return roles;
        }


        public Roles ReadByNombreRol(string nombreRol)
        {
            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositeRol where ID_CompositeRol   is not null and activo=1 and name=@Id";
            Roles roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, nombreRol);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRoles(dr);
                    }
                }
            }
            return roles;
        }

        public void Update(Roles entity)
        {
            const string SQL_STATEMENT = "update AspNetRoles set name=@name where id=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, entity.id);
                db.AddInParameter(cmd, "@name", DbType.String, entity.name);
              
                db.ExecuteNonQuery(cmd);
            }
        }



        #region Composite
        private Roles LoadRolesComposite(IDataReader dr)
        {
            Roles roles = new Roles();
            roles.Id = GetDataValue<int>(dr, "ID_CompositePermiso");
            roles.name = GetDataValue<string>(dr, "name");
            return roles;
        }
        private Roles LoadRolesCompositeRol(IDataReader dr)
        {
            Roles roles = new Roles();
            roles.Id = GetDataValue<int>(dr, "ID_CompositeRol");
            roles.name = GetDataValue<string>(dr, "name");
            return roles;
        }
        public List<Roles> ObtenerPermisosORolesDeUnRol(int id)
        {
            const string SQL_STATEMENT = "select * from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositePermiso where activo=1 and ID_CompositeRol=@Id";
           List<Roles> roles = new List<Roles>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Roles roles1 = new Roles();
                        roles1 = LoadRolesComposite(dr);
                        roles.Add(roles1);
                    }
                }
            }
            return roles;
        }

        public Roles VerificarSiEsUnPermiso(int id)
        {
            const string SQL_STATEMENT = "select ID_CompositePermiso,a.Name from RolesComposite as rc join AspNetRoles as a on a.Id=rc.ID_CompositePermiso where ID_CompositeRol is null and ID_CompositePermiso=@Id and Activo=1";
            Roles roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRolesComposite(dr);
                    }
                }
            }
            return roles;
        }

        public Roles VerificarSiEsUnRol(int id)
        {
            const string SQL_STATEMENT = "select Name,ID_CompositeRol from RolesComposite as rc join AspNetRoles as a on a.Id=rc.ID_CompositeRol where ID_CompositePermiso is null and Activo=1  and ID_CompositeRol=@id";
            Roles roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRolesCompositeRol(dr);
                    }
                }
            }
            return roles;
        }

        #endregion
    }
}
