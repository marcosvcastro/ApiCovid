using Data.Configurations;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class ApiContexto :DbContext {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql("Database=api;Data Source=localhost;UserId=root;Password=123456;SslMode=None");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ResultConsumeApiExternalConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ResultConsumeApiExternal> ResultConsumeApiExternals { get; set; }
    }
}
