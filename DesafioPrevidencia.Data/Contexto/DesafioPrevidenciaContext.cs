using DesafioPrevidencia.Dominio.Entidades;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DesafioPrevidencia.Data.Contexto
{
    public class DesafioPrevidenciaContext : DbContext
    {
        public DesafioPrevidenciaContext()
        : base("DesafioPrevidenciaDB")
        {

        }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<PerfilInvestidor> PerfisInvestidores { get; set; }
        public DbSet<RespostasFormulario> RespostasFormularios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties()
            .Where(p => p.Name == "Senha")
            .Configure(p => p.HasMaxLength(500));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
