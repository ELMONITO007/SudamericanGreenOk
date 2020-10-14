using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaComponent : IRepository2<Marca>
    {
        public Marca Create(Marca entity)
        {
            if (Verificar(entity))
            {
                MarcaDAC marcaDAC = new MarcaDAC();
                return marcaDAC.Create(entity);

            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            MarcaDAC marcaDAC = new MarcaDAC();
            marcaDAC.Delete(id);
        }

        public List<Marca> Read()
        {
            MarcaDAC marcaDAC = new MarcaDAC();
            List<Marca> result = new List<Marca>();
            result = marcaDAC.Read();
            
            return result;

        }

        public Marca ReadBy(int id)
        {
            MarcaDAC marcaDAC = new MarcaDAC();
            return marcaDAC.ReadBy(id);
        }

        public Marca ReadBy(string id)
        {
            MarcaDAC marcaDAC = new MarcaDAC();
            return marcaDAC.ReadBy(id);
        }

        public bool Update(Marca entity)
        {
            MarcaDAC marcaDAC = new MarcaDAC();
            if (Verificar(entity))
            {
                marcaDAC.Update(entity);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool Verificar(Marca entity)
        {
            if (ReadBy(entity.marca)==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
