using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            
            string connectionString = configuration.GetConnectionString("MySqlConnection");

            

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("A chave de conexão 'ConnectionStrings:MySqlConnection' não foi encontrada ou tem um valor nulo/vazio no arquivo de configuração.");
            }

            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
        }
    }
}

