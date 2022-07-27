using Microsoft.EntityFrameworkCore;
using SearchEngine.Core.Domain.Common.Interfaces;
using SearchEngine.Core.Domain.Master;

namespace SearchEngine.Infra.Presistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        #region Ctor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        #endregion

        #region DbSet
        public DbSet<AppSetting> AppSettings { get; set; }
        #endregion

        #region Methods
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        #endregion
    }
}
