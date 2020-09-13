using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PermisoDAC : DataAccessComponent, IRepository<Permiso>
    {
        private Permiso LoadRoles(IDataReader dr)
        {
            Permiso permiso = new Permiso();
            permiso.Id = GetDataValue<int>(dr, "Id");
            permiso.name = GetDataValue<string>(dr, "name");
            return permiso;
        }
        public Permiso Create(Permiso entity)
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

        public List<Permiso> Read()
        {
            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositePermiso where ID_CompositeRol   is  null and activo=1";

            List<Permiso> result = new List<Permiso>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Permiso roles = LoadRoles(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Permiso ReadBy(int id)
        {

            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositePermiso where ID_CompositeRol   is  null and activo =1 and id=@Id";
            Permiso roles = null;

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
        public Permiso ReadBy(String   id)
        {

            const string SQL_STATEMENT = "select DISTINCT  r.Id,r.Name from RolesComposite as rc join AspNetRoles as r on r.Id=rc.ID_CompositePermiso where ID_CompositeRol   is  null and activo =1 and r.Name=@Id";
            Permiso roles = null;

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
        public void Update(Permiso entity)
        {
            const string SQL_STATEMENT = "update AspNetRoles set name=@name where id=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@name", DbType.String, entity.name);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
