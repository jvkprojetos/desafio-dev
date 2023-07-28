using DesafioDev.Application;
using DesafioDev.Infra.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication().AddRepositories(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DesafioDev",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jo�o Vitor",
            Email = "jvkprojetos@outlook.com"
        },
        Description = "DesafioDev: para integrar seu sistema com nossa api, siga o guia de end-points abaixo, nele consta o tipo, corpo da requisi��o, tipos de retorno e tipo de dado esperado na opera��o."
    });
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RunMigration();

app.Run();
