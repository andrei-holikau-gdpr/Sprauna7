using CoreBusiness;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Plugins.DataStore.SQL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using UseCases.DataStorePluginInterfaces;
using UseCases.PackagesUseCases;
using UseCases.UseCaseInterfaces;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers(); // используем контроллеры без представлений


builder.Services.AddDbContext<SpraunaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

builder.Services.AddTransient<IViewPackagesUseCase, ViewPackagesUseCase>();
builder.Services.AddTransient<IGetPackageByIdUseCase, GetPackageByIdUseCase>();
builder.Services.AddTransient<IEditPackageUseCase, EditPackageUseCase>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddCors(); // добавляем сервисы CORS

var app = builder.Build();

// настраиваем CORS
app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // подключаем маршрутизацию на контроллеры

app.Map("/login/{username}", 
    (string username) 
    => {
    var claims = new List<Claim> { 
        new Claim(ClaimTypes.Name, username) 
    };
    // создаем JWT-токен
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            // expires: AuthOptions.LIFETIME,
            expires: new DateTime(2025, 2, 15),
            signingCredentials: new SigningCredentials(
                AuthOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));

    return new JwtSecurityTokenHandler().WriteToken(jwt);
});

app.Map("/data", 
    [Authorize] 
    () => new { message = "Hello World!" });



app.MapGet("/tasktest/{id}",
    [Authorize]
    (string id) =>
{

    // получаем пользователя по id
    Package? track = new Package();
    // Package? package = packages.FirstOrDefault(u => u.Id == id);

    // если не найден, отправляем статусный код и сообщение об ошибке
    if (track == null) 
        return Results.NotFound(
            new { message = $"Track (id: {id}) not found. " });

    // если track найден, отправляем его
    return Results.Json(track);
});

app.Run();

public class AuthOptions
{
    public const string ISSUER = "SpAuthServer"; // издатель токена
    public const string AUDIENCE = "SpAuthClient"; // потребитель токена
    const string KEY = "SpSecretKey@050914";   // ключ для шифрации
    // public var LIFETIME = DateTime.UtcNow.Add(TimeSpan.FromMinutes(525600)); // время жизни токена - 1 минута
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}