using MealManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace MealManagementApp.Data
{
    public class MealDbContext : DbContext
    {
        public MealDbContext(DbContextOptions<MealDbContext>options) : base(options)
        {
        }

        public DbSet<EmployeeMeal> EmployeeMeal { get; set; }
    }
}
