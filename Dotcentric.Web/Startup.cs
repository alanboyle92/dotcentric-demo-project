namespace Dotcentric.Website;

using Baaijte.Optimizely.ImageSharp.Web;
using Baaijte.Optimizely.ImageSharp.Web.Providers;
using Dotcentric.Infrastructure.Service;
using Dotcentric.Infrastructure.Services;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using SixLabors.ImageSharp.Web.Caching.Azure;
using SixLabors.ImageSharp.Web.DependencyInjection;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        _webHostingEnvironment = webHostingEnvironment;
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("EPiServerDB");

        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services.AddHttpClient<IProductService, ProductService>();

        services.AddRouting();
        services.AddHttpContextAccessor();
        services.AddScoped<IUrlHelper>(x =>
        {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            var factory = x.GetRequiredService<IUrlHelperFactory>();
            return factory.GetUrlHelper(actionContext);
        });

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();

        services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

        services.AddAzureBlobProvider(options =>
        {
            options.ConnectionString = _configuration.GetConnectionString("EPiServerAzureBlobs");
            options.ContainerName = "media";
        });

        services.AddImageSharp(options =>
            {
                options.OnPrepareResponseAsync = ctx =>
                {
                    ctx.Response.Headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365)
                    }.ToString();
                    return Task.CompletedTask;
                };
            })
            .Configure<AzureBlobStorageCacheOptions>(options =>
            {
                options.ConnectionString = _configuration.GetConnectionString("EPiServerAzureBlobs");
                options.ContainerName = "media";
            })
            .ClearProviders()
            .AddProvider<BlobImageProvider>()
            .SetCache<AzureBlobStorageCache>();        
        

        services.AddRouting();
        services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/errors/500/");
        }

        app.UseStatusCodePagesWithReExecute("/errors/{0}");
        app.UseRouting();
        app.UseBaaijteOptimizelyImageSharp();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(_webHostingEnvironment.ContentRootPath, "assets")),
            RequestPath = "/assets"
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapRazorPages();
            endpoints.MapContent();            
        });
    }
}
