using digiturkProject.Data;

using digiturkProject.Models.Data;

using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);



// ******************************************************

// TÜM SERVİS KAYITLARI BURADA, builder.Build() ÖNCESİNDE OLMALI

// ******************************************************



builder.Services.AddControllersWithViews();



// DbContext'i servislere ekleyin

builder.Services.AddDbContext<ApplicationDbContext>(options =>

  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();




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

        SeedData.Initialize(services); 

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



// Admin Area için yeni rota tanımı

app.MapControllerRoute(

  name: "AdminArea",

  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");



app.MapControllerRoute(

  name: "BossayfaArea",

  pattern: "{area:exists}/{controller=Bossayfa}/{action=Index}/{id?}");



app.MapControllerRoute(

  name: "default",

  pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

