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
    public class DireccionDAC : DataAccessComponent, IRepository2<Direccion>
    {
        public Direccion ALoad(IDataReader entity)
        {
            Direccion direccion = new Direccion();
            direccion.Id = GetDataValue<int>(entity, "Id_Direccion");
            direccion.direccion = GetDataValue<string>(entity, "direccion");
            direccion.numero = GetDataValue<int>(entity, "numero");
            direccion.piso = GetDataValue<int>(entity, "piso");
            direccion.departamento = GetDataValue<string>(entity, "departamento");
            direccion.localidad = GetDataValue<string>(entity, "localidad");
            direccion.codigoPostal = GetDataValue<int>(entity, "codigoPostal");
            direccion.provincia = GetDataValue<string>(entity, "provincia");


            return direccion;
        }

        public Direccion Create(Direccion entity)
        {
            const string SQL_STATEMENT = "insert into Direccion(Direccion,Numero,Piso,Departamento,Localidad,CodigoPostal,Provincia,activo)values (@Direccion,@Numero,@Piso,@Departamento,@Localidad,@CodigoPostal,@Provincia,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@direccion", DbType.String, entity.direccion);
                db.AddInParameter(cmd, "@numero", DbType.Int32, entity.numero);
                db.AddInParameter(cmd, "@piso", DbType.Int32, entity.piso);
                db.AddInParameter(cmd, "@departamento", DbType.String, entity.departamento);
                db.AddInParameter(cmd, "@localidad", DbType.String, entity.localidad);
                db.AddInParameter(cmd, "@codigoPostal", DbType.String, entity.codigoPostal);
                db.AddInParameter(cmd, "@provincia", DbType.String, entity.provincia);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Direccion set Activo=0 where id_Direccion=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
  

        public List<Direccion> Read()
        {
            const string SQL_STATEMENT = "select * form Direccion where  activo=1";

            List<Direccion> result = new List<Direccion>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Direccion roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Direccion ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from Direccion where  activo=1 and id_Direccion=@Id";
            Direccion roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = ALoad(dr);
                    }
                }
            }
            return roles;
        }
        public Direccion ReadBy(Direccion entity)
        {
            const string SQL_STATEMENT = "select * from Direccion where Direccion=@Direccion and Numero=@Numero and Departamento=@Departamento and Localidad=@Localidad and CodigoPostal=@CodigoPostal and Provincia=@Provincia and activo=1";
            Direccion roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Direccion", DbType.String, entity.direccion);
                db.AddInParameter(cmd, "@numero", DbType.Int32, entity.numero);
                db.AddInParameter(cmd, "@piso", DbType.Int32, entity.piso);
                db.AddInParameter(cmd, "@departamento", DbType.String, entity.departamento);
                db.AddInParameter(cmd, "@localidad", DbType.String, entity.localidad);
                db.AddInParameter(cmd, "@codigoPostal", DbType.Int32, entity.codigoPostal);
                db.AddInParameter(cmd, "@Provincia", DbType.String, entity.provincia);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = ALoad(dr);
                    }
                }
            }
            return roles;
        }

        public Direccion ReadBy(string id)
        {
             const string SQL_STATEMENT = "select * form Direccion where  activo=1 and Direccion=@Id";
            Direccion roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = ALoad(dr);
                    }
                }
            }
            return roles;
        }

        public void Update(Direccion entity)
        {
            const string SQL_STATEMENT = "update Direccion set Direccion=@Direccion, Numero=@Numero, piso=@Piso, Departamento=@Departamento,Localidad=@Localidad, CodigoPostal=@CodigoPostal,Provincia=@Provincia where ID_Direccion=@id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@direccion", DbType.String, entity.direccion);
                db.AddInParameter(cmd, "@numero", DbType.Int32, entity.numero);
                db.AddInParameter(cmd, "@piso", DbType.Int32, entity.piso);
                db.AddInParameter(cmd, "@departamento", DbType.String, entity.departamento);
                db.AddInParameter(cmd, "@localidad", DbType.String, entity.localidad);
                db.AddInParameter(cmd, "@codigoPostal", DbType.String, entity.codigoPostal);
                db.AddInParameter(cmd, "@provincia", DbType.String, entity.provincia);
                db.AddInParameter(cmd, "@id", DbType.String, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
