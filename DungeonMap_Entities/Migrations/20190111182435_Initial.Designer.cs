﻿// <auto-generated />
using System;
using DungeonMap_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DungeonMap_Entities.Migrations
{
    [DbContext(typeof(DungeonMapContext))]
    [Migration("20190111182435_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DungeonMap_Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName")
                        .IsRequired();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<short>("RoleType");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterName = "Letherna",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(4031),
                            GameId = 1,
                            RoleType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(4031),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CharacterName = "Lia",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5815),
                            GameId = 1,
                            RoleType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5816),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CharacterName = "Dungeon Master",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5829),
                            GameId = 1,
                            RoleType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5830),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CharacterName = "Dreyfus",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5831),
                            GameId = 1,
                            RoleType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5831),
                            UserId = 4
                        });
                });

            modelBuilder.Entity("DungeonMap_Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("GameType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3416),
                            GameType = (short)0,
                            Name = "Out Of The Abyss",
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(4052)
                        });
                });

            modelBuilder.Entity("DungeonMap_Entities.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Salt");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(112),
                            Email = "fakeEmailNumber1@gmail.com",
                            FirstName = "Bailey",
                            LastName = "Stoddard",
                            PasswordHash = "change",
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(112),
                            UserName = "critical.bailure"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3044),
                            Email = "dustin.patrick@fakeEmail.io",
                            FirstName = "Dustin",
                            LastName = "Patrick",
                            PasswordHash = "change",
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3044),
                            UserName = "dpatrick"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3071),
                            Email = "something@gmail.com",
                            FirstName = "Kaylin",
                            LastName = "Jones",
                            PasswordHash = "change",
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3071),
                            UserName = "xXxLiaxXx"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3072),
                            Email = "something_else@gmail.com",
                            FirstName = "Russell",
                            LastName = "Patrick",
                            PasswordHash = "change",
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3073),
                            UserName = "_dreyfus"
                        });
                });

            modelBuilder.Entity("DungeonMap_Entities.UserFriend", b =>
                {
                    b.Property<int>("FriendId");

                    b.Property<int>("UserId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("FriendId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("DungeonMap_Entities.UserSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("PreferredCharacterName");

                    b.Property<string>("SkypeHandle");

                    b.Property<short>("SubscriptionType");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("UserSettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "I silence things",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(7523),
                            PhoneNumber = "5554443210",
                            PreferredCharacterName = "Letherna: The Silencer",
                            SkypeHandle = "critical.bailure",
                            SubscriptionType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(7524)
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Malevolent Dungeonmaster",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9544),
                            PhoneNumber = "5554441234",
                            PreferredCharacterName = "God",
                            SkypeHandle = "dustin.patrick",
                            SubscriptionType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9544)
                        },
                        new
                        {
                            Id = 3,
                            Biography = "New to the game. Also you just lost the game",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9578),
                            PhoneNumber = "5554443210",
                            PreferredCharacterName = "Lia",
                            SkypeHandle = "jk_its_kj",
                            SubscriptionType = (short)1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9578)
                        },
                        new
                        {
                            Id = 4,
                            Biography = "I'm just here so I don't get fined",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9580),
                            PhoneNumber = "5554443210",
                            PreferredCharacterName = "Dreyfus",
                            SkypeHandle = "something_creative",
                            SubscriptionType = (short)0,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9580)
                        });
                });

            modelBuilder.Entity("DungeonMap_Entities.Character", b =>
                {
                    b.HasOne("DungeonMap_Entities.Game", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonMap_Entities.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DungeonMap_Entities.User", b =>
                {
                    b.HasOne("DungeonMap_Entities.UserSettings", "Settings")
                        .WithOne("User")
                        .HasForeignKey("DungeonMap_Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DungeonMap_Entities.UserFriend", b =>
                {
                    b.HasOne("DungeonMap_Entities.User", "Friend")
                        .WithMany("FriendUsers")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DungeonMap_Entities.User", "User")
                        .WithMany("UserFriends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}