using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Question.Core.Services.Implement;
using Question.Core.Services.Interfaces;
using Question.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question
{
    public class Startup
    {
        #region Constructor

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            #region Config Data Base
            services.AddDbContext<DataLayerContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Config Ioc
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IUserServices, UserService>();
            services.AddTransient<IUserQuestionService, UserQuestionsService>();
            #endregion

            #region Config Service
            services.AddControllersWithViews();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
