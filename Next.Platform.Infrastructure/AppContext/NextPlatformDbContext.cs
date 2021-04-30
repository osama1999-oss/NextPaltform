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

            modelBuilder.Entity<PlayGroundBooking>().
                Property(p => p.DateOnly)
                .HasColumnType("date");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique(true);

            
            modelBuilder.Entity<Replay>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Replays)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayGroundCategory>()
                .HasOne<Owner>(s => s.Owner)
                .WithMany(g => g.PlayGroundCategories)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayGroundBooking>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.PlayGroundBookings)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PreferredPlayGround>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.PreferredPlayGrounds)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Comment>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.Entity<PlayGround>()
                .HasOne<PlayGroundCategory>(s => s.PlayGroundCategory)
                .WithMany(g => g.playGrounds)
                .HasForeignKey(s => s.PlayGroundCategoryId)
                .OnDelete(DeleteBehavior.NoAction);


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
                .Entity<PlayGround>()
                .Property(e => e.PlayGroundTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundType>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<PlayGroundType>().HasData(
                    Enum.GetValues(typeof(PlayGroundTypeEnum))
                        .Cast<PlayGroundTypeEnum>()
                        .Select(e => new PlayGroundType()
                        {
                            Id = e,
                            Type = e.ToString()
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
            // ================================================
           
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
        public DbSet<PlayGroundCategory> PlayGroundCategories { get; set; }
        public DbSet<PlayGroundType> PlayGroundTypes { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

    }
}
