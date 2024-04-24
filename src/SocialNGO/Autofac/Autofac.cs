using Autofac;
using SocialNGO.Business.Concrete;
using SocialNGO.Business.Constants;
using SocialNGO.Infrastructure.Db.Repositories.Base.Concrete;
using SocialNGO.Infrastructure.Db.Repositories.Base.Contracts;
using SocialNGO.Utility.Concrete;
using SocialNGO.Utility.Contract;

namespace SocialNGO.Autofac;

/// <summary></summary>
public static class Autofac
{
    /// <summary>Register/Resolve Dependency</summary>
    /// <param name="builder"></param>
    public static void ResolveDependency(this ContainerBuilder builder)
    {
        #region Register/Resolve Business
        builder.RegisterType<SchoolManager>().As<ISchoolManager>();
        builder.RegisterType<UserManager>().As<IUserManager>();
        builder.RegisterType<JWTService>().As<IJWTInterface>();
        #endregion

        #region Register/Resolve Repositories
        builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
        #endregion
    }
}
