using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PatientDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PatientConnection")));


builder.Services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
builder.Services.AddScoped(typeof(IBillRepository), typeof(BillRepository));
builder.Services.AddScoped(typeof(IGenderRepository), typeof(GenderRepository));

builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
builder.Services.AddScoped(typeof(IBillService), typeof(BillService));
builder.Services.AddScoped(typeof(IGenderService), typeof(GenderService));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
