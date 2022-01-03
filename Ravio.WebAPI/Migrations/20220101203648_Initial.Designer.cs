﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ravio.WebAPI;

namespace Ravio.WebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220101203648_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ravio.Entities.AddedFoodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int?>("FoodResultId")
                        .HasColumnType("int");

                    b.Property<int>("Grams")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodResultId");

                    b.ToTable("AddedFood");
                });

            modelBuilder.Entity("Ravio.Entities.AwardEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("Ravio.Entities.BodyMessurementsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ChestMessurement")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("HipsMessurement")
                        .HasColumnType("float");

                    b.Property<double>("StomachMessurement")
                        .HasColumnType("float");

                    b.Property<double>("ThighMessurement")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("WaistMessurement")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BodiesMessurements");
                });

            modelBuilder.Entity("Ravio.Entities.CoordinatesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("WorkoutResultEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutResultEntityId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Ravio.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BurningParameter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurningParameter = 1,
                            Name = "Przysiady"
                        },
                        new
                        {
                            Id = 2,
                            BurningParameter = 1,
                            Name = "Pompki"
                        },
                        new
                        {
                            Id = 3,
                            BurningParameter = 1,
                            Name = "Brzuszki"
                        },
                        new
                        {
                            Id = 4,
                            BurningParameter = 1,
                            Name = "Brzuszki ze skrętem tłowia"
                        },
                        new
                        {
                            Id = 5,
                            BurningParameter = 1,
                            Name = "Pajacyki"
                        },
                        new
                        {
                            Id = 6,
                            BurningParameter = 1,
                            Name = "Scyzoryki"
                        },
                        new
                        {
                            Id = 7,
                            BurningParameter = 1,
                            Name = "Nożyce poziome"
                        },
                        new
                        {
                            Id = 8,
                            BurningParameter = 1,
                            Name = "Nożyce pionowe"
                        },
                        new
                        {
                            Id = 9,
                            BurningParameter = 1,
                            Name = "Wykroki"
                        },
                        new
                        {
                            Id = 10,
                            BurningParameter = 1,
                            Name = "Zakroki"
                        });
                });

            modelBuilder.Entity("Ravio.Entities.ExerciseResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRepetitions")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("ExercisesResults");
                });

            modelBuilder.Entity("Ravio.Entities.FoodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Grams")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calories = 120,
                            Grams = 60,
                            Name = "Chleb żytni"
                        },
                        new
                        {
                            Id = 2,
                            Calories = 150,
                            Grams = 60,
                            Name = "Chleb pszenny"
                        },
                        new
                        {
                            Id = 3,
                            Calories = 12,
                            Grams = 30,
                            Name = "Ser żółty"
                        },
                        new
                        {
                            Id = 4,
                            Calories = 63,
                            Grams = 125,
                            Name = "Jajko"
                        },
                        new
                        {
                            Id = 5,
                            Calories = 163,
                            Grams = 150,
                            Name = "Pierś z kurczaka"
                        },
                        new
                        {
                            Id = 6,
                            Calories = 100,
                            Grams = 50,
                            Name = "Ryż biały"
                        },
                        new
                        {
                            Id = 7,
                            Calories = 33,
                            Grams = 100,
                            Name = "Pomidor"
                        },
                        new
                        {
                            Id = 8,
                            Calories = 134,
                            Grams = 250,
                            Name = "Coca-cola"
                        },
                        new
                        {
                            Id = 9,
                            Calories = 15,
                            Grams = 20,
                            Name = "Wędlina drobiowa"
                        },
                        new
                        {
                            Id = 10,
                            Calories = 150,
                            Grams = 200,
                            Name = "Ziemniaki"
                        });
                });

            modelBuilder.Entity("Ravio.Entities.FoodResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TargetCalories")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FoodResults");
                });

            modelBuilder.Entity("Ravio.Entities.GenderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GenderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mężczyzna"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kobieta"
                        });
                });

            modelBuilder.Entity("Ravio.Entities.LifestyleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Parameter")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("LifestyleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Siedzący",
                            Parameter = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Przeciętny",
                            Parameter = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aktywny",
                            Parameter = 0.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sportowy",
                            Parameter = 0.0
                        });
                });

            modelBuilder.Entity("Ravio.Entities.TargetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TargetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Redukcja"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Utrzymania"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Przyrost"
                        });
                });

            modelBuilder.Entity("Ravio.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("GenderTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LifestyleTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TargetTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GenderTypeId");

                    b.HasIndex("LifestyleTypeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TargetTypeId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Ravio.Entities.WorkoutEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BurningParameter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurningParameter = 10,
                            Name = "Bieganie"
                        },
                        new
                        {
                            Id = 2,
                            BurningParameter = 5,
                            Name = "Spacerowanie"
                        },
                        new
                        {
                            Id = 3,
                            BurningParameter = 6,
                            Name = "Pływanie"
                        },
                        new
                        {
                            Id = 4,
                            BurningParameter = 10,
                            Name = "Jeżdżenie na rowerze"
                        },
                        new
                        {
                            Id = 5,
                            BurningParameter = 7,
                            Name = "Jeżdżenie na rolkach"
                        },
                        new
                        {
                            Id = 6,
                            BurningParameter = 8,
                            Name = "Jeżdżenie na łyżwach"
                        },
                        new
                        {
                            Id = 7,
                            BurningParameter = 8,
                            Name = "Wspinaczka górska"
                        },
                        new
                        {
                            Id = 8,
                            BurningParameter = 8,
                            Name = "Kajakarstwo"
                        },
                        new
                        {
                            Id = 9,
                            BurningParameter = 7,
                            Name = "Wioślarstwo"
                        },
                        new
                        {
                            Id = 10,
                            BurningParameter = 6,
                            Name = "Żeglowanie"
                        });
                });

            modelBuilder.Entity("Ravio.Entities.WorkoutResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageSpeed")
                        .HasColumnType("float");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutsResults");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ravio.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ravio.Entities.AddedFoodEntity", b =>
                {
                    b.HasOne("Ravio.Entities.FoodResultEntity", "FoodResult")
                        .WithMany("AddedFood")
                        .HasForeignKey("FoodResultId");

                    b.Navigation("FoodResult");
                });

            modelBuilder.Entity("Ravio.Entities.AwardEntity", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", "User")
                        .WithMany("Awards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ravio.Entities.BodyMessurementsEntity", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", "User")
                        .WithMany("BodyMessurements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ravio.Entities.CoordinatesEntity", b =>
                {
                    b.HasOne("Ravio.Entities.WorkoutResultEntity", null)
                        .WithMany("Coordinates")
                        .HasForeignKey("WorkoutResultEntityId");
                });

            modelBuilder.Entity("Ravio.Entities.ExerciseResultEntity", b =>
                {
                    b.HasOne("Ravio.Entities.ExerciseEntity", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("Ravio.Entities.UserEntity", "User")
                        .WithMany("ExercisesResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ravio.Entities.FoodResultEntity", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", "User")
                        .WithMany("FoodResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ravio.Entities.UserEntity", b =>
                {
                    b.HasOne("Ravio.Entities.GenderType", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderTypeId");

                    b.HasOne("Ravio.Entities.LifestyleType", "Lifestyle")
                        .WithMany()
                        .HasForeignKey("LifestyleTypeId");

                    b.HasOne("Ravio.Entities.TargetType", "Target")
                        .WithMany()
                        .HasForeignKey("TargetTypeId");

                    b.Navigation("Gender");

                    b.Navigation("Lifestyle");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Ravio.Entities.WorkoutResultEntity", b =>
                {
                    b.HasOne("Ravio.Entities.UserEntity", "User")
                        .WithMany("WorkoutsResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ravio.Entities.WorkoutEntity", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId");

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Ravio.Entities.FoodResultEntity", b =>
                {
                    b.Navigation("AddedFood");
                });

            modelBuilder.Entity("Ravio.Entities.UserEntity", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("BodyMessurements");

                    b.Navigation("ExercisesResults");

                    b.Navigation("FoodResults");

                    b.Navigation("WorkoutsResults");
                });

            modelBuilder.Entity("Ravio.Entities.WorkoutResultEntity", b =>
                {
                    b.Navigation("Coordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
