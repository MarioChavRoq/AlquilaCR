using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region BataBase

builder.Services.AddDbContext<AlquilaCrContext>(optionsAction =>
                    optionsAction
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionMario"))
);

#endregion

#region DI


builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IUsuariosDAL, UsuariosDAL>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolesDAL, RolesDAL>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUsuarioRolesDAL, UsuarioRolesDAL>();
builder.Services.AddScoped<IUsuarioRoleService, UsuarioRoleService>();
builder.Services.AddScoped<IPropiedadesDAL, PropiedadesDAL>();
builder.Services.AddScoped<IPropiedadService, PropiedadService>();
builder.Services.AddScoped<IImagenesPropiedadDAL, ImagenesPropiedadDAL>();
builder.Services.AddScoped<IImagenesPropiedadService, ImagenesPropiedadService>();



#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
