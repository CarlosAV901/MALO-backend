using MALO.Microservice.Empresas.API.Extensions;
using MALO.Microservice.Empresas.Application;
using MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure;
using MALO.Microservice.Empresas.Infrastructure.DataContexts;
using MALO.Microservice.Empresas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();

builder.Services.AddControllers();
builder.Services.AddSwagger(builder);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

// Register the new ManosALaObraContextEmpresas
builder.Services.AddSingleton<ManosALaObraContextEmpresas>();

// Register the repositories and services
builder.Services.AddScoped<IEmpresasRepository, EmpresasRepository>(); // Registro del repositorio
builder.Services.AddScoped<EmpresasService>(); // Registro del servicio

// Configuration for other services
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (Environment.GetEnvironmentVariable("ASPNETCORE_SWAGGER_UI_ACTIVE") == "On" || app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSession();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GI.GestorInventarios.API");
        c.DefaultModelsExpandDepth(-1);
        c.InjectStylesheet("./swagger/ui/custom.css");
        c.DisplayRequestDuration();
        c.RoutePrefix = string.Empty;
    });
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowedOrigins");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
public partial class Program { }
