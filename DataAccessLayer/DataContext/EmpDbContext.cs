using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class EmpDbContext : DbContext

    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeData> Employees { get; set; }


    }
}
