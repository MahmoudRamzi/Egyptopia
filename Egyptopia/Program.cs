using Egyptopia.Domain.DTOs.Authentication;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence;
using Egyptopia.Persistence.Context;
using EgyptopiaApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
#region Services

#region Add Cores
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion


#region Asp Identity
builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
})
    .AddEntityFrameworkStores<DataContext>();
#endregion

#region Controllers And Swagger
// Add services to the container.
builder.Services.ConfigurePersistance(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Egyptopia", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

#endregion

#region Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "default";
    options.DefaultChallengeScheme = "default";
})
    .AddJwtBearer("default", options =>
    {
        var secretkey = builder.Configuration.GetValue<string>("secretkey");
        var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
        var key = new SymmetricSecurityKey(secretkeyinbytes);
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuer = false,  
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });
#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Manager",policy => 
    policy
    .RequireClaim(ClaimTypes.Role,"Manager")
    .RequireClaim("Country", "Egypt")
    );
});

#endregion

#endregion

var app = builder.Build();

#region Middelwares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
//app.MapIdentityApi<ApplicationUser>();

app.MapControllers();
#endregion

app.Run();