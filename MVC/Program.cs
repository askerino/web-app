using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVC.Filters;
using MVC.Models;

using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;
var connectionString = new MySqlConnectionStringBuilder()
{
    SslMode = MySqlSslMode.None,
    Server = "/cloudsql/civic-matrix-417102:us-central1:test-mysql-instance",
    UserID = "web-app",
    Password = "web-app",
    Database = "web-app",
    ConnectionProtocol = MySqlConnectionProtocol.UnixSocket
};
connectionString.Pooling = true;
Console.WriteLine(connectionString);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<MyLogAttribute>(); // �A�v���S�̂ɓK�p
});

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MyContext"), new MySqlServerVersion(new Version(8, 3, 0)));
    //options.UseMySql(builder.Configuration.GetConnectionString("MyContext"), new MySqlServerVersion(new Version(8, 0, 31)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    constraints: new
    {
        id = @"\d{1,3}"
    });

app.Run("http://0.0.0.0:8080");
