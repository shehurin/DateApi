namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DateDB : DbContext
    {
        public DateDB()
            : base("name=DateDB")
        {
        }

        public virtual DbSet<Dates> Dates { get; set; }
        public virtual DbSet<ReplyLog> ReplyLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
