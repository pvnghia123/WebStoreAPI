using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAPI.Interface;
using WebStoreAPI.Models.DatebaseContext;
using WebStoreAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore;
using System.Text;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using WebStoreAPI.Service;

namespace WebStoreAPI
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
            var connection = Configuration.GetConnectionString("DbConnectString");
            services.AddDbContextPool<DatabaseContext>(option => option.UseSqlServer(connection));
            services.AddTransient<IProduct, ProductRepository>();
            //services.AddTransient<IUserInfo, UserInfoRepository>();
            services.AddScoped<IUserInfo, UserInfoRepository>();
            services.AddScoped<IAcccessToken, AssessTokenRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAuthentication(Configuration);
            services.AddSwaggerDocumentation();
            services.AddAuthorizationStarup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
