using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DireccionComponent : IRepository2<Direccion>
    {
        public Direccion Create(Direccion entity)
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            return direccionDAC.Create(entity);
        }

        public void Delete(int id)
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            direccionDAC.Delete(id);
        }

        public List<Direccion> Read()
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            return direccionDAC.Read();
        }

        public Direccion ReadBy(int id)
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            return direccionDAC.ReadBy(id);
        }

        public Direccion ReadBy(string id)
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            return direccionDAC.ReadBy(id);
        }

        public bool Update(Direccion entity)
        {
            DireccionDAC direccionDAC = new DireccionDAC();
            direccionDAC.Update(entity);
            return true;
        }

        public bool Verificar(Direccion entity)
        {
            throw new NotImplementedException();
        }
    }
}
