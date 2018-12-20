using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Threading.Tasks;
using System;





namespace SimpleLogin
{
    public class Startup
    {
 public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
 services.AddAuthorization(options =>
    {
        options.AddPolicy("Users", policy =>
        policy.RequireRole("Users"));
    });

  //      JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                                      options.DefaultScheme = "Cookies";
                                      options.DefaultChallengeScheme = "oidc";
                                      
            }).AddCookie(options => { options.LoginPath = "/Login"; }).AddOpenIdConnect("oidc", options =>
                {


options.SignInScheme = "Cookies";

                    options.Authority = Configuration["oidc:Authority"]; // "http://127.0.0.1:8080/auth/realms/master";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = Configuration["oidc:ClientId"]; //"simplelogin";
                    options.ClientSecret=Configuration["oidc:ClientSecret"]; //"27f676ed-1cad-4a8b-9ba6-a429c47aa599";
                    options.SaveTokens = true;
});


            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToPage("/Login");
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();

    }
  }
}
