using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Components;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<WorkoutJournalContext>(
    opts => opts.UseSqlServer("name=ConntectionStrings:WorkoutJournalText"), 
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Transient
    );

builder.Services.AddTransient<IWorkoutJournalRepository, WorkoutJournalRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
