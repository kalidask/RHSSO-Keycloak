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
                //options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               // options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        // OpenId authentication
                 options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(options => { options.LoginPath = "/Login"; }).
/*            AddOpenIdConnect(options =>
    {
        // URL of the Keycloak server
        options.Authority = "http://localhost:8080/auth/realms/master";
        // Client configured in the Keycloak
        options.ClientId = "simplelogin";

        // For testing we disable https (should be true for production)
        options.RequireHttpsMetadata = false;
        options.SaveTokens = true;

        // Client secret shared with Keycloak
        options.ClientSecret = "27f676ed-1cad-4a8b-9ba6-a429c47aa599";
        options.GetClaimsFromUserInfoEndpoint = true;

        // OpenID flow to use
        options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
    }); 

*/

AddOpenIdConnect(options =>
    {
        options.Authority = Configuration["oidc:Authority"];
        options.ClientId = Configuration["oidc:ClientId"];
        options.ClientSecret = Configuration["oidc:ClientSecret"];
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.RemoteSignOutPath = "/SignOut";
        options.SignedOutRedirectUri = "http://localhost:5000/";
        options.ResponseType = "code";

options.Scope.Clear();
                options.Scope.Add("openid");

                options.ClaimsIssuer = "oidc";




options.Events = new OpenIdConnectEvents
                {
                 
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"http://{Configuration["oidc:Authority"]}/v2/logout?client_id={Configuration["oidc:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/Login"))
                            {
                 
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                }; 
    });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToPage("/Login");
            });
        }


/* private OpenIdConnectOptions CreateKeycloakOpenIdConnectOptions()
    {
        var options = new OpenIdConnectOptions
        {
            AuthenticationScheme = "oidc",
            SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme,
            Authority = Configuration["Authentication:KeycloakAuthentication:ServerAddress"]+"/auth/realms/"+ Configuration["Authentication:KeycloakAuthentication:Realm"],
            RequireHttpsMetadata = false, //only in development
            PostLogoutRedirectUri = Configuration["Authentication:KeycloakAuthentication:PostLogoutRedirectUri"],
            ClientId = Configuration["Authentication:KeycloakAuthentication:ClientId"],
            ClientSecret = Configuration["Authentication:KeycloakAuthentication:ClientSecret"],
            ResponseType = OpenIdConnectResponseType.Code,
            GetClaimsFromUserInfoEndpoint = true,
            SaveTokens = true

        };
        options.Scope.Add("openid");
        return options;
    } 
    
*/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();

  /*            app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
            AutomaticAuthenticate = true,
            CookieHttpOnly = true,
            CookieSecure = CookieSecurePolicy.SameAsRequest
        });
        app.UseOpenIdConnectAuthentication(CreateKeycloakOpenIdConnectOptions());
        }
    } */
    }
  }
}
