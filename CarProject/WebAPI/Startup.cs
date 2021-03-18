using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            //AutoFac = bize AOP imkaný sunuyor 
      //      //AutoFac, Ninject, CastleWindsor, StructureMap, LightInJect, DryInJect  --> IoC Container
            // Bunlar .Net Projelerinde aþaðýdaki hareketi yapýyoruz -- Build -- Kýsaca bize IoC alt yapýsý sunuyor
            //AOP -- Bir metotun önünde veya sonunda çalýþan kodlarý yazýyoruz
            services.AddControllers();
            services.AddSingleton<ICarService,CarManager>(); //Bana Arka planda referans oluþtur                      
            services.AddSingleton<ICarDal, EFCarDal>();      // Bir baðýmlýlýk görürsen karþýlýðý budur      
            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<IBrandDal, EfBrandDal>();
            services.AddSingleton<IColorService, ColorManager>();
            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<IRentalService, RentalManager>();
            services.AddSingleton<IRentalDal, EfRentalDal>();
            services.AddSingleton<ICustomerService, CustomerManager>();
            services.AddSingleton<ICustomerDal, EfCustomerDal>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
