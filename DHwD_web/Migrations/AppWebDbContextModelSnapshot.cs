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
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.HasKey("ID");

                    b.HasIndex("PlaceId");

                    b.ToTable("ActivePlaces");
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

                    b.HasKey("ID");

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
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int?>("Id_FounderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("OnlyOnePlayer")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

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
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DHwD_web.Models.ActivePlace", b =>
                {
                    b.HasOne("DHwD_web.Models.Place", "Place")
                        .WithMany("ActivePlace")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("DHwD_web.Models.Mysterys", b =>
                {
                    b.HasOne("DHwD_web.Models.Solutions", "Solutions")
                        .WithOne("Mysterys")
                        .HasForeignKey("DHwD_web.Models.Mysterys", "SolutionsRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                });

            modelBuilder.Entity("DHwD_web.Models.Points", b =>
                {
                    b.HasOne("DHwD_web.Models.User", "User")
                        .WithOne("Points")
                        .HasForeignKey("DHwD_web.Models.Points", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DHwD_web.Models.Status", b =>
                {
                    b.HasOne("DHwD_web.Models.ActivePlace", "ActivePlace")
                        .WithMany("Status")
                        .HasForeignKey("ActivePlaceID");
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
                });
#pragma warning restore 612, 618
        }
    }
}
