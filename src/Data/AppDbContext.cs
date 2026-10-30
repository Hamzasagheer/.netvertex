using Microsoft.EntityFrameworkCore;
using vertex.src.Models; 

namespace vertex.src.Data
{
    // 1. DbContext se inherit karta hai
    public class AppDbContext : DbContext
    {
        private  readonly IHttpContextAccessor _httpContextAccessor;
        // 2. Constructor: Jo database configuration ko ASP.NET se leta hai
        public AppDbContext(DbContextOptions<AppDbContext> options,IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // 3. Database Table: Database ke andar "Users" table banayega
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AttendanceModel> Attendance { get; set; }
        public DbSet<LeaveModel> Leaves { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
