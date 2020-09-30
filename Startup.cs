using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using pnl.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skclusive.Material.Component;
using Skclusive.Core.Component;
using Microsoft.AspNetCore.Http;
using pnl.Models;
using Microsoft.AspNetCore.DataProtection;

namespace pnl
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
            var server = Configuration["DBServer"] ?? "db";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Password@123";
            var database = Configuration["PNL"] ?? "PNL";
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer($"Server={server},{port}; Initial Catalog={database}; User ID={user}; password={password}"));

            // Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //  services.AddSignalR();

            services.AddAntiforgery();
            services.AddDataProtection();

            //services.AddDataProtection().SetApplicationName("pnl");
            services.AddHttpContextAccessor();
            services.AddScoped<IRenderContext>((sp) =>
            {
                var httpContextAccessor = sp.GetService<IHttpContextAccessor>();
                bool? hasStarted = httpContextAccessor?.HttpContext?.Response.HasStarted;
                var isPreRendering = !(hasStarted.HasValue && hasStarted.Value);
                return new RenderContext(isServer: true, isPreRendering);
            });

            
            services.AddServerSideBlazor();
            services.AddControllersWithViews();
            services.TryAddMaterialServices(new MaterialConfigBuilder().WithIsServer(true).WithIsPreRendering(false).Build());
            services.AddScoped<TaxFormService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            using (var srvc = app.ApplicationServices.CreateScope())
            {
                var context = srvc.ServiceProvider.GetService<ApplicationDbContext>();
                //seeding
                context.Database.Migrate();
                if (!context.CriteriaOption.Any())
                {
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Full Year Resident", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Part Year Resident", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Blind", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Standard Deduction", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Public Housing", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Home owner", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Married", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Itemized Deduction", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Noncustodial Parent", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Divorced", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Nursing Home", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Moved For Work", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Renter", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Rent Paid", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Paid Child Care", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Foreign Income", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "School / University", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Retirement Account", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Pay Child support", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Convicted Of A Felony", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Filing For Deceased", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Electric Car", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Charitable donation", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Capital Gain/ Loss", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Your Dependent(s) Have Income", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = " Dependent on someone else Taxes", Enabled = true });
                    context.CriteriaOption.Add(new Data.Models.CriteriaOption { Name = "Income From Other State(s)", Enabled = true });
                    context.SaveChanges();
                }
                if (!context.FilingStatus.Any())
                {
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Single" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus {isEnabled = true,Name = "Married filing jointly"});
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Married filing separately" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Head of household" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Qualifying widow(er) with dependent child" });
                    context.SaveChanges();
                }
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //  endpoints.MapFallbackToPage("/_Host");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });
        }
    }
}
