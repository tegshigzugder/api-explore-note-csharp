using ExploreNoteApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExploreNoteApi.Database.Models;
using ExploreNoteApi.Providers;
using ExploreNoteApi.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("connectionstrings.json");
builder.Configuration.AddJsonFile("secrets.json");

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
	.AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });

builder.Services.AddDbContext<ExploreNoteDbContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("Database"),
		ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Database"))), ServiceLifetime.Transient);

builder.Services.AddScoped<IEnumService, EnumService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IOverpassProvider, OverpassProvider>();
builder.Services.AddScoped<INominatimProvider, NominatimProvider>();

builder.Services.AddScoped<IPlacesDbRepository, PlacesDbRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceItemRepository, PlaceItemRepository>();

builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

ExploreNoteApi.Runtime.Program.Instance.ConfigureRuntimeRequiredBuilder(builder);

// Add services to the container.
builder.Services.AddHealthChecks();

var app = builder.Build();

// Map the health check endpoint.
app.MapHealthChecks("/health");

ExploreNoteApi.Runtime.Program.Instance.ConfigureRuntimeApplication(app, builder);

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseCors();

app.Run();

namespace ExploreNoteApi.Runtime
{
	public partial class Program
	{
		public static RuntimeConfig Instance { get; set; } = new();
	}

	public class RuntimeConfig
	{
		public virtual void ConfigureRuntimeRequiredBuilder(WebApplicationBuilder builder)
		{
		}

		public virtual void ConfigureRuntimeApplication(WebApplication application, WebApplicationBuilder builder)
		{
		}
	}
}
