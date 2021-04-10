using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheMoviePlug.Models;

namespace TheMoviePlug.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
