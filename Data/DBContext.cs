#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspcore6_1.Models;

namespace aspcore6_1.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<aspcore6_1.Models.Member> Member { get; set; }


        public DbSet<aspcore6_1.Models.Customers> customers { get; set; }
        public DbSet<aspcore6_1.Models.AdminMember> adminMembers { get; set; }

        public DbSet<aspcore6_1.Models.Contact_Us> contact_Us { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new List<Member>()
            {
                new Member() { Id=1,Name="Admin",Age=20,DateTime=DateTime.Now}
 });
        }

    }
}
