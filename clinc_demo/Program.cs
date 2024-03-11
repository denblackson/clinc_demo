using clinic_demo.BLL.Implementations;
using clinic_demo.BLL.Interfaces;
using clinic_demo.DAL;
using clinic_demo.DAL.Interfaces;
using clinic_demo.DAL.Repositiries;
using clinic_demo.Domain.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); //  .AddRazorRuntimeCompilation() nuget packages for auto html page update


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBaseRepository<AppointmentEntity>, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IBaseRepository<DoctorEntity>, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();




var connectionString = builder.Configuration.GetConnectionString("DENIS_MSSQL");

builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(connectionString);
});







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
    pattern: "{controller=Appointment}/{action=Index}/{id?}");

app.Run();
