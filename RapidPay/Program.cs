using BusinessLogic.Implementations;
using BusinessLogic.Interfaces;
using BusinessLogic.Validations;
using Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RapidPay;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddFluentValidation((options) => options.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(CardDtoValidator))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
    options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<Context>((options) =>
{
    options.UseInMemoryDatabase("RapidPay");
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
app.UseMiddleware<ErrorHandlerMiddleware>();
app.Run();
