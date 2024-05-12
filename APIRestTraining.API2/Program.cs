using APIRestTraining.Datos.Colegio;
using APIRestTraining.Datos.Colegio.Implementacion;
using APIRestTraining.Model.Conexion;
using APIRestTraining.Negocio.Colegio;
using APIRestTraining.Negocio.Colegio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ConexionSql>();
builder.Services.AddScoped<IServicioAlumnos, ServicioAlumnos>();
builder.Services.AddScoped<IAlumnosDataMapper, AlumnosDataMapper>();

builder.Services.Configure<ConexionString>(builder.Configuration.GetSection("ConnectionStrings"));

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
