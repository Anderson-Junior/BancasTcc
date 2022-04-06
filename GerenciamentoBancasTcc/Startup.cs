using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GerenciamentoBancasTcc
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //                options.LoginPath = "/Account/Login");

            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            //foreach (string roleName in new[] {
            //    Helpers.RolesHelper.ADMINISTRADOR,
            //    Helpers.RolesHelper.PROFESSOR,
            //    Helpers.RolesHelper.COORDENADOR,
            //    Helpers.RolesHelper.ORIENTADOR
            //    })
            //{
            //    if (roleManager.RoleExistsAsync(roleName).Result
            //        || roleManager.CreateAsync(new IdentityRole { Name = roleName }).Result.Succeeded)
            //    {
            //        foreach (string userName in new[] { "ander.lemos.jr@gmail.com"/*, "emersonlemmos@gmail.com", "allan@gmail.com" */})
            //        {
            //            var user = userManager.FindByNameAsync(userName).Result;

            //            if (!userManager.IsInRoleAsync(user, roleName).Result)
            //            {
            //                _ = userManager.AddToRoleAsync(user, roleName).Result;
            //            }
            //        }
            //    }
            //}
        }
    }
}
