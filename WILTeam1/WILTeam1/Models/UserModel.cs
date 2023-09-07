using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WILTeam1.Models
{
    public partial class UserModel : DbContext
    {
        public UserModel()
            : base("name=UsersModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Caus> Causes { get; set; }
        public virtual DbSet<Interaction> Interactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Interactions)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Year)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Caus>()
                .HasMany(e => e.Interactions)
                .WithRequired(e => e.Caus)
                .HasForeignKey(e => e.CauseId);

            modelBuilder.Entity<Interaction>()
                .Property(e => e.Comment)
                .IsUnicode(false);
        }
    }
}
