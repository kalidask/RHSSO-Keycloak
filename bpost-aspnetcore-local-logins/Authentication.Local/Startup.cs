    
namespace Authentication.Local
{
using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;


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


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
     options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";

                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/auth/login";
                }). 
AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = "Cookies";
        options.Authority = Configuration["oidc:Authority"];
        options.ClientId = Configuration["oidc:ClientId"];
        options.ClientSecret = Configuration["oidc:ClientSecret"];
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.RemoteSignOutPath = "/SignOut";
        options.SignedOutRedirectUri = "http://localhost:55658/";
        options.ResponseType = "code";
 options.Scope.Clear();
        options.Scope.Add("openid");
        options.CallbackPath = new PathString("/signin-auth0");
options.TokenValidationParameters = new TokenValidationParameters
				{
					NameClaimType = "name",
				};

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
