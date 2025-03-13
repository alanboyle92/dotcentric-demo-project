using Dotcentric.Website.Models.Blocks;
using EPiServer.Cms.TinyMce.Core;

namespace Dotcentric.Website.Rendering
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTinyMceConfiguration(this IServiceCollection services)
        {
            services.Configure<TinyMceConfiguration>(config =>
            {
                config.For<RichTextBlock>(t => t.RichText)
                    .DisableMenubar()
                    .Toolbar("bold italic | bullist numlist")
                    .AddPlugin("lists")
                    .Width(600);
            });

            return services;
        }
    }
}
