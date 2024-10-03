using Microsoft.EntityFrameworkCore;
using NetforemostAPI.Models.Data;
using NetforemostAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Servicios
builder.Services.AddDbContext<NetforemostDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<ISaldosRepository, SaldosRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("myCORS", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod() 
               .AllowAnyHeader(); 
    });
});


#endregion
var app = builder.Build();
#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("myCORS");
app.UseAuthorization();

app.MapControllers();
#endregion
app.Run();
