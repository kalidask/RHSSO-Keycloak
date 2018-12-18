    
namespace Authentication.Local
{
using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
//    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Models;
using Services;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


    public class Startup
    {


       private readonly IDictionary<string, User> _users = new Dictionary<string, User>
        {
            {
                "George", new User {
                    Id =  1,
                    UserName = "George",
                    FirstName = "George",
                    LastName = "Dyrrachitis",
                    Password = "1234",
                    DateOfBirth = new DateTime(1989, 10, 26)
                }
            }
        }; 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton(_users);
            services.AddTransient<IUserService, UserService>();
            services.AddMvc();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //
    //
    //
  //   options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        // OpenId authentication
                          options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/auth/login";
                    options.LogoutPath = "/auth/logout";
                }).  /*    AddOpenIdConnect(options =>
    {

        options.Authority = "http://localhost:8080/auth/realms/master";

        options.ClientId = "simplelogin";


        options.RequireHttpsMetadata = false;
        options.SaveTokens = true;


        options.ClientSecret = "27f676ed-1cad-4a8b-9ba6-a429c47aa599";
        options.GetClaimsFromUserInfoEndpoint = true;


        options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
    }); */


AddOpenIdConnect(options =>
    {
        options.Authority = Configuration["Authentication:oidc:Authority"];
        options.ClientId = Configuration["Authentication:oidc:ClientId"];
        options.ClientSecret = Configuration["Authentication:oidc:ClientSecret"];
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.RemoteSignOutPath = "/SignOut";
        options.SignedOutRedirectUri = "http://localhost:55658/";
        options.ResponseType = "code";

    });








services.AddAuthorization(options =>
    {
        options.AddPolicy("Users", policy =>
        policy.RequireRole("Users"));
    });
        
}





        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
