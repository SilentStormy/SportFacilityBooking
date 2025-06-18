using Core.Domain.Interfaces;
using Core.Domain.Services;
using Core.Domain.Services.UserAuth;
using Infrastructure.Data.Interface;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserAuthentication, UserAuthentication>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISportFacilityView, SportFacilityService>();
builder.Services.AddScoped<ISportFacilityRepository, SportFacilityRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationManagement, ReservationManagement>();
builder.Services.AddScoped<ITimeSlotAvailabilityChecker,TimeSlotAvailabilityChecker>();
builder.Services.AddSession();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
