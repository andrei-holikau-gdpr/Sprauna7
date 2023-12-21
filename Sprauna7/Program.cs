using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Sprauna7.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
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

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AccountContextConnection") ?? throw new InvalidOperationException("Connection string 'AccountContextConnection' not found.");

builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//services.AddDbContext<SpraunaContext>(options =>
//{
//    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
//});

// DI for In-Memory Data Store
builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
builder.Services.AddScoped<IPackageRepository, PackageInMemoryRepository>();
builder.Services.AddScoped<IProductSpRepository, ProductSpInMemoryRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseInMemoryRepository>();
builder.Services.AddScoped<IReceiverRepository, ReceiverInMemoryRepository>();

builder.Services.AddScoped<IDepartmentDeliveryParcelRepository, DepartmentDeliveryParcelInMemoryRepository>();
builder.Services.AddScoped<IRegionRepository, RegionInMemoryRepository>();

builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewPackagesUseCase, ViewPackagesUseCase>();
builder.Services.AddTransient<IViewProductsSpUseCase, ViewProductsSpUseCase>();
builder.Services.AddTransient<IViewPurchasesUseCase, ViewPurchasesUseCase>();
builder.Services.AddTransient<IViewReceiversUseCase, ViewReceiversUseCase>();

builder.Services.AddTransient<IViewDepartmentDeliveryParcelsUseCase, ViewDepartmentDeliveryParcelsUseCase>();
builder.Services.AddTransient<IViewRegionsUseCase, ViewRegionsUseCase>();

builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IAddPackageUseCase, AddPackageUseCase>();
builder.Services.AddTransient<IAddProductSpUseCase, AddProductSpUseCase>();
builder.Services.AddTransient<IAddPurchaseUseCase, AddPurchaseUseCase>();
builder.Services.AddTransient<IAddReceiverUseCase, AddReceiverUseCase>();

builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IEditPackageUseCase, EditPackageUseCase>();
builder.Services.AddTransient<IEditProductSpUseCase, EditProductSpUseCase>();
builder.Services.AddTransient<IEditPurchaseUseCase, EditPurchaseUseCase>();
builder.Services.AddTransient<IEditReceiverUseCase, EditReceiverUseCase>();

builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IGetPackageByIdUseCase, GetPackageByIdUseCase>();
builder.Services.AddTransient<IGetProductSpByIdUseCase, GetProductSpByIdUseCase>();
builder.Services.AddTransient<IGetPurchaseByIdUseCase, GetPurchaseByIdUseCase>();
builder.Services.AddTransient<IGetReceiverByIdUseCase, GetReceiverByIdUseCase>();

builder.Services.AddTransient<IGetDepartmentDeliveryParcelByIdUseCase, GetDepartmentDeliveryParcelByIdUseCase>();
// services.AddTransient<IGetRegionByIdUseCase, GetRegionByIdUseCase>();

builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IDeletePackageUseCase, DeletePackageUseCase>();
builder.Services.AddTransient<IDeleteProductSpUseCase, DeleteProductSpUseCase>();
builder.Services.AddTransient<IDeletePurchaseUseCase, DeletePurchaseUseCase>();
builder.Services.AddTransient<IDeleteReceiverUseCase, DeleteReceiverUseCase>();

builder.Services.AddTransient<IGetProductsSpByPurchaseUseCase, GetProductsSpByPurchaseUseCase>();

// DI for EF core Data Store for SQL

builder.Services.AddBootstrapBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
