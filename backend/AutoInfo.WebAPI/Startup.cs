using AutoInfo.DLL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoInfo.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarReportDbContext>((_, builder) =>
            {
                builder.UseNpgsql(_configuration.GetConnectionString("CarReportsDatabase"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(GetType().Assembly.FullName));
            });

            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoInfo API"); });
            app.UseEndpoints(builder => { builder.MapControllers(); });
        }
    }
}