using FernwehApi.Repositories;
using FernwehApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FernwehApi.Database.Models;
using FernwehApi.Providers;
using FernwehApi.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("connectionstrings.json");
builder.Configuration.AddJsonFile("secrets.json");
builder.Services.AddDbContext<FernwehDbContext>();

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


builder.Services.AddScoped<IEnumService, EnumService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IGooglePlacesProvider, GooglePlacesProvider>();
builder.Services.AddScoped<IOsmOverpassProvider, OsmOverpassProvider>();
builder.Services.AddScoped<INominatimProvider, NominatimProvider>();

builder.Services.AddScoped<IPlacesDbRepository, PlacesDbRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceItemRepository, PlaceItemRepository>();

builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

var app = builder.Build();

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
