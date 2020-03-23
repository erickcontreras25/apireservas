using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Reserva.AppService;
using Reserva.Domain;

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
            services.AddScoped<UsuarioAppService>();
            services.AddScoped<UsuarioDomain>();
            services.AddScoped<EquipoAppService>();
            services.AddScoped<EquipoDomain>();
            services.AddScoped<AdminAppService>();
            services.AddScoped<AdminDomain>();
            services.AddScoped<TorneoAppService>();
            services.AddScoped<TorneoDomain>();


            services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Data Source=DESKTOP-PKMVCOP;Initial Catalog=Reservaciones;Trusted_Connection=True"));
            services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("Server=DESKTOP-PKMVCOP;Initial Catalog=Reservaciones;Persist Security Info=False;User ID=sa;Password=usuario34;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            //services.AddTransient<ProyectoServices, ProyectoServices>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
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

            app.UseCors("PermitirTodo");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
