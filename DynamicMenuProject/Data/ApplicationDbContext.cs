using System;
using System.Collections.Generic;
using System.Text;
using DynamicMenuProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DynamicMenuProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<MenuPermissions> MenuPermissions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<CMSItems> CMSItems { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<FeedbackForm> FeedbackForm { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<RelatedValues> RelatedValues { get; set; }
        public DbSet<FeedbackResult> FeedbackResult { get; set; }
    }
}
