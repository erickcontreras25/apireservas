using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reserva.AppService;
using Reserva.Domain;
using Reserva.Models;

namespace Reserva
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddScoped<ComplejoAppService>();
            services.AddScoped<ComplejoDomain>();
            services.AddScoped<CanchaAppService>();
            services.AddScoped<CanchaDomain>();
            services.AddScoped<ReservacionAppService>();
            services.AddScoped<ReservacionDomain>();

            services.AddScoped<EquipoAppService>();
            services.AddScoped<EquipoDomain>();

            services.AddScoped<TorneoAppService>();
            services.AddScoped<TorneoDomain>();


            //services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Data Source=DESKTOP-PKMVCOP;Initial Catalog=Reserva;Trusted_Connection=True"));
            services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Data Source=216.155.157.158;Integrated Security=False;User ID=alejandro;Password=if^jR548;Connect Timeout=15;Encrypt=False;Packet Size=4096"));


            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
                 .AddEntityFrameworkStores<DBContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "yourdomain.com",
                     ValidAudience = "yourdomain.com",
                     IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Llave_secreta"])),
                     ClockSkew = TimeSpan.Zero
                 });


            //services.AddTransient<ProyectoServices, ProyectoServices>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(ConfigureJson);

            services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors("PermitirTodo");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
