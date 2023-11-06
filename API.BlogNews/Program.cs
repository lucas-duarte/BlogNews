using API.BlogNews.Controllers;
using API.BlogNews.Helpers;
using API.BlogNews.Interfaces;
using API.BlogNews.Services;
using Database.BlogNews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Web;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.
var connectionStringDatabase = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogNewsDbContext>(options => options.UseSqlServer(connectionStringDatabase)
                                                                            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.ContextInitialized)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BlogNewsDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INoticiaService, NoticiaService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
