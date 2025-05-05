using Microsoft.EntityFrameworkCore;
using NcmAPI.Domain.Entities;
using NcmAPI.Infrastructure.Configuration;

namespace NcmAPI.Infrastructure.Data
{
    /// <summary>
    /// DbContext da aplicação, responsável pelo mapeamento das entidades de domínio para o banco.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Conjunto de registros antigos de NCM (old_ncm).
        /// </summary>
        public DbSet<OldNcm> OldNcms { get; set; }

        /// <summary>
        /// Conjunto de novos registros de NCM (new_ncm).
        /// </summary>
        public DbSet<NewNcm> NewNcms { get; set; }

        /// <summary>
        /// Conjunto de novos registros de ususuarios (users)
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OldNcmConfiguration());
            modelBuilder.ApplyConfiguration(new NewNcmConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
