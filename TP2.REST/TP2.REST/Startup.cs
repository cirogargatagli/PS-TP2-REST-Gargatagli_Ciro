using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;
using TP2.REST.AccessData;
using TP2.REST.AccessData.Commands;
using TP2.REST.AccessData.Queries;
using TP2.REST.Application.Services;
using TP2.REST.Domain.Commands;
using TP2.REST.Domain.Queries;

namespace TP2.REST
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
            var connectionString = Configuration.GetSection("ConnectionString").Value;

            //EF CORE
            services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(connectionString));

            //SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(s =>
            {
                return new SqlConnection(connectionString);
            });

            //SWAGGER
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "REST", Version = "v1" });
            });


            services.AddTransient<IGenericRepository, GenericsRepository>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<IAlquilerService, AlquilerService>();
            services.AddTransient<IClienteQuery, ClienteQuery>();
            services.AddTransient<ILibroQuery, LibroQuery>();
            services.AddTransient<IAlquilerQuery, AlquilerQuery>();
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


            //Indicamos a la app utilizar swagger
            app.UseSwagger();

            //Indicamos a la app utilizar la interfaz de swagger
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "REST V1");
                s.RoutePrefix = string.Empty;
            });
        }
    }
}