using AutoMapper;
using Domain.Data;
using Domain.Utils;
using FluentValidation.AspNetCore;
using Infraestructura.Interfaces.TypeOfUsers;
using Infraestructura.Interfaces.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Repository;
using Repositories.Repository.TypeofUsers;
using Repositories.Repository.Users;
using System;


namespace SixDegreesItSolutionAPI
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
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddDbContext<SDDbContexto>(
            options => options.UseSqlServer("name=ConnectionStrings:myConnection"));
            services.AddTransient<IUserRepositoryRead,UsersRepositoryRead>();
            services.AddTransient<IUserRepositoryWrite, UserRepositoryWrite>();
            services.AddTransient<ITypeOfUserRepositoryRead, TypeOfUserRepositoryRead>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
