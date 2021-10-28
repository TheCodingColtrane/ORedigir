using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ORedigir.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace ORedigir.Data
{
    public partial class ORedigirContext: IdentityDbContext<ApplicationUser>
    {
        public ORedigirContext(DbContextOptions<ORedigirContext> options) :base(options)
        {
        }

        public DbSet<ApplicationUser> Usuario { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<TextoProduzido> TextoProduzido { get; set; }
        public DbSet<PropostaTextual> PropostaTextual { get; set; }
        public DbSet<Historico> Historico{ get; set; }
        public DbSet<SA> Sa { get; set; }
        public DbSet<LogUsuario> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TextoProduzido>().Property(p => p.Nota).HasColumnType("decimal").HasPrecision(3, 1);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Professor", NormalizedName = "Professor" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Aluno", NormalizedName = "Aluno" });
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuario");        
        }

    }
}
