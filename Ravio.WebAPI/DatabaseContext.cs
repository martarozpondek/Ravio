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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Ravio"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>().Ignore(entity => entity.Age);
            builder.Entity<UserEntity>().Ignore(entity => entity.BMI);

            builder.Entity<FoodResultEntity>().Ignore(entity => entity.Calories);
        }
    }
}
