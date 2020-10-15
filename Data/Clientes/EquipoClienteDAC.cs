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
    public class EquipoClienteDAC : DataAccessComponent, IRepository2<EquipoCliente>
    {
        public EquipoCliente ALoad(IDataReader entity)
        {
            EquipoCliente marca = new EquipoCliente();
            marca.Id = GetDataValue<int>(entity, "ID_EquipoClienteo");
            marca.antiguedad = GetDataValue<int>(entity, "antiguedad");
            marca.fechaCompra = GetDataValue<DateTime>(entity, "fechaCompra");
            marca.marca.Id= GetDataValue<int>(entity, "ID_marca");
            marca.modelo = GetDataValue<string>(entity, "modelo");
            marca.persona.Id = GetDataValue<int>(entity, "dni");
            marca.peso= GetDataValue<int>(entity, "peso");
            marca.serial= GetDataValue<string>(entity, "serial");
            marca.tipoEquipo.Id= GetDataValue<int>(entity, "ID_tipoEquipo");
            return marca;
        }

        public EquipoCliente Create(EquipoCliente entity)
        {
            const string SQL_STATEMENT = "insert into EquipoCliente(Antiguedad,FechaCompra,Id_Marca,Modelo,DNI,Peso,Serial,Id_TipoEquipo,Activo)values(@Antiguedad,@FechaCompra,@Id_Marca,@Modelo,@DNI,@Peso,@Serial,@Id_TipoEquipo,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@antiguedad", DbType.Int32, entity.antiguedad);

                db.AddInParameter(cmd, "@fechaCompra", DbType.DateTime, entity.fechaCompra);
                db.AddInParameter(cmd, "@ID_marca", DbType.Int32, entity.marca.Id);

                db.AddInParameter(cmd, "@modelo", DbType.String, entity.modelo);
                db.AddInParameter(cmd, "@dni", DbType.Int32, entity.persona.Id);

                db.AddInParameter(cmd, "@peso", DbType.Int32, entity.peso);
                db.AddInParameter(cmd, "@serial", DbType.String, entity.serial);
                db.AddInParameter(cmd, "@ID_tipoEquipo", DbType.Int32, entity.tipoEquipo.Id);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update EquipoCliente set Activo=0 where id_EquipoCliente=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<EquipoCliente> Read()
        {
            const string SQL_STATEMENT = "select * from EquipoCliente where  activo=1";

            List<EquipoCliente> result = new List<EquipoCliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        EquipoCliente roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }
        public List<EquipoCliente> ReadByCliente(int id)
        {
            const string SQL_STATEMENT = "select * form EquipoCliente where  activo=1 and dni=@id";

            List<EquipoCliente> result = new List<EquipoCliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        EquipoCliente roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }
        public EquipoCliente ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from EquipoCliente where  activo=1 and id_EquipoCliente=@Id";
            EquipoCliente roles = null;

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

        public EquipoCliente ReadBy(string id)
        {
            const string SQL_STATEMENT = "select * from EquipoCliente where  activo=1 and serial=@Id";
            EquipoCliente roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);
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

        public void Update(EquipoCliente entity)
        {
            const string SQL_STATEMENT = "update EquipoCliente set Antiguedad=@Antiguedad ,FechaCompra=@FechaCompra, Id_Marca=@Id_Marca,Modelo=@Modelo,DNI=@DNI,Peso=@Peso,Serial=@Serial,Id_TipoEquipo=@Id_TipoEquipo where Id_EquipoCliente=@id)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, entity.Id);
                db.AddInParameter(cmd, "@antiguedad", DbType.Int32, entity.antiguedad);
                db.AddInParameter(cmd, "@Id", DbType.String, entity.Id);
                db.AddInParameter(cmd, "@fechaCompra", DbType.DateTime, entity.fechaCompra);
                db.AddInParameter(cmd, "@ID_marca", DbType.Int32, entity.marca.Id);

                db.AddInParameter(cmd, "@modelo", DbType.String, entity.modelo);
                db.AddInParameter(cmd, "@dni", DbType.Int32, entity.persona.Id);

                db.AddInParameter(cmd, "@peso", DbType.Int32, entity.peso);
                db.AddInParameter(cmd, "@serial", DbType.String, entity.serial);
                db.AddInParameter(cmd, "@ID_tipoEquipo", DbType.Int32, entity.tipoEquipo.Id);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
        }
    }
}
