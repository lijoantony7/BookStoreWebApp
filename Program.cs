using BookStoreWebApp.BookStoreContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // dependency injections services
builder.Services.AddDbContext<AppDbContext>( options =>
    options.UseSqlServer( "Server=.;Database=BookStore;Integrated Security=True;Encrypt=False;" ) );


#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // runtime Compilation enabled
#endif

var app = builder.Build(); // in app. http pipeline

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

//static folder name wwwroot should be root level folder
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
   endpoints.MapDefaultControllerRoute();
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
