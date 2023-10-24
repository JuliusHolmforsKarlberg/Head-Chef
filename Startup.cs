using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI.Configurations;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Head_Chef.Business.Extensions;
using Head_Chef.Business.Services;
using Head_Chef.Business.Services.Interfaces;
using Head_Chef.Business.TinyMce;
using Head_Chef.Models.Pages;
using Head;
using Head_Chef.Business.Services.Interfaces;

namespace Head_Chef
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddFind()
                .AddNackademin()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>()
                .TinyMceConfiguration();


            services.Configure<UploadOptions>(x =>
            {
                x.FileSizeLimit = 52428800; // 50MB
            });

            services.Configure<EPiServer.Find.FindOptions>(options =>
            {
                options.DefaultIndex = "carl.schele_nackademin2023v001";
                options.ServiceUrl = "https://demo04.find.episerver.net/SNRr6mO0axGL6CLGAPTGAZrOMFS1S9ZI";
            });

            services.AddSingleton<IXmlSitemapService, XmlSitemapService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
            });
        }
    }
}