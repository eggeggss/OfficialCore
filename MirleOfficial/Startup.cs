using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MirleOfficial.ViewModel;
using OfficialBLL;
using OfficialDAL.Common;
using OfficialDAL.DAL;
using OfficialDAL.Meta;
using OfficialDAL.Models;

namespace MirleOfficial
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
            services.Configure<Profile>(
                     Configuration.GetSection("Profile")
            );

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            
            services.AddDbContext<MIRLE_WEBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<EFAdapter>();

            services.Scan(scan => scan
            .FromAssemblies(Assembly.Load("OfficialDAL"))
            .FromAssemblyOf<Startup>()
            .AddClasses(classes => classes.Where(t => t.Name.EndsWith("DAL", StringComparison.OrdinalIgnoreCase)))
            .AsSelf()
            .WithScopedLifetime()
            );

            services.Scan(scan => scan
            .FromAssemblies(Assembly.Load("OfficialBLL"))
            .FromAssemblyOf<Startup>()
            .AddClasses(classes => classes.Where(t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)))
            .AsSelf()
            .WithScopedLifetime()
            );

            services.AddScoped<FirstViewModel>();


            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews().
                AddViewLocalization().
                AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new CultureInfo[] {
                new CultureInfo("en-US"),
                new CultureInfo("zh-TW"),
                new CultureInfo("zh-CN"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                RequestCultureProviders = new[]
            {
                new CookieRequestCultureProvider() { Options = new RequestLocalizationOptions{ SupportedCultures=supportedCultures,
                SupportedUICultures=supportedCultures} }
            },
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                //當預設Provider偵測不到用戶支持上述Culture的話，就會是↓
                DefaultRequestCulture = new RequestCulture("zh-TW")//Default UICulture、Culture 
            });


            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
