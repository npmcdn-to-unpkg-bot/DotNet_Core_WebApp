using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bristrong.Official.WebService.Models
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions options)
            : base(options)
        { }


        public DbSet<AppUser> Users { get; set; }
        //public DbSet<News> NewsSet { get; set; }
        //public DbSet<JobInformation> JobInformationSet { get; set; }

    }
}
