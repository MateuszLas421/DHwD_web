﻿// <auto-generated />
using System;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DHwD_web.Migrations
{
    [DbContext(typeof(AppWebDbContext))]
    partial class AppWebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DHwD_web.Models.ActivePlace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Team_Id")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PlaceId");

                    b.ToTable("ActivePlaces");
                });

            modelBuilder.Entity("DHwD_web.Models.Chats", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GameId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("DHwD_web.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeEdit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DHwD_web.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("MysteryRef")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("MysteryRef")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DHwD_web.Models.Mysterys", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SolutionsRef")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("SolutionsRef")
                        .IsUnique();

                    b.ToTable("Mysterys");
                });

            modelBuilder.Entity("DHwD_web.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("LocationRef")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("LocationRef")
                        .IsUnique();

                    b.ToTable("Places");
                });

            modelBuilder.Entity("DHwD_web.Models.Points", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataTimeEdit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserPoints")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("DHwD_web.Models.Solutions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MysterySolutionNegative")
                        .HasColumnType("text");

                    b.Property<string>("MysterySolutionPozitive")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("DHwD_web.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ActivePlaceID")
                        .HasColumnType("integer");

                    b.Property<bool>("Game_Status")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.HasIndex("ActivePlaceID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DHwD_web.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeEdit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int?>("Id_FounderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("OnlyOnePlayer")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("StatusPassword")
                        .HasColumnType("boolean");

                    b.Property<int>("StatusRef")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("Id_FounderId");

                    b.HasIndex("StatusRef")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DHwD_web.Models.TeamMembers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("JoinTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("DHwD_web.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeEdit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DHwD_web.Models.ActivePlace", b =>
                {
                    b.HasOne("DHwD_web.Models.Place", "Place")
                        .WithMany("ActivePlace")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("DHwD_web.Models.Chats", b =>
                {
                    b.HasOne("DHwD_web.Models.Games", "Game")
                        .WithMany("Chats")
                        .HasForeignKey("GameId");

                    b.HasOne("DHwD_web.Models.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DHwD_web.Models.Location", b =>
                {
                    b.HasOne("DHwD_web.Models.Mysterys", "Mysterys")
                        .WithOne("Location")
                        .HasForeignKey("DHwD_web.Models.Location", "MysteryRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mysterys");
                });

            modelBuilder.Entity("DHwD_web.Models.Mysterys", b =>
                {
                    b.HasOne("DHwD_web.Models.Solutions", "Solutions")
                        .WithOne("Mystery")
                        .HasForeignKey("DHwD_web.Models.Mysterys", "SolutionsRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("DHwD_web.Models.Place", b =>
                {
                    b.HasOne("DHwD_web.Models.Games", "Games")
                        .WithMany("Place")
                        .HasForeignKey("GamesId");

                    b.HasOne("DHwD_web.Models.Location", "Location")
                        .WithOne("Place")
                        .HasForeignKey("DHwD_web.Models.Place", "LocationRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DHwD_web.Models.Points", b =>
                {
                    b.HasOne("DHwD_web.Models.User", "User")
                        .WithOne("Points")
                        .HasForeignKey("DHwD_web.Models.Points", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DHwD_web.Models.Status", b =>
                {
                    b.HasOne("DHwD_web.Models.ActivePlace", "ActivePlace")
                        .WithMany("Status")
                        .HasForeignKey("ActivePlaceID");

                    b.Navigation("ActivePlace");
                });

            modelBuilder.Entity("DHwD_web.Models.Team", b =>
                {
                    b.HasOne("DHwD_web.Models.Games", "Games")
                        .WithMany("Teams")
                        .HasForeignKey("GamesId");

                    b.HasOne("DHwD_web.Models.User", "Id_Founder")
                        .WithMany("Teams")
                        .HasForeignKey("Id_FounderId");

                    b.HasOne("DHwD_web.Models.Status", "Status")
                        .WithOne("Team")
                        .HasForeignKey("DHwD_web.Models.Team", "StatusRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Id_Founder");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DHwD_web.Models.TeamMembers", b =>
                {
                    b.HasOne("DHwD_web.Models.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DHwD_web.Models.User", "User")
                        .WithMany("TeamMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DHwD_web.Models.ActivePlace", b =>
                {
                    b.Navigation("Status");
                });

            modelBuilder.Entity("DHwD_web.Models.Games", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Place");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("DHwD_web.Models.Location", b =>
                {
                    b.Navigation("Place");
                });

            modelBuilder.Entity("DHwD_web.Models.Mysterys", b =>
                {
                    b.Navigation("Location");
                });

            modelBuilder.Entity("DHwD_web.Models.Place", b =>
                {
                    b.Navigation("ActivePlace");
                });

            modelBuilder.Entity("DHwD_web.Models.Solutions", b =>
                {
                    b.Navigation("Mystery");
                });

            modelBuilder.Entity("DHwD_web.Models.Status", b =>
                {
                    b.Navigation("Team");
                });

            modelBuilder.Entity("DHwD_web.Models.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("DHwD_web.Models.User", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Points")
                        .IsRequired();

                    b.Navigation("TeamMembers");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
