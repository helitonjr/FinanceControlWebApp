using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using HJR.FinanceControl.WebApp.Models;
using HJR.FinanceControl.WebApp.Data.Mappings;
using HJR.FinanceControl.WebApp.ViewModels;

namespace HJR.FinanceControl.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ContaAPagar>   ContasAPagar   { get; set; }
        public DbSet<ContaAReceber> ContasAReceber { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ForSqlServerUseIdentityColumns();

            builder.ApplyConfiguration(new ContaPagarMap());
            builder.ApplyConfiguration(new ContaReceberMap());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}