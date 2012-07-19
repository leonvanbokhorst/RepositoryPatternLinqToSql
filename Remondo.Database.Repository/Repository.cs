using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;

namespace Remondo.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected Table<T> DataTable;

        public Repository(DataContext dataContext)
        {
            DataTable = dataContext.GetTable<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            DataTable.InsertOnSubmit(entity);
        }

        public void Delete(T entity)
        {
            DataTable.DeleteOnSubmit(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DataTable.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DataTable;
        }

        public T GetById(int id)
        {
            // Beware the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return DataTable.Single(e => e.ID.Equals(id));
        }

        #endregion
    }
}