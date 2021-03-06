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
using Skclusive.Material.Core;
using pnl.Data.Models;
using pnl.Models.Helpers;
using Microsoft.AspNetCore.Identity.UI.Services;

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
            //server = "localhost";
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer($"Server={server},{port}; Initial Catalog={database}; User ID={user}; password={password}"));

            // Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            //.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            //  services.AddSignalR();
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("SuperAdminOnly", policy => policy.RequireRole("SuperAdmin"));
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });
            services.AddDataProtection();
            services.AddAntiforgery();

            services.AddDataProtection().SetApplicationName("pnl");
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
            services.AddTransient<ITaxFormService,TaxFormService>();
            services.AddTransient<IEmailSender, emailSend>();

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
            //app.Use((ctx, next) =>
            //{
            //    ctx.Request.Scheme = "https";
            //    return next();
            //});
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
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "GetStarted" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Continue" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Filed" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "Approved" });
                    context.FilingStatus.Add(new Data.Models.FilingStatus { isEnabled = true, Name = "NotApproved" });
                    context.SaveChanges();
                }
                context.Database.OpenConnection();

                if (!context.USAStates.Any())
                {
                       context.USAStates.Add(new USAStates { Name="Alaska",Abrv="AK"});
                       context.USAStates.Add(new USAStates { Name="Alabama",Abrv="AL"});
                       context.USAStates.Add(new USAStates { Name="American Samoa",Abrv="AS"});
                       context.USAStates.Add(new USAStates { Name="Arizona",Abrv="AZ"});
                       context.USAStates.Add(new USAStates { Name="Arkansas",Abrv="AR"});
                       context.USAStates.Add(new USAStates { Name="California",Abrv="CA"});
                       context.USAStates.Add(new USAStates { Name="Colorado",Abrv="CO"});
                       context.USAStates.Add(new USAStates { Name="Connecticut",Abrv="CT"});
                       context.USAStates.Add(new USAStates { Name="Delaware",Abrv="DE"});
                       context.USAStates.Add(new USAStates { Name="District of Columbia",Abrv="DC"});
                       context.USAStates.Add(new USAStates { Name="Federated USAStates of Micronesia",Abrv="FM"});
                       context.USAStates.Add(new USAStates { Name="Florida",Abrv="FL"});
                       context.USAStates.Add(new USAStates { Name="Georgia",Abrv="GA"});
                       context.USAStates.Add(new USAStates { Name="Guam",Abrv="GU"});
                       context.USAStates.Add(new USAStates { Name="Hawaii",Abrv="HI"});
                       context.USAStates.Add(new USAStates { Name="Idaho",Abrv="ID"});
                       context.USAStates.Add(new USAStates { Name="Illinois",Abrv="IL"});
                       context.USAStates.Add(new USAStates { Name="Indiana",Abrv="IN"});
                       context.USAStates.Add(new USAStates { Name="Iowa",Abrv="IA"});
                       context.USAStates.Add(new USAStates { Name="Kansas",Abrv="KS"});
                       context.USAStates.Add(new USAStates { Name="Kentucky",Abrv="KY"});
                       context.USAStates.Add(new USAStates { Name="Louisiana",Abrv="LA"});
                       context.USAStates.Add(new USAStates { Name="Maine",Abrv="ME"});
                       context.USAStates.Add(new USAStates { Name="Marshall Islands",Abrv="MH"});
                       context.USAStates.Add(new USAStates { Name="Maryland",Abrv="MD"});
                       context.USAStates.Add(new USAStates { Name="Massachusetts",Abrv="MA"});
                       context.USAStates.Add(new USAStates { Name="Michigan",Abrv="MI"});
                       context.USAStates.Add(new USAStates { Name="Minnesota",Abrv="MN"});
                       context.USAStates.Add(new USAStates { Name="Mississippi",Abrv="MS"});
                       context.USAStates.Add(new USAStates { Name="Missouri",Abrv="MO"});
                       context.USAStates.Add(new USAStates { Name="Montana",Abrv="MT"});
                       context.USAStates.Add(new USAStates { Name="Nebraska",Abrv="NE"});
                       context.USAStates.Add(new USAStates { Name="Nevada",Abrv="NV"});
                       context.USAStates.Add(new USAStates { Name="New Hampshire",Abrv="NH"});
                       context.USAStates.Add(new USAStates { Name="New Jersey",Abrv="NJ"});
                       context.USAStates.Add(new USAStates { Name="New Mexico",Abrv="NM"});
                       context.USAStates.Add(new USAStates { Name="New York",Abrv="NY"});
                       context.USAStates.Add(new USAStates { Name="North Carolina",Abrv="NC"});
                       context.USAStates.Add(new USAStates { Name="North Dakota",Abrv="ND"});
                       context.USAStates.Add(new USAStates { Name="Northern Mariana Islands",Abrv="MP"});
                       context.USAStates.Add(new USAStates { Name="Ohio",Abrv="OH"});
                       context.USAStates.Add(new USAStates { Name="Oklahoma",Abrv="OK"});
                       context.USAStates.Add(new USAStates { Name="Oregon",Abrv="OR"});
                       context.USAStates.Add(new USAStates { Name="Palau",Abrv="PW"});
                       context.USAStates.Add(new USAStates { Name="Pennsylvania",Abrv="PA"});
                       context.USAStates.Add(new USAStates { Name="Puerto Rico",Abrv="PR"});
                       context.USAStates.Add(new USAStates { Name="Rhode Island",Abrv="RI"});
                       context.USAStates.Add(new USAStates { Name="South Carolina",Abrv="SC"});
                       context.USAStates.Add(new USAStates { Name="South Dakota",Abrv="SD"});
                       context.USAStates.Add(new USAStates { Name="Tennessee",Abrv="TN"});
                       context.USAStates.Add(new USAStates { Name="Texas",Abrv="TX"});
                       context.USAStates.Add(new USAStates { Name="Utah",Abrv="UT"});
                       context.USAStates.Add(new USAStates { Name="Vermont",Abrv="VT"});
                       context.USAStates.Add(new USAStates { Name="Virgin Islands",Abrv="VI"});
                       context.USAStates.Add(new USAStates { Name="Virginia",Abrv="VA"});
                       context.USAStates.Add(new USAStates { Name="Washington",Abrv="WA"});
                       context.USAStates.Add(new USAStates { Name="West Virginia",Abrv="WV"});
                       context.USAStates.Add(new USAStates { Name="Wisconsin",Abrv="WI"});
                       context.USAStates.Add(new USAStates { Name="Wyoming",Abrv="WY"});
                       context.USAStates.Add(new USAStates { Name="Armed Forces Africa",Abrv="AE"});
                       context.USAStates.Add(new USAStates { Name="Armed Forces Americas (except Canada)",Abrv="AA"});
                       context.USAStates.Add(new USAStates { Name="Armed Forces Canada",Abrv="AE"});
                       context.USAStates.Add(new USAStates { Name="Armed Forces Europe",Abrv="AE"});
                       context.USAStates.Add(new USAStates { Name="Armed Forces Middle East",Abrv="AE"});
                       context.USAStates.Add(new USAStates { Name = "Armed Forces Pacific", Abrv = "AP" });
                       context.SaveChanges();
                }
                if (!context.AnswerTypes.Any())
                {
                    context.Add(new AnswerType { Type = "Radio" });
                    context.Add(new AnswerType { Type = "TextBox" });
                    context.Add(new AnswerType { Type = "DropDown" });
                    context.Add(new AnswerType { Type = "CheckBox" });
                    context.SaveChanges();
                }
       
                if (!context.FormSteps.Any())
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FormSteps ON");
                    context.Add(new FormStep { Id = 8, TheStep = 1, StepName = "Basic Information", Section = 1, SectionName = "Part 1 - Expenses � Last Year, Did You (or Your Spouse) Pay", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    
                    context.Add(new FormStep { Id = 9, TheStep = 2, StepName = "Personal Information", Section = 1, SectionName = "Personal Information", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 10, TheStep = 2, StepName = "Personal Information", Section = 2, SectionName = "Section 2 - placeholder", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 11, TheStep = 2, StepName = "Personal Information", Section = 3, SectionName = "Spouse Information", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 12, TheStep = 2, StepName = "Personal Information", Section = 4, SectionName = "Section 4 - placeholder", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 13, TheStep = 2, StepName = "Personal Information", Section = 5, SectionName = "Section 5 Placeholder", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new FormStep { Id = 14, TheStep = 3, StepName = "Income", Section = 1, SectionName = "Part 1 - Expenses � Last Year, Did You (or Your Spouse) Pay", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });                    
                    context.Add(new FormStep { Id = 15, TheStep = 3, StepName = "Income", Section = 2, SectionName = "Part 2 - Expenses � Last Year, Did You (or Your Spouse) Pay", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 16, TheStep = 3, StepName = "Income", Section = 3, SectionName = "Part 3 � Life Events � Last Year, Did You (or Your Spouse)", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 17, TheStep = 3, StepName = "Income", Section = 4, SectionName = "Part 4 - Health Care Coverage - Last year, did you, your spouse, or dependent(s)", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 18, TheStep = 4, StepName = "Additional Information", Section = 1, SectionName = "Additional Information and Questions Related to the Preparation of Your Return", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new FormStep { Id = 19, TheStep = 4, StepName = "Additional Information", Section = 1, SectionName = "Additional Information and Questions Related to the Preparation of Your Return", isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });


                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FormSteps OFF");
                    context.Database.CloseConnection();
                }                
                if (!context.Questions.Any())
                {
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Are you a U.S citizen?", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "A. Full-time student", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "B. Totally and permanently disabled", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "C. Legally Blind", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Maritial Status", Order = 5, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "If yes, did you get married in 2019? ", Order = 6, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Did you live with your spouse during any part of the last six months of 2017?", Order = 7, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Date of final decree", Order = 8, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Date of separate maintenance agreement", Order = 9, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Year of spouse’s death", Order = 10, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Can anyone claim you or your spouse as a dependent?", Order = 11, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Date of final decree", Order = 12, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Date of separate maintenance agreement", Order = 13, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 10, TheQuestion = "Year of spouse’s death", Order = 14, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 11, TheQuestion = "is your spouse a us citizen?", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 11, TheQuestion = "A. Full-time student", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 11, TheQuestion = "B. Totally and permanently disabled", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 11, TheQuestion = "C. Legally Blind", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 13, TheQuestion = "A. Been a victim of identity theft?", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 13, TheQuestion = "B. Adopted a child?", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 14, TheQuestion = "1. (B) Wages or Salary? (Form W-2)",Order=1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "2. (A) Tip Income?", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "3. (B) Scholarships? (Forms W-2, 1098-T)", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "4. (B) Interest/Dividends from: checking/savings accounts, bonds, CDs, brokerage? (Forms 1099-INT, 1099-DIV)", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "5. (B) Refund of state/local income taxes? (Form 1099-G)", Order = 5, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "6. (B) Alimony income or separate maintenance payments?", Order = 6, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "7. (A) Self-Employment income? (Form 1099-MISC, cash)", Order = 7, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "8. (A) Cash/check payments for any work performed not reported on Forms W-2 or 1099?", Order = 8, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "9. (A) Income (or loss) from the sale of Stocks, Bonds or Real Estate? (including your home) (Forms 1099-S,1099-B)", Order = 9, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "10. (B) Disability income? (such as payments from insurance, or workers compensation) (Forms 1099-R, W-2)", Order = 10, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "11. (A) Payments from Pensions, Annuities, and/or IRA? (Form 1099-R)", Order = 11, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "12. (B) Unemployment Compensation? (Form 1099G)", Order = 12, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "13. (B) Social Security or Railroad Retirement Benefits? (Forms SSA-1099, RRB-1099)", Order = 13, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "14. (M) Income (or loss) from Rental Property?", Order = 13, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 14, TheQuestion = "15. (B) Other income? (gambling, lottery, prizes, awards, jury duty, Sch K-1, royalties, foreign income, etc.)", Order = 13, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 15, TheQuestion = "1. (B) Alimony or separate maintenance payments?", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "2. Contributions to a retirement account?", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "3. (B) College or post secondary educational expenses for yourself, spouse or dependents? (Form 1098-T)", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "4. (B) Unreimbursed employee business expenses? (such as uniforms or mileage)", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "5. (B) Medical expenses? (including health insurance premiums)", Order = 5, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "6. (B) Home mortgage interest? (Form 1098)", Order = 6, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "7. (B) Real estate taxes for your home or personal property taxes for your vehicle? (Form 1098)", Order = 7, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "8. (B) Charitable contributions?", Order = 8, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "9. (B) Child or dependent care expenses such as daycare?", Order = 9, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "10. (B) For supplies used as an eligible educator such as a teacher, teacher�s aide, counselor, etc.?", Order = 10, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 15, TheQuestion = "11. (A) Expenses related to self-employment income or any o", Order = 11, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 16, TheQuestion = "1. (HSA) Have a Health Savings Account? (Forms 5498-SA, 1099-SA, W-2 with code W in box 12)", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "2. (A) Have debt from a mortgage or credit card cancelled/forgiven by a commercial lender? (Forms 1099-C, 1099-A)", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "3. (A) Buy, sell or have a foreclosure of your home? (Form 1099-A)", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "4. (B) Have Earned Income Credit (EIC) or other credits disallowed in a prior year?", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "5. (A) Purchase and install energy-efficient home items? (such as windows, furnace, insulation, etc.)", Order = 5, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "6. (B) Live in an area that was affected by a natural disaster?", Order = 6, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "7. (A) Receive the First Time Homebuyers Credit in 2008?", Order = 7, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "8. (B) Make estimated tax payments or apply last year�s refund to this year�s tax?", Order = 8, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 16, TheQuestion = "9. (A) File a federal return last year containing a �capital loss carryover� on Form 1040 Schedule D?", Order = 9, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 17, TheQuestion = "1. (B) Have health care coverage?", Order = 1, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 17, TheQuestion = "2. (B) Receive one or more of these forms?", Order = 2, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 17, TheQuestion = "3. (A) Have coverage through the Marketplace (Exchange)? [Provide Form 1095-A]", Order = 3, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 17, TheQuestion = "3a. (A) If yes, were advance credit payments made to help you pay your health care premiums?", Order = 4, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 17, TheQuestion = "3b. (A) If yes, Is everyone listed on your Form 1095-A being cla", Order = 5, AnswerTypeId = 1, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

                    context.Add(new Question { FormStepId = 18, TheQuestion = "1. Provide an email address (optional) (this email address will not be used for contacts from the Internal Revenue Service) ", Order = 1, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "2. Presidential Election Campaign Fund (If you check a box, your tax or refund will not change) ", Order = 2, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });                    
                    context.Add(new Question { FormStepId = 18, TheQuestion = "Check here if you, or your spouse if filing jointly, want $3 to go to this fund You Spouse", Order = 3, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "3. If you are due a refund, would you like: ", Order = 4, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "4. If you have a balance due, would you like to make a payment directly from your bank account?", Order = 5, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "5. Have you or your spouse received any letters from the Internal Revenue Service?", Order = 6, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });                    
                    context.Add(new Question { FormStepId = 18, TheQuestion = "6. Other than English, what language is spoken in your home?", Order = 7, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "Prefer not to answer", Order = 8, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "7. Do you or any member of your household have a disability?", Order = 9, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });
                    context.Add(new Question { FormStepId = 18, TheQuestion = "8. Are you or your spouse a Veteran from the U.S. Armed Forces?", Order = 10, AnswerTypeId = 2, isEnabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, isDeleated = false, ModifiedBy = "admin" });

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
                name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapAreaControllerRoute(name: "admin",
                //    areaName: "PnlAccess",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}");


                //

               

                //  endpoints.MapFallbackToPage("/_Host");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();   
            });
        }
    }
}
