using SocialNGO.Utility.Concrete;
using SocialNGO.Utility.Contract;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;

namespace SocialNGO.Registration;

/// <summary> </summary>
public static class ResourceExtension
{
    /// <summary> </summary>
    /// <param name="builder"></param>
    public static void RegisterResources(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        #region Localization
        //Step 1
        builder.Services.AddSingleton(typeof(ILanguageService<>), typeof(LanguageService<>));
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddControllers()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                    var abc = factory.Create("SharedResource", assemblyName.Name);
                    return factory.Create("SharedResource", assemblyName.Name);
                };
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new("fr-FR"),
                    new("en-US")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "fr-FR", uiCulture: "fr-FR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });
        #endregion
    }
}
