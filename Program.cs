using CodeInterview.Application.Services;
using CodeInterview.Application.Services.Interfaces;
using CodeInterview.Infra.Context;
using CodeInterview.Infra.Repositories;
using Microex.Swagger.SwaggerGen.Application;
using Microex.Swagger.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("TestDb"));

builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<IUsersServices, UsersServices>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "",
        Description = "Code Interview",
        Contact = new OpenApiContact
        {
            Name = "Paulo Henrique Camargo",
            Email = "oluapcamargo@gmail.com",
            Url = new Uri("https://github.com/oluapcamargo"),
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger().UseSwaggerUI3(setup =>
{
    setup.RoutePrefix = "swagger";
    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    setup.DocExpansion(DocExpansion.List);
    setup.DisplayRequestDuration();
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.UseRouting();

app.Run();
