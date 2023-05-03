using FinanceManagerAPI.Data;
using FinanceManagerAPI.MappingProfiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FinanceManagerDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("FinanceManagerDb")));
builder.Services.AddControllers();

// AutoMapper configuration
builder.Services.AddAutoMapper(typeof(UserAccountProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
