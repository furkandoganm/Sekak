using AppCore.Records;
using System;
using System.Linq;

namespace AppCore.DataAccess.Repositories.Base
{
    public interface IRepository<TEntity>: IDisposable where TEntity: Record, new()
    {
        IQueryable<TEntity> Query(params string[] entitiesToInclude);
        void Add(TEntity entity, bool save = true);
        void Update(TEntity entity, bool save = true);
        void Delete(TEntity entity, bool save = true);
        void Save();
    }
}
