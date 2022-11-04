using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostgresCRUD.DataAccess;


namespace PostgresCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];

            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddScoped<IDataAccessProvider, DataAccessProvider>();
            services.AddSwaggerGen(setupAction =>

            {

                setupAction.SwaggerDoc("LibraryOpenAPISpecification",

                new Microsoft.OpenApi.Models.OpenApiInfo()

                {

                    Title = "PostgresCRUD",

                    Version = "1"

                });



            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
                //.AllowCredentials());
            });

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();


            app.UseSwaggerUI(setupAction =>

            {

                setupAction.SwaggerEndpoint(

                "/swagger/LibraryOpenAPISpecification/swagger.json",

                "PostgresCRUD");



            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
