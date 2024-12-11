using DataAccess;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using TestWorkerService;

var builder = Host.CreateApplicationBuilder(args);



builder.Services.AddHangfire(config => config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<TestAppDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfireServer();

// Register the UpsertJob for dependency injection
builder.Services.AddSingleton<UpsertJob>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
