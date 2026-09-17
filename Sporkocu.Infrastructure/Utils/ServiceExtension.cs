using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sporkocu.Application.Interfaces.Repository;
using Sporkocu.Application.Interfaces.Repository.Base;
using Sporkocu.Infrastructure.EFCore;
using Sporkocu.Infrastructure.Repository;
using Sporkocu.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Utils
{
    public static class ServiceExtension
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<SportContext>(options => options.UseSqlite("Data Source=sporkocu.db"));
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<INutritionPlanRepository, NutritionPlanRepository>();
            services.AddScoped<INutritionPlanDetailRepository, NutritionPlanDetailRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IRightRepository, RightRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IScheduleLessonRepository, ScheduleLessonRepository>();
            services.AddScoped<IStudentCoachRepository, StudentCoachRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
