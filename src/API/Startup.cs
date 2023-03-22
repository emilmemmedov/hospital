using Autofac;
using Memorial.API.Configuration.Auth;
using Memorial.API.Modules.Hospital;
using Memorial.API.Modules.Identity;
using Memorial.Modules.Hospital.Infrastructure.Configuration;
using Memorial.Modules.Identity.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Memorial.API
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
            InitializeModules(services);
            
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddSingleton<IJwtProvider, JwtProvider>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Memorial.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Memorial.API v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new HospitalAutofacModule());
            containerBuilder.RegisterModule(new IdentityAutofacModule());
        }

        private void InitializeModules(IServiceCollection service)
        {
            HospitalModuleStartup
                .Initialize(
                    Configuration.GetConnectionString("PostgresDBConnection"),
                    service
                );
            
            IdentityModuleStartup
                .Initialize(
                    Configuration.GetConnectionString("PostgresDBConnection"),
                    service
                );
        }
    }
}
