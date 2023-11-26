using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI.Configurations;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Geta.NotFoundHandler.Infrastructure.Configuration;
using Geta.NotFoundHandler.Infrastructure.Initialization;
using Geta.NotFoundHandler.Optimizely.Infrastructure.Configuration;
using Geta.Optimizely.Sitemaps;
using Head_Chef.Business.Extensions;
using Head_Chef.Business.Services;
using Head_Chef.Business.Services.Interfaces;
using Head_Chef.Business.TinyMce;
using Head_Chef.Models.Pages;


namespace Head_Chef
{
    public sealed class Startup
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
            services.AddSingleton<ICommentService, CommentService>();

            services.Configure<UploadOptions>(x =>
            {
                x.FileSizeLimit = 52428800; // 50MB
            });

            IServiceCollection serviceCollection = services.Configure<EPiServer.Find.FindOptions>(options =>
            {
                options.DefaultIndex = "pernorin_headchef2";
                options.ServiceUrl = "https://demo04.find.episerver.net/5TCUMC4KJVuNG7XsIwkfKuSWFkQFKrOv/";                
            });

            var connectionString = "Data Source=cms2-sqlserver.database.windows.net,1433;Initial Catalog=cms2_headchef;Persist Security Info=False;User ID=HeadChefAdmin;Password='BytMig123!~¨^';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddNotFoundHandler(o =>
            {
                o.UseSqlServer(connectionString);
                o.BufferSize = 30;
                o.ThreshHold = 5;
                o.HandlerMode = FileNotFoundMode.On;
                o.IgnoredResourceExtensions = new[] { "jpg", "gif", "png", "css", "js", "ico", "swf", "woff" };
                o.Logging = LoggerMode.On;
                o.LogWithHostname = false;
                //o.AddProvider<NullNotFoundHandlerProvider>();
            });

            services.AddOptimizelyNotFoundHandler(o =>
            {
                o.AutomaticRedirectsEnabled = true;
            });

            //services.AddSingleton<IXmlSitemapService, XmlSitemapService>();
            services.AddSitemaps(x =>
            {
                x.EnableLanguageDropDownInAdmin = true;
                x.EnableRealtimeCaching = true;
                x.EnableRealtimeSitemap = true;
            });
            //services.AddSingleton<ICommentService, CommentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            // app.UseNotFoundHandler();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}