using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using WFS.Data;
using System.Security.Principal;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WFS.Data.Model;

namespace WFS.WebApi.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //  DbSet<ApplicationProperties> appProperties { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

       

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync()
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IAuditModel &&
                                                                            (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IAuditModel))
            {

                var userId = HttpContext.Current.User.Identity.GetUserId();
                history.UpdatedOn = DateTime.Now.Ticks;
                history.UpdatedBy = userId;

                if (history.CreatedOn == DateTime.MinValue.Ticks)
                {
                    history.CreatedOn = DateTime.Now.Ticks;
                    history.CreatedBy = userId;
                    history.IsDeleted = false;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}