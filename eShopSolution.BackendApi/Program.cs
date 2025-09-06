using eShopSolution.Application.Catalog.Products;
using eShopSolution.Data.EF;
using EShopSulotionUtilities.Constants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<EShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(SystemConstant.MainConnectionString)));

// Add other services (e.g., repositories, application services) here
builder.Services.AddTransient<IPublicProductService, PublicProductService>();

// 🔹 Thêm Swagger service để đăng ký ISwaggerProvider
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Thêm Swagger middleware vào pipeline
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "eShopSolution API V1");
        // c.RoutePrefix = string.Empty; // mở Swagger ở trang gốc
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
