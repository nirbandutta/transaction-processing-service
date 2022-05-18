using TransactionProcessingService.API.Extensions;
using TransactionProcessingService.API.MiddleWare;
using TransactionProcessingService.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TransactionProcessingService.API
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.RegisterServices(Configuration.GetConnectionString("IPP_CRM"), Configuration.GetConnectionString("IPP_TRN"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DE Bank Process API v1");
            });


            app.UseRouting();

            app.UseGlobalExceptionMiddleware();
            app.UseMiddleware<SerilogContextMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
