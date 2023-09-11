using System;
using Core.Common.Models;
using Core.StudentModule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
		}
        public DbSet<Core.StudentModule.Models.Student> Students { get; set; }
    }
}

 