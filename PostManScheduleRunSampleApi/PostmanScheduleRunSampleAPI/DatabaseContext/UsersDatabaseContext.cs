using PostmanScheduleRunSampleAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostmanScheduleRunSampleAPI.DatabaseContext
{
    public class UsersDatabaseContext : DbContext
    {
        public UsersDatabaseContext(DbContextOptions<UsersDatabaseContext> options) : base(options)
        { }
        public DbSet<UsersModel> Users { get; set; }
    }
}
