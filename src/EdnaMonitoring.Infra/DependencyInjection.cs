using EdnaMonitoring.App.Data;
using EdnaMonitoring.App.Security;
using EdnaMonitoring.Domain.Entities;
using EdnaMonitoring.Infra.Email;
using EdnaMonitoring.Infra.Identity.TokenProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EdnaMonitoring.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsEnvironment("Testing"))
            {
                // Add Identity Infra
                services.AddDbContext<AppIdentityDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "EdnaMonitoring"));
            }
            else
            {
                // Add Identity Persistence Infra 
                services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseNpgsql(
                          configuration.GetConnectionString("DefaultConnection"),
                          b => b.MigrationsAssembly("EdnaMonitoring.Web"))
                    );
            }

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 2;
                options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation");

            // set email confirmation token lifespan to 3 days
            services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromDays(3));

            services.ConfigureApplicationCookie(options =>
            {
                // configure login path for return urls
                // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            // Add Email service
            services.AddTransient<IEmailSender, EmailSender>();

            // add super admin user details from config as a singleton service
            IdentityInit identityInit = new IdentityInit();
            configuration.Bind("IdentityInit", identityInit);
            services.AddSingleton(identityInit);


            return services;
        }
    }
}
