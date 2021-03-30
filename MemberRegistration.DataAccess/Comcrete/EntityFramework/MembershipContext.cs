using MemberRegistration.DataAccess.Comcrete.EntityFramework.Mappings;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccess.Comcrete.EntityFramework
{
    public class MembershipContext : DbContext
    {
        public MembershipContext()
        {
            Database.SetInitializer<MembershipContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberMap());
        }
        public DbSet<Member> Members { get; set; }
    
    }
}
