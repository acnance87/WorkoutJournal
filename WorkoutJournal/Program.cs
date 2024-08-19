using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Repository;
using WorkoutJournal.Managers;
using WorkoutJournal.Managers.Contracts;
using Newtonsoft.Json;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var env = builder.Environment;

        // Add services to the container.
        builder.Services.AddMvc().AddNewtonsoftJson(
                  options => {
                      options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  });

        builder.Services.AddDbContext<WorkoutJournalContext>(opts => opts.UseInMemoryDatabase("WorkoutJournal"));

        builder.Services.AddTransient<IWorkoutJournalRepository, WorkoutJournalRepository>();
        builder.Services.AddTransient<IWorkoutJournalContract, WorkoutJournalManager>();

        var app = builder.Build();

        Configure(app, env);

        app.UseStaticFiles();

        app.MapDefaultControllerRoute();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.Run();

        void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WorkoutJournalContext>();
            CreateDatabaseTables(context);
        }

        void CreateDatabaseTables(WorkoutJournalContext context) {
            IEnumerable<WorkoutTypes> workoutTypes = new List<WorkoutTypes>() {
        new() { ExerciseName = "Biceps Curl" },
        new() { ExerciseName = "Chest Press" },
        new() { ExerciseName = "Deadlift" },
        new() { ExerciseName = "Triceps Extension" },
    };
            context.AddRange(workoutTypes);
            context.SaveChanges();
        }
    }
}