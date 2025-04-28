using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using System.Reflection;
using Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gracosoft .NET CORe",
        Description = "Aplicación elaborada durante las clases del 1 al 9 de la asignatura .Net Core, se encarga del procesamiento de la lógica de un videojuego RPG.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Guillermo Giménez",
            Url = new Uri("https://github.com/GGimenezG/GracoNETCore")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // To Enable authorization using Swagger (JWT)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });


    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IPersonajeService), typeof(PersonajeService));
builder.Services.AddScoped(typeof(IHabilidadService), typeof(HabilidadService));

builder.Services.AddScoped(typeof(IEquipoService), typeof(EquipoService));
builder.Services.AddScoped(typeof(IMisionService), typeof(MisionService));
builder.Services.AddScoped(typeof(IUbicacionService), typeof(UbicacionService));
builder.Services.AddScoped(typeof(IEnemigoService), typeof(EnemigoService));
builder.Services.AddScoped(typeof(IEquipoService), typeof(EquipoService));

builder.Services.AddScoped(typeof(IPersonajeRepository), typeof(PersonajeRepository));
builder.Services.AddScoped(typeof(IHabilidadRepository), typeof(HabilidadRepository));
builder.Services.AddScoped(typeof(IObjetivoRepository), typeof(ObjetivoRepository));
builder.Services.AddScoped(typeof(IObjetoRepository), typeof(ObjetoRepository));
builder.Services.AddScoped(typeof(IEquipoRepository), typeof(EquipoRepository));
builder.Services.AddScoped(typeof(IEstadisticaRepository), typeof(EstadisticaRepository));
builder.Services.AddScoped(typeof(IMisionRepository), typeof(MisionRepository));
builder.Services.AddScoped(typeof(IPersonajeMisionRepository), typeof(PersonajeMisionRepository));
builder.Services.AddScoped(typeof(IRanuraRepository), typeof(RanuraRepository));
builder.Services.AddScoped(typeof(ITipoEstadisticaRepository), typeof(TipoEstadisticaRepository));
builder.Services.AddScoped(typeof(ITipoObjetoRepository), typeof(TipoObjetoRepository));
builder.Services.AddScoped(typeof(IUbicacionRepository), typeof(UbicacionRepository));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(patata =>
        patata.UseNpgsql("Host=dpg-d07up2qdbo4c73btv6a0-a;Server=dpg-d07up2qdbo4c73btv6a0-a.oregon-postgres.render.com;Port=5432;Database=netcore2025gracotaller;Username=netcore2025gracotaller_user;Password=JySaSfBbVSvDX4BZSLhgjJYxOVTCntx8;Include Error Detail=true;",
        b => b.MigrationsAssembly("Infrastructure")));


//builder.Services.AddDbContext<AppDbContext>(options =>
//                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//            );

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();
//app.Services.a

app.UseAuthentication();
app.UseAuthorization();



app.Run();

