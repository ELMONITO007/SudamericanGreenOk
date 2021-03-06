﻿using Entities;
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
    public class PersonaDAC : DataAccessComponent, IRepository2<Persona>
    {
        public Persona ALoad(IDataReader entity)
        {
            Persona persona = new Persona();
            persona.Id = GetDataValue<int>(entity, "DNI");
            persona.cuil = GetDataValue<string>(entity, "cuil");
            persona.email = GetDataValue<string>(entity, "email");
            persona.telefono = GetDataValue<string>(entity, "telefono");
            persona.tipoPersona.Id = GetDataValue<int>(entity, "Id_tipoPersona");
            persona.usuarios.Id = GetDataValue<int>(entity, "Id");
        


            return persona;
        }

        public Persona Create(Persona entity)
        {

            const string SQL_STATEMENT = "insert into Persona(DNI,Cuil,EMail,Telefono,ID_TipoPersona,Activo,id)values(@DNI,@Cuil,@EMail,@Telefono,@ID_TipoPersona,1,@id)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
        
                db.AddInParameter(cmd, "@cuil", DbType.String, entity.cuil);
                db.AddInParameter(cmd, "@email", DbType.String, entity.email);
             
                db.AddInParameter(cmd, "@telefono", DbType.String, entity.telefono);
                db.AddInParameter(cmd, "@Id_tipoPersona", DbType.Int32, entity.tipoPersona.Id);
                db.AddInParameter(cmd, "@DNI", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@id", DbType.Int32, entity.usuarios.Id);
                db.ExecuteScalar(cmd);
            }
            return entity;

        }

        public void Delete(int id)
        {

            const string SQL_STATEMENT = "update Persona set Activo=0 where DNI=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Persona> Read()
        {
            const string SQL_STATEMENT = "select * from Persona where  activo=1";

            List<Persona> result = new List<Persona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Persona roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Persona ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from Persona where  activo=1 and DNI=@Id";
            Persona roles = null;

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

        public Persona ReadBy(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Persona entity)
        {
            const string SQL_STATEMENT = "update persona set Cuil=@Cuil,EMail=@EMail,Telefono=@Telefono  where DNI=@DNI";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@cuil", DbType.String, entity.cuil);
                db.AddInParameter(cmd, "@email", DbType.String, entity.email);
             
                db.AddInParameter(cmd, "@telefono", DbType.String, entity.telefono);
           
             
                db.AddInParameter(cmd, "@DNI", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
