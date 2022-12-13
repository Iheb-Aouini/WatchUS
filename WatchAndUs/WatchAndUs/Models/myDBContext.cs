using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WatchAndUs.Models
{
    public class myDBContext : DbContext
    {
        
        public myDBContext() : base("watch")
        {

        }
        public DbSet<user> users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Watcher> Watchers { get; set; }
    }
}