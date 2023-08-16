using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // 1. ad�m: mvc mimarisi �al��acaksa bu servisi eklemeliyiz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // middlewares
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); // route middleware'i => gelen iste�in hangi controllera gidece�i rota ayarlan�r

            app.UseAuthorization();

            app.UseEndpoints(endpoints => // endpoint middlewarei => yap�lan iste�in var�� noktas�: URL(istek adresi).
            {
                endpoints.MapDefaultControllerRoute();/*MapRazorPages();*/
                // MapDefaultControllerRoute() => s�sl� parantez i�inde parametre tan�mlanabilir.
                // {controller = Home}/{action = Index}/{id?} -----> https://www......com/personel/getir/103
            });
        }
    }
}
