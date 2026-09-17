using Microsoft.EntityFrameworkCore;
using Sporkocu.Domain.Entities;
using Sporkocu.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.EFCore
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCoachConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new NutritionPlanConfiguration());
            modelBuilder.ApplyConfiguration(new NutritionPlanDetailConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleLessonConfiguration());
            // configurations
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<NutritionPlan> NutritionPlan { get; set; }
        public DbSet<NutritionPlanDetail> NutritionPlanDetail { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Right> Right { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ScheduleLesson> ScheduleLesson { get; set; }
        public DbSet<StudentCoach> StudentCoach { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }


    }
}
