using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using DataAccessLayer.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Builder Servisleri
builder.Services.AddDbContext<AgricultureContext>();
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();

builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();

builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageDal, EfImageDal>();

builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
#endregion


builder.Services.AddControllersWithViews(config =>
{
  var policy = new AuthorizationPolicyBuilder()
      .RequireAuthenticatedUser()
      .Build();

  config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
      options.LoginPath = "/Login/Index"; // Login sayfasý yönlendirmesi
      options.AccessDeniedPath = "/Account/AccessDenied"; // Eriþim engellendiðinde yönlendirme
      options.ExpireTimeSpan = TimeSpan.FromHours(1); // Cookie expiration süresi
      options.SlidingExpiration = true; // Oturum uzatma
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
