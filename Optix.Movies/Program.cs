using Optix.Movies.Data;
using Microsoft.EntityFrameworkCore;
using Optix.Movies.Api;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));
builder.Services.AddHttpClient();


// Add services to the container.

builder.Services.AddControllers()
                              .AddOData(option => option.Select()
                              .Filter()
                              .Count()
                              .OrderBy()
                              .Expand()
                              .SetMaxTop(100)
                              );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add movie services
builder.Services.AddMovieServices();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
