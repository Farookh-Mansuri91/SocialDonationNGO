using Microsoft.Extensions.Localization;

namespace SocialNGO.Utility.Contract;

/// <summary></summary>
/// <typeparam name="T"></typeparam>
public interface ILanguageService<T> where T : class
{
    /// <summary></summary>
    string Getkey(string key);

    /// <summary></summary>
    LocalizedString GetResourcekey(string key);
}
