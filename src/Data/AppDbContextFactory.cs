using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace vertex.src.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        var connectionString = "Server=srv2078.hstgr.io; Port=3306; Database=u525423178_vertex_001; Uid=u525423178_vertex_001; Pwd=Vertex@001; AllowZeroDateTime=True; ConvertZeroDateTime=True;";
        
        // Use a hardcoded version (e.g., MySQL 8.0) instead of AutoDetect to avoid connection checks
        optionsBuilder.UseMySql(
            connectionString, 
            new MySqlServerVersion(new Version(8, 0, 30)) // Adjust version number (e.g., 5.7 or 8.0) if needed
        );

        return new AppDbContext(optionsBuilder.Options, null!);
    }
}