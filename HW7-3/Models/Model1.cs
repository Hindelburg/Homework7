namespace HW7_3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.searched)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.requestorIP)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.requestorAgent)
                .IsUnicode(false);
        }
    }
}
