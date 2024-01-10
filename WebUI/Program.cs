using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = new PathString("/Account/Login");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    //options.AccessDeniedPath = new PathString("/Account/AccessDenied");
});
builder.Services.AddDbContext<ShoppingContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ShoppingContext>();
builder.Services.AddScoped<IBannerService, BannerManager>();
builder.Services.AddScoped<IBannerDal, EfBannerDal>();

builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IDealsOfTheWeekService, DealsOfTheWeekManager>();
builder.Services.AddScoped<IDealsOfTheWeekDal, EfDealsOfTheWeekDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();

builder.Services.AddScoped<IDescriptionService, DescriptionManager>();
builder.Services.AddScoped<IDescriptionDal, EfDescriptionDal>();

builder.Services.AddScoped<IProductImageService, ProductImageManager>();
builder.Services.AddScoped<IProductImageDal, EfProductImageDal>();

builder.Services.AddScoped<IProductSpecificationService, ProductSpecificationManager>();
builder.Services.AddScoped<IProductSpecificationDal, EfProductSpecificationDal>();

builder.Services.AddScoped<IReviewService, ReviewManager>();
builder.Services.AddScoped<IReviewDal, EfReviewDal>();

builder.Services.AddScoped<ISpecificationService, SpecificationManager>();
builder.Services.AddScoped<ISpecificationDal, EfSpecificationDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
