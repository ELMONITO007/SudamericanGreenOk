using Entities;
using System.Collections.Generic;
using System.Data;

namespace Data
{
    public interface IRepository2<TEntity> where TEntity : EntityBase
    {
        TEntity Create(TEntity entity);
        List<TEntity> Read();
        TEntity ReadBy(int id);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity ALoad(IDataReader entity);
        TEntity ReadBy(string id);
    }
}
