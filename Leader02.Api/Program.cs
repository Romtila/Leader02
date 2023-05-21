using Leader02.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.AddDbContext<Leader02Context>(options =>
    options.UseNpgsql(configuration.GetConnectionString("Leader02")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();