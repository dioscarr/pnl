﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pnl.Data.Models;
using pnl.Models;

namespace pnl.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaxForm> TaxForms { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public DbSet<CriteriaOption> CriteriaOption { get; set; }
        public DbSet<Dependent> Dependent { get; set; }
        public DbSet<DependentCareProviders> DependentCare { get; set; }
        public DbSet<TaxFormCriteria> TaxFormCriteria { get; set; }
        public DbSet<FilingStatus> FilingStatus { get; set; }
        public DbSet<TaxFormAddress> TaxFormAddress { set; get; }
        public DbSet<TaxFormPerson> TaxFormPeople { set; get; }
        public DbSet<QuestionsTaxForm> QuestionsTaxForms{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerType> AnswerTypes{ get; set; }
        public DbSet<Answer> Answers{ get; set; }
        public DbSet<FormStep> FormSteps { get; set; }
        public DbSet<USAStates> USAStates { get; set; }
        public DbSet<Notifications> Notifications{ get; set; }
    }
}
