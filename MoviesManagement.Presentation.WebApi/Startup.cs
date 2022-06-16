using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviesManagement.Core.Application;
using MoviesManagement.Infrastructure.Persistence;
using MoviesManagement.Presentation.WebApi.Extensions.Middlewares;

namespace MoviesManagement.Presentation.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesManagement.Presentation.WebApi", Version = "v1" });
            });

            services.AddControllers().AddFluentValidation();
            services.AddApplicationLayer(Configuration);
            services.AddPersistenceLayer(Configuration);
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesManagement.Presentation.WebApi v1"));
            }

            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
