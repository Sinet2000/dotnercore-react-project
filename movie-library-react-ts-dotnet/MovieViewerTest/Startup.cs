using APIServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using MovieViewerTest.Core.Configuration;
using MovieViewerTest.Services;
using Services;

namespace MovieViewerTest
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
            // Read settings from config file
            services.Configure<APISettings>(Configuration.GetSection("APISettings"));

            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
            });

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });

            // Add application services.
            RegisterApplicationServices(services);

            // Add AutoMapper.
            services.AddAutoMapper(typeof(Startup));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>(sp => sp.GetService<DataContext>());
            services.AddScoped<IMovieAPIService, MovieAPIService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IQueryService, QueryService>();
            services.AddScoped<IMovieFoundByIMDbIDService, MovieFoundByIMDbIDService>();
            services.AddScoped<IMovieFoundByTitleService, MovieFoundByTitleService>();
            services.AddScoped<IMovieSearchedByTitleResultService, MovieSearchedByTitleResultService>();
        }
    }
}
