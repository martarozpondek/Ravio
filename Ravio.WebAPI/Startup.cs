using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using Ravio.WebAPI.Services;
using System.Text;
using System.Text.Json.Serialization;

namespace Ravio.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors();

            serviceCollection.AddRouting();

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters { ValidateIssuer = false, ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Key"))), ValidateAudience = false, ValidateLifetime = false });

            serviceCollection.AddAuthorization();

            serviceCollection.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });

            serviceCollection.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Ravio")));

            serviceCollection.AddIdentity<UserEntity, IdentityRole<int>>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            serviceCollection.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
            serviceCollection.AddScoped<IExercisesRepository, ExercisesRepository>();
            serviceCollection.AddScoped<IFoodRepository, FoodRepository>();

            serviceCollection.AddScoped<IWorkoutsResultsRepository, WorkoutsResultsRepository>();
            serviceCollection.AddScoped<IExercisesResultsRepository, ExercisesResultsRepository>();
            serviceCollection.AddScoped<IFoodResultsRepository, FoodResultsRepository>();

            serviceCollection.AddScoped<IWorkoutsResultsService, WorkoutsResultsService>();
            serviceCollection.AddScoped<IExercisesResultsService, ExercisesResultsService>();
            serviceCollection.AddScoped<IFoodResultsService, FoodResultsService>();

            serviceCollection.AddScoped<IBodiesMessurementsRepository, BodiesMessurementsRepository>();
            serviceCollection.AddScoped<IUsersService, UsersService>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
