using Repository.Data;
using System.Data.Entity;

namespace Repository
{
    public class InstagramContext : DbContext
    {
        public InstagramContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
    }
}
