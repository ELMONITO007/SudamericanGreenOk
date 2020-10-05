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
    public class TipoPersonaPersonaDAC : DataAccessComponent, IRepository2<TipoPersonaPersona>
    {
        public TipoPersonaPersona ALoad(IDataReader entity)
        {
            TipoPersonaPersona tipoPersonaPersona = new TipoPersonaPersona();
            tipoPersonaPersona.persona.Id = GetDataValue<int>(entity, "DNI");
            tipoPersonaPersona.tipoPersona.Id = GetDataValue<int>(entity, "ID_tipoPersona");
            return tipoPersonaPersona;
        }

        public TipoPersonaPersona Create(TipoPersonaPersona entity)
        {
            const string SQL_STATEMENT = "insert into TipoPersonaPersona(DNI,ID_tipoPersona)values(@name,@ID_tipoPersona)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.persona.Id);
                db.AddInParameter(cmd, "@ID_tipoPersona", DbType.Int32, entity.tipoPersona.Id);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "delete TipoPersonaPersona  where  DNI=@Id and ID_direccion=@direccion";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        public void Delete(int id,int TipoPersona)
        {
            const string SQL_STATEMENT = "delete TipoPersonaPersona  where  DNI=@Id and ID_TipoPersona=@TipoPersona";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddInParameter(cmd, "@TipoPersona", DbType.Int32, TipoPersona);
                db.ExecuteNonQuery(cmd);
            }
        }
        public List<TipoPersonaPersona> Read()
        {
            const string SQL_STATEMENT = "select * from TipoPersonaPersona as tpo join TipoPersona as tp on tpo.ID_TIpoPersona=tp.ID_TipoPersona join Persona as p  on p.DNI=tpo.DNI where p.Activo=1 and tp.Activo=1";

            List<TipoPersonaPersona> result = new List<TipoPersonaPersona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoPersonaPersona roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public TipoPersonaPersona ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPersonaPersona ReadBy(string id)
        {
            throw new NotImplementedException();
        }
        public TipoPersonaPersona ReadBy(int id,int tipo)
        {
            const string SQL_STATEMENT = "select * from TipoPersonaPersona as tpo join TipoPersona as tp on tpo.ID_TIpoPersona=tp.ID_TipoPersona join Persona as p  on p.DNI=tpo.DNI where p.Activo=1 and tp.Activo=1 and tpo.DNI=@DNI and tpo.ID_TipoPersona=@ID_TipoPersona";

          TipoPersonaPersona result = new TipoPersonaPersona();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddInParameter(cmd, "@TipoPersona", DbType.Int32, tipo);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        result = ALoad(dr);
                        
                    }
                }
            }
            return result;
        }
        public List<TipoPersonaPersona> ReadByPersona(int id)
        {
            const string SQL_STATEMENT = "select * from TipoPersonaPersona as tpo join TipoPersona as tp on tpo.ID_TIpoPersona=tp.ID_TipoPersona join Persona as p  on p.DNI=tpo.DNI where p.Activo=1 and tp.Activo=1 and tpo.DNI=@DNI";

            List<TipoPersonaPersona> result = new List<TipoPersonaPersona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoPersonaPersona roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }
        public void Update(TipoPersonaPersona entity)
        {
            throw new NotImplementedException();
        }
    }
}
