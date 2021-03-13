using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinders.Business.Abstract;
using HotelFinders.Business.Concrete;
using HotelFinders.DataAccess.Abstract;
using HotelFinders.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelFinders.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelManager>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(config=> {
                config.PostProcess = (doc => 
                {
                    doc.Info.Title = "Hotels Api";
                    doc.Info.Version = "13.10.1";
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
