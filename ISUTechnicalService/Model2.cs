using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ISUTechnicalService
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<AdminPanel> AdminPanel { get; set; }
        public virtual DbSet<Customerİnfo> Customerİnfo { get; set; }
        public virtual DbSet<Deviceİnfo> Deviceİnfo { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<SalesHistory> SalesHistory { get; set; }
        public virtual DbSet<StockTracking> StockTracking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminPanel>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<AdminPanel>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customerİnfo>()
                .Property(e => e.TC)
                .IsUnicode(false);

            modelBuilder.Entity<Customerİnfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customerİnfo>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Customerİnfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customerİnfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.TC)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Deviceİnfo>()
                .Property(e => e.Trouble)
                .IsUnicode(false);

            //modelBuilder.Entity<Deviceİnfo>()
            //  .Property(e => e.Price)
            //  .IsOptional();


            modelBuilder.Entity<Payment>()
                .Property(e => e.TC)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Process)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.TC)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.Process)
                .IsUnicode(false);

            modelBuilder.Entity<StockTracking>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<StockTracking>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<StockTracking>()
                .Property(e => e.Model)
                .IsUnicode(false);
        }
    }
}
