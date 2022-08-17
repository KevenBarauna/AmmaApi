using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Business.Service;
using Amma.Business.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Amma.Infrastructure.Interfaces;
using Amma.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;
using Amma.Api.AutoMapper.Mapper;
using Amma.Business.Validations;
using Amma.Business.Validations.Usuario;

namespace Amma.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Amma.Api", Version = "v1" });
            });

             services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            
            //DB
            string stringConnection = "Server=localhost;Database=Amma;Trusted_Connection=True;";
            services.AddDbContext<Contexto>((options) => options.UseSqlServer(stringConnection));

            // SERVICE
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPermissaoService, PermissaoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IStatusService, StatusService>();

            // REPOSITORY
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amma.Api v1"));
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
