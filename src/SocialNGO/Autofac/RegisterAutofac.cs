using Autofac;

namespace SocialNGO.Autofac;

/// <summary></summary>
public class RegisterAutofac : Module
{
    /// <summary></summary>
    /// <param name="builder"></param>
    protected override void Load(ContainerBuilder builder)
    {
        builder.ResolveDependency();
    }
}
