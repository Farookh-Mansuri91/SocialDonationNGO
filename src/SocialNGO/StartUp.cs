using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNGO.Autofac;
using SocialNGO.Common;
using SocialNGO.Helper.ApiResponse;
using SocialNGO.Helper.ExceptionHandler;
using SocialNGO.Helper.Middleware.JwtMiddleware;
using SocialNGO.Infrastructure.db.Wrapper.Concrete;
using SocialNGO.Infrastructure.db.Wrapper.Contracts;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Profiles;
using SocialNGO.Registration;

namespace SocialNGO;

/// <summary>Register Services and Pipelines</summary>
public static class StartUp
{
    /// <summary> </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
        builder.RegisterResources();
        #region register mySQL Context
        builder.Services.AddDbContext<ApplicationDBContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        #endregion
        #region Model Validation"
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = ModelErrorResponse.GenerateErrorResponse;
        });
        #endregion
        builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
        #region Autofac
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RegisterAutofac()));
        #endregion
        AutoMapperRegistration(builder);
        builder.AddSwaggerMethod();
        #region "FromForm Requestd Size Limit"
        builder.Services.Configure<FormOptions>(o =>
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });
        #endregion

        #region RegisterExceptionHandler"
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        #endregion
        AddCors(builder);
        return builder;
    }

    /// <summary> Configure the HTTP request pipeline.</summary>
    /// <param name="app"></param>
    /// <returns>HTTP request pipeline</returns>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseExceptionHandler();
        app.UseCors();
        app.UseMiddleware<JwtMiddleware>();
        return app;
    }

    /// <summary>Automapper Registration</summary>
    /// <param name="builder"></param>
    private static void AutoMapperRegistration(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    }

    /// <summary>Cors Registration</summary>
    /// <param name="builder"></param>
    private static void AddCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}
