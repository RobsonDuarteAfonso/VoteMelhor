using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using System.Text;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;
using VoteMelhor.ApplicationCore.Services;
using VoteMelhor.Infra.Data;
using VoteMelhor.Infra.Data.Repositories;
using VoteMelhor.WebApi.AutoMapper;
using VoteMelhor.WebApi.Services;
using VoteMelhor.WebApi.Validations;

namespace VoteMelhor.WebApi
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
            services.AddCors();
            services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvc().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            //WebApi
            services.AddScoped<TokenService>();

            // Application
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPoliticoService, PoliticoService>();
            services.AddScoped<IPartidoService, PartidoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IPoliticoPartidoService, PoliticoPartidoService>();

            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPoliticoRepository, PoliticoRepository>();
            services.AddScoped<IPartidoRepository, PartidoRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IPoliticoPartidoRepository, PoliticoPartidoRepository>();
            services.AddScoped<VoteMelhorContext>();

            //Validações
            services.AddScoped<CreateUsuarioValidation>();

            // AutoMapper Settings
            services.AddAutoMapperSetup();



            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            //services.AddDependencyInjectionSetup();

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SettingsKey:Secret"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
