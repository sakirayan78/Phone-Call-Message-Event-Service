using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using ByX.Model.Common;

namespace ByX.Model
{
   public class ByXContext : DbContext
    {
        public ByXContext()
            : base("Name=MainDb")
        {

        }
        public DbSet<PhoneDetail.PhoneDetail> PhoneDetails { get; set; }
        public DbSet<MessageDetail.MessageDetail> MessageDetails { get; set; }
        public DbSet<CallDetail.CallDetail> CallDetails { get; set; }
        public DbSet<PhoneBook.PhoneBook> PhoneBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
