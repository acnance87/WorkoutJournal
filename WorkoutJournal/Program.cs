using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Repository;
using WorkoutJournal.Managers;
using WorkoutJournal.Managers.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

builder.Services.AddDbContext<WorkoutJournalContext>(
    opts => opts.UseSqlServer("name=ConnectionStrings:WorkoutJournalContext"), 
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Transient
    );

builder.Services.AddTransient<IWorkoutJournalRepository, WorkoutJournalRepository>();
builder.Services.AddTransient<IWorkoutJournalContract, WorkoutJournalManager>();


var app = builder.Build();

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
