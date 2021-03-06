using GoodToCode.Entity.Event;
using GoodToCode.Entity.Person;
using GoodToCode.Framework.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GoodToCode.Entity.WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<HttpCrudOptions>(Configuration.GetSection("HttpCrudEndpoints"));
            services.Configure<HttpQueryOptions>(Configuration.GetSection("HttpQueryEndpoints"));

            services.AddHttpCrud<PersonDto>(); // Add Get, Put, Post, Delete calls as CRUD-aligned requests
            services.AddHttpQuery<PersonDto>(); // Add Url Query based calls that return lists


            services.AddHttpCrud<EventDto>(); // Add Get, Put, Post, Delete calls as CRUD-aligned requests
            services.AddHttpQuery<EventDto>(); // Add Url Query based calls that return lists

            // Mvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvcWithDefaultRoute();
        }
    }
}
