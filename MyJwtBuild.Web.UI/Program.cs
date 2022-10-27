using Microsoft.AspNetCore.Mvc.Filters;
using MyJwtBuild.BUSINESS.Concrete;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.BUSINESS.IOCContainer;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Context;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Repositories;
using MyJwtBuild.DATAACCESS.Interfaces;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Concrete;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;
using MyJwtBuild.Web.UI.ApiServices.DataApi.Concrete;
using MyJwtBuild.Web.UI.ApiServices.DataApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDependencies();

builder.Services.AddScoped<IAuthApiService, AuthApiManager>();
builder.Services.AddScoped<IProductApiService, ProductApiManager>();
builder.Services.AddScoped<IUserApiService, UserApiManager>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
