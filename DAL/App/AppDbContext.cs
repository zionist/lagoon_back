using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lagoon_back.DAL.App
{
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Database=lagoon;Username=lagoon;Password=lagoon");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item", "app");

                entity.HasIndex(e => e.ImagePath)
                    .HasName("item_image_path_key")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("item_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app.item_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnName("image_path");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Specification)
                    .IsRequired()
                    .HasColumnName("specification");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("item_category_id_fkey");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("item_category", "app");

                entity.HasIndex(e => e.ImagePath)
                    .HasName("item_category_image_path_key")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("item_category_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app.item_category_id_seq'::regclass)");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnName("image_path");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.HasSequence("item_category_id_seq");

            modelBuilder.HasSequence("item_id_seq");
        }
    }
}
