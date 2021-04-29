﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Next.Platform.Infrastructure.AppContext;

namespace Next.Platform.Infrastructure.Migrations
{
    [DbContext(typeof(NextPlatformDbContext))]
    partial class NextPlatformDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NeighborhoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

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

            modelBuilder.Entity("Next.Platform.Core.Model.MemberStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemberStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Status = "Blocked"
                        },
                        new
                        {
                            Id = 1,
                            Status = "Banned"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Available"
                        });
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Neighborhood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Neighborhoods");
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

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int>("MemberStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NeighborhoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberStatusId");

                    b.HasIndex("NeighborhoodId");

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

                    b.Property<Guid>("PlayGroundCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayGroundStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PlayGroundTypeId")
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

                    b.HasIndex("PlayGroundCategoryId");

                    b.HasIndex("PlayGroundStatusId");

                    b.HasIndex("PlayGroundTypeId");

                    b.ToTable("PlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBooking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayGroundBookingStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayGroundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayGroundBookingStatusId");

                    b.HasIndex("PlayGroundId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NeighborhoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PlayGroundCategories");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlayGroundId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayGroundId");

                    b.ToTable("PlayGroundImages");
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
                        },
                        new
                        {
                            Id = 4,
                            Status = "Canceled"
                        });
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayGroundTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Ten"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Fourteen"
                        },
                        new
                        {
                            Id = 3,
                            Type = "TwentyOne"
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

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

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

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NeighborhoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Admin", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Neighborhood", null)
                        .WithMany("Admins")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Comment", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGround", null)
                        .WithMany("Comments")
                        .HasForeignKey("PlayGroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Owner", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.MemberStatus", null)
                        .WithMany("Owners")
                        .HasForeignKey("MemberStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.Neighborhood", null)
                        .WithMany("Owners")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGround", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGroundCategory", "PlayGroundCategory")
                        .WithMany("playGrounds")
                        .HasForeignKey("PlayGroundCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.PlayGroundStatus", null)
                        .WithMany("PlayGrounds")
                        .HasForeignKey("PlayGroundStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.PlayGroundType", null)
                        .WithMany("PlayGrounds")
                        .HasForeignKey("PlayGroundTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayGroundCategory");
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

                    b.HasOne("Next.Platform.Core.Model.User", "User")
                        .WithMany("PlayGroundBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundCategory", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Neighborhood", null)
                        .WithMany("PlayGroundCategories")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.Owner", "Owner")
                        .WithMany("PlayGroundCategories")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundImages", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.PlayGround", null)
                        .WithMany("PlayGroundImages")
                        .HasForeignKey("PlayGroundId")
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

                    b.HasOne("Next.Platform.Core.Model.User", "User")
                        .WithMany("PreferredPlayGrounds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Replay", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Comment", null)
                        .WithMany("Replays")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Next.Platform.Core.Model.User", "User")
                        .WithMany("Replays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.User", b =>
                {
                    b.HasOne("Next.Platform.Core.Model.Neighborhood", null)
                        .WithMany("Users")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Comment", b =>
                {
                    b.Navigation("Replays");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.MemberStatus", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Neighborhood", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Owners");

                    b.Navigation("PlayGroundCategories");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.Owner", b =>
                {
                    b.Navigation("PlayGroundCategories");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGround", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlayGroundBookings");

                    b.Navigation("PlayGroundImages");

                    b.Navigation("PreferredPlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundBookingStatus", b =>
                {
                    b.Navigation("PlayGroundBookings");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundCategory", b =>
                {
                    b.Navigation("playGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundStatus", b =>
                {
                    b.Navigation("PlayGrounds");
                });

            modelBuilder.Entity("Next.Platform.Core.Model.PlayGroundType", b =>
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
