using EDGM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EDGM.App
{
    public class Startup
    {
        //-----------------------------------------------
        public IConfiguration config { get; }
        //---------------------------------------------------------------------------------------------------
        public Startup(IConfiguration configuration)
        {
            config = configuration;                              // read appsettings.json file
        }
        //---------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------  SERVICES
        public void ConfigureServices(IServiceCollection services)
        {
            //--------------------------------
            services.AddMvc()
                    .AddJsonOptions(options => {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
            //--------------------------------
            services.AddCors();
            //--------------------------------
            services.AddDbContext<DataContext>(options => options.UseSqlite("EDGM.db"));
            //--------------------------------
        }
        //---------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------  CONFIGURE
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //--------------------------------
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //--------------------------------
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            //--------------------------------
            app.UseMvc();
            //--------------------------------

            // ===== Create tables ======
            SeedData.SeedDatabase(new DataContext(), config);
        }
        //---------------------------------------------------------------------------------------------------
    }
}
