using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ravio.Entities;

namespace Ravio.WebAPI
{
    public class DatabaseContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public DatabaseContext() : base()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public virtual DbSet<UserEntity> Accounts { get; set; }
        public virtual DbSet<GenderType> GenderTypes { get; set; }
        public virtual DbSet<LifestyleType> LifestyleTypes { get; set; }
        public virtual DbSet<TargetType> TargetTypes { get; set; }
        public virtual DbSet<BodyMessurementsEntity> BodiesMessurements { get; set; }

        public virtual DbSet<WorkoutEntity> Workouts { get; set; }
        public virtual DbSet<WorkoutResultEntity> WorkoutsResults { get; set; }
        public virtual DbSet<CoordinatesEntity> Coordinates { get; set; }

        public virtual DbSet<ExerciseEntity> Exercises { get; set; }
        public virtual DbSet<ExerciseResultEntity> ExercisesResults { get; set; }

        public virtual DbSet<FoodEntity> Food { get; set; }
        public virtual DbSet<FoodResultEntity> FoodResults { get; set; }
        public virtual DbSet<AddedFoodEntity> AddedFood { get; set; }

        public virtual DbSet<AwardEntity> Awards { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>().HasMany(u => u.BodyMessurements).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserEntity>().HasMany(u => u.WorkoutsResults).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserEntity>().HasMany(u => u.ExercisesResults).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserEntity>().HasMany(u => u.FoodResults).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserEntity>().HasMany(u => u.Awards).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);

          
            

            builder.Entity<GenderType>().HasData(new GenderType {Id = 1, Name = "Mężczyzna" });
            builder.Entity<GenderType>().HasData(new GenderType {Id = 2, Name = "Kobieta" });
            builder.Entity<LifestyleType>().HasData(new LifestyleType { Id=1, Name = "Siedzący" });
            builder.Entity<LifestyleType>().HasData(new LifestyleType { Id=2, Name = "Przeciętny" });
            builder.Entity<LifestyleType>().HasData(new LifestyleType { Id=3, Name = "Aktywny" });
            builder.Entity<LifestyleType>().HasData(new LifestyleType { Id=4, Name = "Sportowy" });
            builder.Entity<TargetType>().HasData(new TargetType { Id=1, Name = "Redukcja" });
            builder.Entity<TargetType>().HasData(new TargetType { Id=2, Name = "Utrzymania" });
            builder.Entity<TargetType>().HasData(new TargetType { Id=3, Name = "Przyrost" });
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=1, Name = "Przysiady", BurningParameter= 1});
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=2, Name = "Pompki", BurningParameter = 1});
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=3, Name = "Brzuszki", BurningParameter =  1});
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=4, Name = "Brzuszki ze skrętem tłowia", BurningParameter =1  });
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=5, Name = "Pajacyki", BurningParameter = 1 });
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=6, Name = "Scyzoryki", BurningParameter =  1});
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=7, Name = "Nożyce poziome", BurningParameter = 1 });
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=8, Name = "Nożyce pionowe", BurningParameter = 1 });
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=9, Name = "Wykroki", BurningParameter =  1});
            builder.Entity<ExerciseEntity>().HasData(new ExerciseEntity { Id=10, Name = "Zakroki", BurningParameter =   1});
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=1, Name = "Bieganie", BurningParameter=10 });
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=2, Name = "Spacerowanie", BurningParameter=5 });
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=3, Name = "Pływanie", BurningParameter= 6});
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=4, Name = "Jeżdżenie na rowerze", BurningParameter= 10});
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=5, Name = "Jeżdżenie na rolkach", BurningParameter= 7 });
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=6, Name = "Jeżdżenie na łyżwach", BurningParameter= 8});
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=7, Name = "Wspinaczka górska", BurningParameter=8 });
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=8, Name = "Kajakarstwo", BurningParameter= 8});
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=9, Name = "Wioślarstwo", BurningParameter=7 });
            builder.Entity<WorkoutEntity>().HasData(new WorkoutEntity { Id=10, Name = "Żeglowanie", BurningParameter=6 });
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =1, Name= "Chleb żytni", Grams= 60, Calories=120});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =2, Name= "Chleb pszenny", Grams= 60, Calories=150});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =3, Name= "Ser żółty", Grams= 30, Calories=12});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =4, Name= "Jajko", Grams= 125, Calories=63});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =5, Name= "Pierś z kurczaka", Grams= 150, Calories=163});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =6, Name= "Ryż biały", Grams= 50, Calories=100});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =7, Name= "Pomidor", Grams= 100, Calories=33});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =8, Name= "Coca-cola", Grams= 250, Calories=134});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =9, Name= "Wędlina drobiowa", Grams= 20, Calories=15});
            builder.Entity<FoodEntity>().HasData(new FoodEntity { Id =10, Name= "Ziemniaki", Grams= 200, Calories=150});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=SERVER-ROBIRT\\SQLDEVELOPER;Initial Catalog=Ravio;User Id=sa;Password=CortX-1RDS;");
        }
    }
}
