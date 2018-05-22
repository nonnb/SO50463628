namespace ConsoleApp5
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("name=MyModel")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<EFparticipant> participants { get; set; }
        public virtual DbSet<EFprereg_participants> prereg_participants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EFparticipant>()
                .HasOptional(e => e.EFprereg_participants)
                .WithRequired(e => e.participant);
        }
    }
}
