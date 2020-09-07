using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pnl.Data.Models;

namespace pnl.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaxForm> TaxtForms { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public DbSet<CriteriaOption> CriteriaOptions { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<DependentCareProviders> DependentCares { get; set; }
        public DbSet<TaxFormCriteria> TaxFormCriterias { get; set; }
    }
}
