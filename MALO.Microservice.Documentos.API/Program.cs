
using MALO.Microservice.Documentos.Aplication.Services;
using MALO.Microservice.Documentos.Domain.Interfaces.Helpers;
using MALO.Microservice.Domumentos.Infraestructure.Helpers;

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

//Configuration Azure Key Vault
//builder.Configuration.AzureKeyVault(builder);
// DependencyContainers classes, it's a run time dependency
builder.Services.AddApplicationServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilesHelper, FilesHelper>();
builder.Services.AddScoped<FileService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        builder =>
        {
            builder
            .AllowCredentials()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .WithMethods("GET", "POST", "OPTIONS")  // Aseg�rate de que 'OPTIONS' est� permitido
                   .SetIsOriginAllowed(origin => true);
        });
});

var app = builder.Build();
//var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";  // Usa 8080 como valor por defecto si no se define el puerto
//app.Urls.Add($"http://*:{port}");


// Configure the HTTP request pipeline.
if (Environment.GetEnvironmentVariable("ASPNETCORE_SWAGGER_UI_ACTIVE") == "On" || app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSession();
    app.UseDeveloperExceptionPage();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GI.GestorInventarios.API");
        c.DefaultModelsExpandDepth(-1);
        c.InjectStylesheet("./swagger/ui/custom.css");
        c.DisplayRequestDuration();
        c.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigins");
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