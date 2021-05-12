
using Just.Entityframeworkcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Just.Entityframeworkcore.EntityFramework
{
    public class JustDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<MemberSport> MemberSports { get; set; }

        public JustDbContext(DbContextOptions<JustDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                   new Sport { Id = 1, Name = "Tennis" },
                    new Sport { Id = 2, Name = "Squash" }
                );

            modelBuilder.Entity<MemberSport>()
                .HasKey(ms => new { ms.MemberId, ms.SportId});
            modelBuilder.Entity<MemberSport>()
                .HasOne(m => m.Members)
                .WithMany(ms => ms.MemberSports)
                .HasForeignKey(ms => ms.MemberId);
            modelBuilder.Entity<MemberSport>()
                .HasOne(s => s.Sports)
                .WithMany(ms => ms.MemberSports)
                .HasForeignKey(ms => ms.SportId);
        }
    }
}
