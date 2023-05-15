using Microsoft.EntityFrameworkCore;
using Sakugen.Data;
using Sakugen.Interface;
using Sakugen.Other;
using Sakugen.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IQRCodeRepositroy, QrCodeRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.Use(async (context, next) =>
{
    if (ApplicationConfig.Url != "")
        ApplicationConfig.Url = context.Request.Host.ToString();

    await next.Invoke();
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
