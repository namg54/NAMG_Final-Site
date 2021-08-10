using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;
using NAMG_Final.Data.Repository;
using NAMG_Final.Services;
using NAMG_Final.Services.Contact;

namespace NAMG_Final
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region  Db Context

            services.AddDbContext<MySiteContext>(options => options.UseSqlServer("Data Source = .;Initial Catalog=automation_DB;Integrated Security=true"));
            //services.AddDbContext<MySiteContext>(options => options.UseSqlServer("Server=.;Initial Catalog=namgir_namg_DB;User Id=namgir_namg_DB;Password=D&587joz;MultipleActiveResultSets=true"));

            #endregion

            #region IOC

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region Authentication

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Logout";
                    option.ExpireTimeSpan = TimeSpan.FromDays(30);
                });

            #endregion
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IContactMessage, ContactMessage>();
            //services.Configure<EmailConfigViewModel>(option => Configuration.GetSection("EmailConfigs").Bind(option));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/Admin"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                    else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                   
                   
                }

                await next.Invoke();
            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=About}/{id?}");
            });
        }

        //static void myhandler(IApplicationBuilder app)
        //{
        //    app.Use(async (Context,next) =>
        //    {
        //        if (!Context.User.Identity.IsAuthenticated)
        //        {
        //            Context.Response.Redirect("/Account/Login");
        //        }
        //        else
        //        {
        //            await next.Invoke();
        //        }
        //    });
    }
}

