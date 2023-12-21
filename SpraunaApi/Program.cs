using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Plugins.DataStore.SQL;
using System.Text;
using UseCases.DataStorePluginInterfaces;
using UseCases.PackagesUseCases;
using UseCases.UseCaseInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SpraunaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPackageRepository, PackageRepository>();

builder.Services.AddTransient<IViewPackagesUseCase, ViewPackagesUseCase>();
builder.Services.AddTransient<IGetPackageByIdUseCase, GetPackageByIdUseCase>();
builder.Services.AddTransient<IEditPackageUseCase, EditPackageUseCase>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.Audience = "myapi";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SpSecretKey@050914")),
            ValidateIssuer = true,
            ValidIssuer = "https://localhost:5001",
            ValidateAudience = true,
            ValidAudience = "myapi"
        };
    });

/*
 services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = Configuration["Jwt:Authority"];
            options.Audience = Configuration["Jwt:Audience"];
        });
 */

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage(); // New
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
