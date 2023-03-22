using Microsoft.EntityFrameworkCore;
using SimpleCollab.Data.Context;
using SimpleCollab.Data.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext
               >(dbOption =>
               {
                   var ConnectionString = builder.Configuration.GetSection("ConnectionStrings")["ConnString"];
                   dbOption.UseSqlServer(ConnectionString);
               });
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<ApiDbContext>>();
builder.Services.AddAutoMapper(Assembly.Load("SimpleCollab.Models"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
