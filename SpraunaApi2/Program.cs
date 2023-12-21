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

builder.Services.AddControllers(); // ���������� ����������� ��� �������������


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
            // ���������, ����� �� �������������� �������� ��� ��������� ������
            ValidateIssuer = true,
            // ������, �������������� ��������
            ValidIssuer = AuthOptions.ISSUER,
            // ����� �� �������������� ����������� ������
            ValidateAudience = true,
            // ��������� ����������� ������
            ValidAudience = AuthOptions.AUDIENCE,
            // ����� �� �������������� ����� �������������
            ValidateLifetime = true,
            // ��������� ����� ������������
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ��������� ����� ������������
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddCors(); // ��������� ������� CORS

var app = builder.Build();

// ����������� CORS
app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // ���������� ������������� �� �����������

app.Map("/login/{username}", 
    (string username) 
    => {
    var claims = new List<Claim> { 
        new Claim(ClaimTypes.Name, username) 
    };
    // ������� JWT-�����
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

    // �������� ������������ �� id
    Package? track = new Package();
    // Package? package = packages.FirstOrDefault(u => u.Id == id);

    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    if (track == null) 
        return Results.NotFound(
            new { message = $"Track (id: {id}) not found. " });

    // ���� track ������, ���������� ���
    return Results.Json(track);
});

app.Run();

public class AuthOptions
{
    public const string ISSUER = "SpAuthServer"; // �������� ������
    public const string AUDIENCE = "SpAuthClient"; // ����������� ������
    const string KEY = "SpSecretKey@050914";   // ���� ��� ��������
    // public var LIFETIME = DateTime.UtcNow.Add(TimeSpan.FromMinutes(525600)); // ����� ����� ������ - 1 ������
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}