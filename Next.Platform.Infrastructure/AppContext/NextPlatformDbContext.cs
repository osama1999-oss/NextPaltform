using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Infrastructure.AppContext
{
   public class NextPlatformDbContext :DbContext
    {
        public NextPlatformDbContext(DbContextOptions<NextPlatformDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique(true);

            modelBuilder.Entity<Replay>()
                .HasOne(e => e.user)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayGroundBooking>().HasKey(pgb => new { pgb.UserId, pgb.PlayGroundId });
            modelBuilder.Entity<PreferredPlayGround>().HasKey(ppg => new { ppg.UserId, ppg.PlayGroundId });

            modelBuilder
                .Entity<PlayGround>()
                .Property(e => e.PlayGroundStatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundStatus>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundStatus>().HasData(
                    Enum.GetValues(typeof(PlayGroundStatusEnum))
                        .Cast<PlayGroundStatusEnum>()
                        .Select(e => new PlayGroundStatus()
                        {
                            Id = e,
                            Status = e.ToString()
                        })
                );
            // ================================================
            //modelBuilder
            //    .Entity<User>()
            //    .Property(e => e.MemberStatusId)
            //    .HasConversion<int>();

            //modelBuilder
            //    .Entity<MemberStatus>()
            //    .Property(e => e.Id)
            //    .HasConversion<int>();

            //modelBuilder
            //    .Entity<MemberStatus>().HasData(
            //        Enum.GetValues(typeof(MemberStatusEnum))
            //            .Cast<MemberStatusEnum>()
            //            .Select(e => new MemberStatus()
            //            {
            //                Id = e,
            //                Status = e.ToString()
            //            })
            //    );
            // ================================================
            modelBuilder
                .Entity<Owner>()
                .Property(e => e.MemberStatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<MemberStatus>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<MemberStatus>().HasData(
                    Enum.GetValues(typeof(MemberStatusEnum))
                        .Cast<MemberStatusEnum>()
                        .Select(e => new MemberStatus()
                        {
                            Id = e,
                            Status = e.ToString()
                        })
                );
            // ================================================
            modelBuilder
                .Entity<PlayGroundBooking>()
                .Property(e => e.PlayGroundBookingStatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundBookingStatus>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundBookingStatus>().HasData(
                    Enum.GetValues(typeof(PlayGroundBookingStatusEnum))
                        .Cast<PlayGroundBookingStatusEnum>()
                        .Select(e => new PlayGroundBookingStatus()
                        {
                            Id = e,
                            Status = e.ToString()
                        })
                );
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PlayGround> PlayGrounds { get; set; }
        public DbSet<PlayGroundBooking> PlayGroundBookings { get; set; }
        public DbSet<PlayGroundBookingStatus> PlayGroundBookingStatus { get; set; }
        public DbSet<PlayGroundStatus> PlayGroundStatus { get; set; }
        public DbSet<MemberStatus> MemberStatus { get; set; }
        public DbSet<PreferredPlayGround> PreferredPlayGrounds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlayGroundImages> PlayGroundImages { get; set; }

    }
}
