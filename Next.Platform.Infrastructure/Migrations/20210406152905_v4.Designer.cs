﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Next.Platform.Infrastructure.AppContext;

namespace Next.Platform.Infrastructure.Migrations
{
    [DbContext(typeof(NextPlatformDbContext))]
    [Migration("20210406152905_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Next.Platform.Core.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayGroundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayGroundId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGround", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasBall")
                        .HasColumnType("bit");

                    b.Property<bool>("HasGarag")
                        .HasColumnType("bit");

                    b.Property<bool>("HasLoacker")
                        .HasColumnType("bit");

                    b.Property<bool>("HasShower")
                        .HasColumnType("bit");

                    b.Property<bool>("HasToilet")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWater")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayGroundStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceEvening")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceMorning")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlayGroundStatusId");

                    b.ToTable("PlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBooking", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayGroundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Form")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayGroundBookingStatusId")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "PlayGroundId");

                    b.HasIndex("PlayGroundBookingStatusId");

                    b.HasIndex("PlayGroundId");

                    b.ToTable("PlayGroundBookings");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayGroundBookingStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 1,
                            Status = "Canceled"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Approved"
                        });
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayGroundStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 1,
                            Status = "Closed"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Status = "InMaintenance"
                        });
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PreferredPlayGround", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayGroundId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "PlayGroundId");

                    b.HasIndex("PlayGroundId");

                    b.ToTable("PreferredPlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Replay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Replay");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Comment", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGround", null)
                        .WithMany("Comments")
                        .HasForeignKey("PlayGroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGround", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Owner", null)
                        .WithMany("PlayGrounds")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.PlayGroundStatus", null)
                        .WithMany("PlayGrounds")
                        .HasForeignKey("PlayGroundStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBooking", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGroundBookingStatus", null)
                        .WithMany("PlayGroundBookings")
                        .HasForeignKey("PlayGroundBookingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.PlayGround", null)
                        .WithMany("PlayGroundBookings")
                        .HasForeignKey("PlayGroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", null)
                        .WithMany("PlayGroundBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PreferredPlayGround", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGround", null)
                        .WithMany("PreferredPlayGrounds")
                        .HasForeignKey("PlayGroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", null)
                        .WithMany("PreferredPlayGrounds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Replay", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Comment", null)
                        .WithMany("Replays")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", null)
                        .WithMany("Replays")
                        .HasForeignKey("UserId1");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Comment", b =>
                {
                    b.Navigation("Replays");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Owner", b =>
                {
                    b.Navigation("PlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGround", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlayGroundBookings");

                    b.Navigation("PreferredPlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBookingStatus", b =>
                {
                    b.Navigation("PlayGroundBookings");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundStatus", b =>
                {
                    b.Navigation("PlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlayGroundBookings");

                    b.Navigation("PreferredPlayGrounds");

                    b.Navigation("Replays");
                });
#pragma warning restore 612, 618
        }
    }
}
