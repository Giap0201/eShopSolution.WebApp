using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Common;
using eShopSolution.Application.System.Users;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using EShopSulotionUtilities.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add config authentication in JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // Kiểm tra người phát hành
                ValidateAudience = true, // Kiểm tra đối tượng
                ValidateLifetime = true, // Kiểm tra thời gian hết hạn
                ValidateIssuerSigningKey = true, // Kiểm tra chữ ký

                ValidIssuer = Configuration["Jwt:Issuer"], // Tên người phát hành (ví dụ: "yourdomain.com")
                ValidAudience = Configuration["Jwt:Audience"], // Đối tượng (ví dụ: "yourclientapp.com")
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])) // Secret Key
            };
        });

// Configure DbContext with SQL Server
builder.Services.AddDbContext<EShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(SystemConstant.MainConnectionString)));

// Configure Identity
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<EShopDbContext>()
    .AddDefaultTokenProviders();
// Add other services (e.g., repositories, application services) here
builder.Services.AddTransient<IStorageService, FileStorageService>();

builder.Services.AddTransient<IPublicProductService, PublicProductService>();
builder.Services.AddTransient<IManageProductService, ManageProductService>();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService, UserService>();

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