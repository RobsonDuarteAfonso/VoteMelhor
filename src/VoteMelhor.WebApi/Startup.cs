using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Text;
using VoteMelhor.Domain.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Infra.Data;
using VoteMelhor.Infra.Data.Repositories;
using VoteMelhor.WebApi.Services;

namespace VoteMelhor.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddDbContext<VoteMelhorContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();

            services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvc().AddNewtonsoftJson(opt => {
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter());                
            });

            //WebApi
            services.AddScoped<TokenService>();

            // Application
            services.AddTransient<LawSuitHandler, LawSuitHandler>();
            services.AddTransient<PartyHandler, PartyHandler>();
            services.AddTransient<PoliticalPartyHandler, PoliticalPartyHandler>();
            services.AddTransient<PoliticalHandler, PoliticalHandler>();
            services.AddTransient<PositionHandler, PositionHandler>();
            services.AddTransient<ProposalHandler, ProposalHandler>();
            services.AddTransient<RatingHandler, RatingHandler>();
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<VotingHandler, VotingHandler>();
            services.AddTransient<SenatorCongressmanHandler, SenatorCongressmanHandler>();


            // Infra - Data
            services.AddTransient<IVotingRepository, VotingRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IProposalRepository, ProposalRepository>();
            services.AddTransient<ILawSuitRepository, LawSuitRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPoliticalRepository, PoliticalRepository>();
            services.AddTransient<IPartyRepository, PartyRepository>();
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IPoliticalPartyRepository, PoliticalPartyRepository>();
            services.AddTransient<VoteMelhorContext>();

            //Config Autentication
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Vote Melhor", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vote Melhor");
            });

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
