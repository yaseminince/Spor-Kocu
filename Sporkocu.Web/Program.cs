using Microsoft.EntityFrameworkCore;
using Sporkocu.Application.Interfaces;
using Sporkocu.Application.Services;
using Sporkocu.Infrastructure.EFCore;
using Sporkocu.Infrastructure.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSession();


builder.Services.DependencyInjection();

builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<INutritionPlanService, NutritionPlanService>();
builder.Services.AddScoped<INutritionPlanDetailService, NutritionPlanDetailService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IRightService, RightService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IScheduleLessonService, ScheduleLessonService>();
builder.Services.AddScoped<IStudentCoachService, StudentCoachService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
