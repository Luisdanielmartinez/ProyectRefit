using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProyectRefit.Backend.bdContext;
using ProyectRefit.Backend.Models;

namespace ProyectRefit.Backend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationContext>(
                options => options.UseInMemoryDatabase("ArticuloPruevaDb"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>() {
                    new User(){
                        FirstName ="Luis",
                        LastName="Martinez",
                        Email="Luisdaniel@gmail.com",
                        Passowrd="12345",
                        Tell="829-662-8990"
                         
                    },
                      new User(){
                        FirstName ="Daniel",
                        LastName="Perez",
                        Email="Perez@gmail.com",
                        Passowrd="12345",
                        Tell="829-662-6653"

                    }
                });
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>()
                {
                    new Product()
                    {
                        Image="image",
                        Name="Samsung",
                        Description="Este es un telefono",
                        IsAvalible=true,
                        Price=232,
                        user=new User
                        {

                        }
                    },
                     new Product()
                     {
                        Image="image",
                        Name="pc",
                        Description="Este es un computadora",
                        IsAvalible=true,
                        Price=39,
                        user=new User(){
                            FirstName ="Daniel",
                            LastName="Perez",
                            Email="Perez@gmail.com",
                            Passowrd="12345",
                            Tell="829-662-6653"

                        }

                     }
                     
                });
                context.SaveChanges();
            }
        }
    }
}
