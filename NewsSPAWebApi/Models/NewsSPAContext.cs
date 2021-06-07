using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewsSPAWebApi.Models
{
    public partial class NewsSPAContext : DbContext
    {
        public NewsSPAContext()
        {
        }

        public NewsSPAContext(DbContextOptions<NewsSPAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-T2D9LUV7\\MSSQLSERVER15;Database=NewsSPA;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.ShortDesc)
                    .HasColumnName("short_desc")
                    .HasMaxLength(350);

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_Users");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_News_Themes");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("short_description")
                    .HasMaxLength(350);
            });

            modelBuilder.Entity<Themes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.ShortDesc)
                    .HasColumnName("short_desc")
                    .HasMaxLength(350);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(150);

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel")
                    .HasMaxLength(12);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
