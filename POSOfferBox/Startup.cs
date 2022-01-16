using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POSOfferBox.BL;
using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.BL.EngineCore.Concrete;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo;
using POSOfferBox.Repo.Core.Abstract;
using POSOfferBox.Repo.Core.Concrete;
using POSOfferBox.Repo.Core.Factory.Abstract;
using POSOfferBox.Repo.Core.Factory.Concrete;
using POSOfferBox.Auth.Middleware;
using POSOfferBox.Auth.Helpers;
using POSOfferBox.Auth.Services;
using Utilities.CrypHelpers;
using System.Collections.Generic;

namespace POSOfferBox
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
            services.AddDbContext<POSOFFERBOXDBContext>(conf => conf.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "POSOfferBox", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization:Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            new List<string>()
                        }
                    });
            });


            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IHashHelper, HashHelper>();

        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            //Repository Services
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DataRepositoryFactory>().As<IDataRepositoryFactory>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IDataRepository<>)).InstancePerDependency();
            //End Repository Services

            //Engine Services
            builder.RegisterType<BusinessEngineFactory>().As<IBusinessEngineFactory>().InstancePerLifetimeScope();
            //End Engines Services

            //Modules
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<BLModule>();
            //End Modules
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POSOfferBox v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseAuthorization();
            app.UseJwtMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
