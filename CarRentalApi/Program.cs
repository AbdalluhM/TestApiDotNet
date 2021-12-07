using CarRentalApi.Data;
using CarRentalApi.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opts =>
{
    var connString = builder.Configuration.GetConnectionString("DefaultConnectionStrng");
    opts.UseSqlServer(connString, options =>
    {
        options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName.Split(',')[0]);
    });
});

builder.Services.AddTransient<BookService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
