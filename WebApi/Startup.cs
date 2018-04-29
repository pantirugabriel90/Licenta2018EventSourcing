﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CQRSlite.Domain;
using CQRSlite.Commands;
using CQRSlite.Routing;
using CQRSlite.Events;
using Domain;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using WebApi.Models;
using WebApi.Auth;
using DataLayer.RavenDB;
using Services.Queries;

namespace WebApi
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
            services.AddIdentity<User, IdentityRole>()
                                                               .AddEntityFrameworkStores<IdentityContext>()
                                                               .AddDefaultTokenProviders();
            services.AddDbContext<IdentityContext>(options =>
                                                              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Authentication/Login/";
                options.AccessDeniedPath = "/Authentication/Login/";
            });
            services.Configure<RavenSettings>(Configuration.GetSection("Raven"));
            services.AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();
            services.AddSingleton<IViewSincronizor, ViewSincronizor>();
            services.AddScoped<ISession, Session>();
            services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<Router>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());
            services.AddSingleton<IEventStore>(y=>new RavenEventStore(y.GetService<IDocumentStoreHolder>()));
            // services.AddSingleton<IEventStore>(y=>new SqlEventStore(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository>(y => new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
