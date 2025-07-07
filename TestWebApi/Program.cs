using Microsoft.EntityFrameworkCore;
using Serilog;
using TestWebApi;
using TestWebApi.Controllers;
using TestWebApi.Entities;
using TestWebApi.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("log/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Logging.AddConsole();
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();

#if DEBUG
builder.Services.AddTransient<IMailService,LocalMailService>();
#else
builder.Services.AddTransient<IMailService,CloudMailService>();
#endif

builder.Services.AddDbContext<CityInfoContext>((DbContextOptions =>
{
    DbContextOptions.UseSqlServer(builder.Configuration.GetSection("Database")["ConnectionString"]);
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints((endpoints) =>
{
    endpoints.MapControllers(); 
});

app.Run();
