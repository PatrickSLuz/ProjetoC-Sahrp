using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoControleComprasWEB.Data;
using Repository;

namespace ProjetoControleComprasWEB
{
    public class Startup
    {

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AgenteLogado>>();
            string[] rolesNames = { "Administrador", "Gestor", "Usuario" };
            IdentityResult result;
            foreach (var namesRole in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(namesRole));
                }
            }
        }

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

            // Criar Injeção de Dependencia das DAOs
            services.AddScoped<AgenteDAO>();
            services.AddScoped<CargoDAO>();
            services.AddScoped<SetorDAO>();
            services.AddScoped<ProdutoDAO>();
            services.AddScoped<PedidoDAO>();

            // Configurando/Criando a injeção de dependencia (ID, ou em Inglês, DI) do Contexto
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ControleComprasConnection")));

            // Configurar o Identity - Auteticação
            services.AddIdentity<AgenteLogado, IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login/Login";
                options.AccessDeniedPath = "/Login/AcessoNegado";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Context context, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();
            DbInitializer.Initialize(context); // Metodo para inserir dados Default no BD.
        }
    }
}
