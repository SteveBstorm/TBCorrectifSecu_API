using CorrectifSecu_API.Services;
using CorrectifSecu_BLL.LocalServices;
using CorrectifSecu_DAL.Repositories;
using CorrectifSecu_DAL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IAppUserRepository, AppUserService>();
builder.Services.AddSingleton<IAppRoleRepository, AppRoleService>();
builder.Services.AddSingleton<IBeerRepository, BeerService>();
builder.Services.AddScoped<TokenManager>();
builder.Services.AddSingleton<LocalUserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("tokenValidation").GetSection("secret").Value)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("tokenValidation").GetSection("issuer").Value,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("tokenValidation").GetSection("audience").Value
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("userPolicy", policy => policy.RequireRole("User", "Admin", "Moderator"));
    options.AddPolicy("modoPolicy", policy => policy.RequireRole("Admin", "Moderator"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
