using DevPals_TestWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPals_TestWork.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<HistoryModel> History { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
