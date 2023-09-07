using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WILTeam1.Models
{
    public partial class BusinessModel : DbContext
    {
        public BusinessModel()
            : base("name=BusinessModel")
        {
        }

        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessOwner> BusinessOwners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessOwner>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessOwner>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessOwner>()
                .HasMany(e => e.Businesses)
                .WithOptional(e => e.BusinessOwner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete();
        }
    }
}
