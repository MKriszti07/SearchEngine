using Microsoft.EntityFrameworkCore;
using SearchEngine.Core.Domain.Common.Interfaces;
using SearchEngine.Infra.Presistence;
using System.Linq.Expressions;

namespace SearchEngine.Core.Domain.Common.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Func<ApplicationDBContext> _instanceFunc;
        private DbSet<T> _dbSet;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = DbContext.Set<T>());
        }

        public Repository(Func<ApplicationDBContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Add(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.Now.ToLocalTime();
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.Now.ToLocalTime();
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.Now.ToLocalTime();
            }
            DbSet.Update(entity);
        }
    }
}
