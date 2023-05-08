using Api.OptionsSetup;
using Application;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Authentication;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Environment.IsDevelopment();

builder.Services
          .AddApplication()
          .AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

builder.Host.UseSerilog((context, configuration) =>
                        configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op => op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "passapp",
        ValidAudience = "passapp",
        SaveSigninToken = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("_d6IIvvPnPYTMeVnHtaKb1sUJQlap9GtuorZ1D9MGl4"))
    });

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

var app = builder.Build();

// add hardcoded test user to db on startup
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var testUser = new User
        {
            Id = 1,
            Email = "agustinyuse@gmail.com",
            Password = "password"
        };

        context.Users.Add(testUser);
        context.SaveChanges();


        context.Roles.Add(Role.Registered);
        context.SaveChanges();
        context.UserRoles.Add(new UserRole() { RoleId = 1, UserId = 1 });
        context.SaveChanges();
        IEnumerable<Permission> permissions = Enum.GetValues<Domain.Enums.Permission>().Select(p => new Permission()
        {
            PermissionId = (int)p,
            Name = p.ToString()
        });
        foreach (Permission permission in permissions)
        {
            context.Permissions.Add(permission);
            context.SaveChanges();
        }
        context.RolePermissions.Add(new RolePermission() { RoleId = 1, PermissionId = 1 });
        context.RolePermissions.Add(new RolePermission() { RoleId = 1, PermissionId = 2 });

        context.SaveChanges();
    }
    catch (Exception ex)
    {

        throw;
    }
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
