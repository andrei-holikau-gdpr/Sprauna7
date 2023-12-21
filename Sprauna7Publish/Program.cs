using Plugins.DataStore.InMemory;
using Sprauna7Publish.Data;
using UseCases.CategoriesUseCase;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.DepartmentDeliveryParcels;
using UseCases.PackagesUseCases;
using UseCases.ProductsSpUseCases;
using UseCases.PurchasesUseCases;
using UseCases.ReceiversUseCases;
using UseCases.RegionsUseCases;
using UseCases.UseCaseInterfaces;
using UseCases;
using Microsoft.EntityFrameworkCore;
using Sprauna7Publish.Areas.Identity.Data;
using UseCases.CostOfDeliveriesUseCases;
using Sprauna7Publish.SpPlugins.SpLogger;
using Plugins.MailKitSp.Interfaces;
using Plugins.MailKitSp.Services;
using Plugins.MailKitSp.Models;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;
using UseCases.ShopByShop.PvzSbsUseCases;
using UseCases.ShopByShop;
using Plugins.ShopByShop.Services;
using CoreBusiness.ShopByShop.Models;
using UseCases.ShopByShop.TrackSbsUseCases;
using UseCases.ShopByShop.RecipientSbsUseCases;
using Plugins.DataStore.SQL;
using UseCasesSp.FileSpUseCases;
using UseCasesSp.DirectorySpUseCases;
using UseCasesSp.UseCaseInterfaces;
using UseCasesSp.ProductsSpUseCases;
using UseCasesSp;
// using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AccountContextConnection") 
        ?? throw new InvalidOperationException("\t SpLog, program.cs InvalidOperationException AccountContextConnection, Time:" + DateTime.Now.ToLongTimeString());

builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages(); // Add services to the container.
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddDbContext<SpraunaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Authorization Services
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
});
#endregion
// ---
#region DI for In-Memory Data Store Repository

//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddScoped<IPackageRepository, PackageInMemoryRepository>();
//builder.Services.AddScoped<IProductSpRepository, ProductSpInMemoryRepository>();
//builder.Services.AddScoped<IPurchaseRepository, PurchaseInMemoryRepository>();
//builder.Services.AddScoped<IReceiverRepository, ReceiverInMemoryRepository>();

//builder.Services.AddScoped<IDepartmentDpRepository, DepartmentDpInMemoryRepository>();
//builder.Services.AddScoped<IRegionRepository, RegionInMemoryRepository>();
//builder.Services.AddScoped<ICostOfDeliveryRepository, CostOfDeliveryInMemoryRepository>();

//builder.Services.AddScoped<IFileSpRepository, FileSpInMemoryRepository>();
//builder.Services.AddScoped<IDirectorySpRepository, DirectorySpInMemoryRepository>();

#endregion
// ---
#region DI for SQL Data Store Repository

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IProductSpRepository, ProductSpRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IReceiverRepository, ReceiverRepository>();

builder.Services.AddScoped<IDepartmentDpRepository, DepartmentDpRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<ICostOfDeliveryRepository, CostOfDeliveryRepository>();

builder.Services.AddScoped<IFileSpRepository, FileSpRepository>();
builder.Services.AddScoped<IDirectorySpRepository, DirectorySpRepository>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

#endregion
// ---
#region For ShopByShopInMemory Repository

// builder.Services.AddScoped<IPvzRepository, PvzServiceInMemory>();
// builder.Services.AddScoped<IRecipientRepository, RecipientServiceInMemory>();
// builder.Services.AddScoped<ITrackRepository, TrackServiceInMemory>();

#endregion
// ---
#region ShopByShop
builder.Configuration.AddJsonFile("SettingsSp/shopbyshopSettings.json");
builder.Services.AddSingleton(
    builder.Configuration.GetSection("ShopbyshopSettingsV100")
        .Get<ShopByShopSettings>());
#endregion
// ---
#region AddScoped Repository

builder.Services.AddScoped<IPvzRepository, PvzService>();
builder.Services.AddScoped<IRecipientRepository, RecipientService>();
builder.Services.AddScoped<ITrackRepository, TrackService>();

// builder.Services.AddScoped<IDepartmentDpRepository, DepartmentDpInMemoryRepository>();
// builder.Services.AddScoped<IRegionRepository, RegionInMemoryRepository>();
// builder.Services.AddScoped<ICostOfDeliveryRepository, CostOfDeliveryInMemoryRepository>();

// builder.Services.AddScoped<IFileSpRepository, FileSpRepository>();
//builder.Services.AddScoped<IDirectorySpRepository, DirectorySpRepository>();

// builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskInMemoryRepository>();

#endregion
// ---
#region View Services
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewPackagesUseCase, ViewPackagesUseCase>();
builder.Services.AddTransient<IViewProductsSpUseCase, ViewProductsSpUseCase>();
builder.Services.AddTransient<IViewPurchasesUseCase, ViewPurchasesUseCase>();
builder.Services.AddTransient<IViewReceiversUseCase, ViewReceiversUseCase>();

builder.Services.AddTransient<IViewDepartmentDpsUseCase, ViewDepartmentDpsUseCase>();
builder.Services.AddTransient<IViewRegionsUseCase, ViewRegionsUseCase>();
builder.Services.AddTransient<IViewCostOfDeliveriesUseCase, ViewCostOfDeliveriesUseCase>();

builder.Services.AddTransient<IGetPurchasesByPackegeIdUseCase, GetPurchasesByPackegeIdUseCase>();
builder.Services.AddTransient<IGetInvoiceByIdUseCase, GetInvoiceByIdUseCase>();

#endregion
// ---
#region Add Services

builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IAddPackageUseCase, AddPackageUseCase>();
builder.Services.AddTransient<IAddProductSpUseCase, AddProductSpUseCase>();
builder.Services.AddTransient<IAddPurchaseUseCase, AddPurchaseUseCase>();
builder.Services.AddTransient<IAddReceiverUseCase, AddReceiverUseCase>();

builder.Services.AddTransient<IAddPvzUseCase, AddPvzUseCase>();

builder.Services.AddTransient<IAddFileSpUseCase, AddFileSpUseCase>();
builder.Services.AddTransient<IAddDirectorySpUseCase, AddDirectorySpUseCase>();

#endregion
// ---
#region  Edit Services
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IEditPackageUseCase, EditPackageUseCase>();
builder.Services.AddTransient<IEditProductSpUseCase, EditProductSpUseCase>();
builder.Services.AddTransient<IEditPurchaseUseCase, EditPurchaseUseCase>();
builder.Services.AddTransient<IEditReceiverUseCase, EditReceiverUseCase>();
#endregion
// ---
#region Get Services
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IGetPackageByIdUseCase, GetPackageByIdUseCase>();
builder.Services.AddTransient<IGetProductSpByIdUseCase, GetProductSpByIdUseCase>();
builder.Services.AddTransient<IGetPurchaseByIdUseCase, GetPurchaseByIdUseCase>();
builder.Services.AddTransient<IGetReceiverByIdUseCase, GetReceiverByIdUseCase>();

builder.Services.AddTransient<IGetDepartmentDpByIdUseCase, GetDepartmentDpByIdUseCase>();
// services.AddTransient<IGetRegionByIdUseCase, GetRegionByIdUseCase>();

builder.Services.AddTransient<IGetFileSpByIdUseCase, GetFileSpByIdUseCase>();
builder.Services.AddTransient<IGetDirectorySpByIdUseCase, GetDirectorySpByIdUseCase>();
builder.Services.AddTransient<IGetDirectorySpByUserIdUseCase, GetDirectorySpByUserIdUseCase>();
#endregion
builder.Services.AddTransient<
    IExistsProductSpByTrackNumberUseCase, 
    ExistsProductSpByTrackNumberUseCase>();
// ---
#region Delete Services
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IDeletePackageUseCase, DeletePackageUseCase>();
builder.Services.AddTransient<IDeleteProductSpUseCase, DeleteProductSpUseCase>();
builder.Services.AddTransient<IDeletePurchaseUseCase, DeletePurchaseUseCase>();
builder.Services.AddTransient<IDeleteReceiverUseCase, DeleteReceiverUseCase>();
#endregion
// ---
builder.Services.AddTransient<IGetProductsSpByPurchaseUseCase, GetProductsSpByPurchaseUseCase>();
builder.Services.AddTransient<IGetPackagesByStatusUseCase, GetPackagesByStatusUseCase>();
// ---
#region CRUD ShopByShop
// ---
#region View Sbs Services
builder.Services.AddTransient<IViewPvzsSbsUseCase, ViewPvzsSbsUseCase>();
builder.Services.AddTransient<IViewTracksSbsUseCase, ViewTracksSbsUseCase>();
builder.Services.AddTransient<IViewRecipientsSbsUseCase, ViewRecipientsSbsUseCase>();
#endregion
// ---
#region Get Sbs Services
builder.Services.AddTransient<IGetTrackSbsByIdUseCase, GetTrackSbsByIdUseCase>();
builder.Services.AddTransient<IGetRecipientSbsByIdUseCase, GetRecipientSbsByIdUseCase>();
#endregion
// ---
#region Add Sbs Services
builder.Services.AddTransient<IAddTrackSbsUseCase, AddTrackSbsUseCase>();
builder.Services.AddTransient<IAddRecipientSbsUseCase, AddRecipientSbsUseCase>();
#endregion
// ---
#region Edit Sbs Services
builder.Services.AddTransient<IEditTrackSbsUseCase, EditTrackSbsUseCase>();
builder.Services.AddTransient<IEditRecipientSbsUseCase, EditRecipientSbsUseCase>();
#endregion
// ---
#region Delete Sbs Services
builder.Services.AddTransient<IDeleteTrackSbsUseCase, DeleteTrackSbsUseCase>();
builder.Services.AddTransient<IDeleteRecipientSbsUseCase, DeleteRecipientSbsUseCase>();
#endregion
// ---
#endregion
// ---
// DI for EF core Data Store for SQL

// ---
#region BootstrapBlazor
builder.Services.AddBootstrapBlazor();
#endregion
// ---
#region Google Facebook MicrosoftAccount Twitter *Commented
/*
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   })
   .AddFacebook(options =>
   {
       IConfigurationSection FBAuthNSection =
       config.GetSection("Authentication:FB");
       options.ClientId = FBAuthNSection["ClientId"];
       options.ClientSecret = FBAuthNSection["ClientSecret"];
   })
   .AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
   })
   .AddTwitter(twitterOptions =>
   {
       twitterOptions.ConsumerKey = config["Authentication:Twitter:ConsumerAPIKey"];
       twitterOptions.ConsumerSecret = config["Authentication:Twitter:ConsumerSecret"];
       twitterOptions.RetrieveUserDetails = true;
   });
*/
#endregion
// ---
builder.Services.AddHttpContextAccessor();
// ---
#region Logging
string NameLoggerFile = "logger\\logger_"
    + DateTime.Now.ToShortDateString() + "_"
    + DateTime.Now.ToShortTimeString().Replace(':', '-') 
    + ".txt";

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), NameLoggerFile));
#endregion
// ---
#region Mail
builder.Configuration.AddJsonFile("SettingsSp/mailSettings.json");

//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton(builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>());
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion
// ---
#region AddCors Services
// builder.Services.AddCors(); // добавляем сервисы CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("SpraunaPanelPolicy", builder =>
    builder.AllowAnyOrigin() // ToDo: Change to sprauna.by
    //builder.WithOrigins("https://sprauna.by/panel/")
        .AllowAnyMethod()
        .AllowAnyHeader());
});
#endregion
// ---
var app = builder.Build();
// ---
#region Logger Work
app.Logger.LogInformation("\t SpLog, app.Run,, Time:" + DateTime.Now.ToLongTimeString());
#endregion
// ---
#region Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
#endregion
// ---
/* *Commented
app.Run(async (context) =>
{
    var path = context.Request.Path;
    app.Logger.LogInformation($"LogInformation {path}");
    await context.Response.WriteAsync("Hello World!");
});
*/
// ---
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// ---
#region UseCors
// глобальная настройка CORS для всех ресурсов
// app.UseCors(builder => builder.AllowAnyOrigin());
app.UseCors("SpraunaPanelPolicy");

/*
app.UseCors(builder =>
        builder
        .WithOrigins("https://sprauna.by",
            "https://sprauna.by/panel/",
            "https://sprauna.by/iframe/")
        .AllowAnyMethod()
        .AllowAnyHeader());
*/
// ToDo: Delete https://localhost:7113/
#endregion
// ---
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
