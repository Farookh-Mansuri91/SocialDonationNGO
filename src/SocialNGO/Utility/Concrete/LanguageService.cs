using SocialNGO.Utility.Contract;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace SocialNGO.Utility.Concrete;

/// <summary>
/// Dummy class to group shared resources
/// </summary>
public class SharedResource
{
}

/// <summary> </summary>
/// <typeparam name="T"></typeparam>
public class LanguageService<T> : ILanguageService<T> where T : class
{
    private readonly IStringLocalizer _localizer;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary> </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="factory"></param>
    public LanguageService(IStringLocalizerFactory factory, IHttpContextAccessor httpContextAccessor)
    {
        var type = typeof(SharedResource);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
        _localizer = factory.Create("SharedResource", assemblyName.Name);
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary> </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string Getkey(string key)
    {
        var culture = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture;
        var message = _localizer.GetString(key, culture);
        return _localizer.GetString(key, culture).Value;
    }

    /// <summary> </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public LocalizedString GetResourcekey(string key)
    {
        return _localizer[key];
    }
}


