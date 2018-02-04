using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace lagoon_back.Context
{
    public partial class CustomIdentityDbContext : IdentityDbContext
    {

        public CustomIdentityDbContext(DbContextOptions options):base(options) {

        }
        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("auth");
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Database=lagoon;Username=lagoon;Password=lagoon;Port=5432");
            //optionsBuilder.UseLoggerFactory(this.factory);
            //}
        }

    }

}
