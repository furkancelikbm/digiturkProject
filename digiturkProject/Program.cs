using digiturkProject.Data;
using digiturkProject.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; // ILogger için gerekli using

var builder = WebApplication.CreateBuilder(args);

// ******************************************************
// TÜM SERVİS KAYITLARI BURADA, builder.Build() ÖNCESİNDE OLMALI
// ******************************************************

builder.Services.AddControllersWithViews();

// DbContext'i servislere ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ******************************************************
// builder.Build() ARTIK SERVİSLER KAYDEDİLDİKTEN SONRA ÇAĞRILMALI
// ******************************************************
var app = builder.Build();

// ******************************************************
// HTTP İSTEK PIPELINE'INI VE VERİTABANI BAŞLATMAYI KONFİGÜRE ET
// ******************************************************

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Uygulama başlarken veritabanına başlangıç verileri ekleme
// Bu kısım app.Build() sonrası gelebilir, çünkü servisleri kullanıyor, eklemiyor.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate(); // Veritabanının güncel olduğundan emin olun
        SeedData.Initialize(services); // Başlangıç verilerini ekleyin
    }
    catch (Exception ex)
    {
        // ILogger'ı doğrudan uygulama servis sağlayıcısından alın
        // Bu, servis koleksiyonunun kilitlenmesi sorununu çözer.
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Veritabanı başlatılırken veya seed edilirken bir hata oluştu.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot içeriğini sunar

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
