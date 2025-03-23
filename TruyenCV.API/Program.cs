using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using TruyenCV.Application;
using TruyenCV.Infrastructure;
using TruyenCV.Infrastructure.Data;
using TruyenCV.Infrastructure.Identity;
using TruyenCV.Share;

var builder = WebApplication.CreateBuilder(args);

// ? Thêm các Service vào DI Container
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddShareServices();

builder.Services.AddControllers();

// ? C?u hình Swagger v?i xác th?c JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TruyenChu API",
        Version = "v1",
        Description = "API TruyenCV",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@example.com"
        }
    });

    // ? Thêm h? tr? JWT Token vào Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Nh?p 'Bearer {token}' ?? xác th?c.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});

var app = builder.Build();

// ? Ch?y `DbInitializer` khi ?ng d?ng kh?i ??ng
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityApplicationUser>>();

    await DbInitializer.SeedRoles(roleManager);
    await DbInitializer.SeedAdminUser(userManager);
}

// ? C?u hình Middleware
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TruyenChu API v1");
        c.RoutePrefix = string.Empty; // M?c ??nh Swagger ? `/`
    });
}

app.UseHttpsRedirection();
app.UseAuthentication(); // ? ??m b?o API yêu c?u xác th?c n?u c?n
app.UseAuthorization();

app.MapControllers();

app.Run();
