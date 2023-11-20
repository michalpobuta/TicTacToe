using Microsoft.EntityFrameworkCore;
using TicTacToe.Database.Model;

namespace TicTacToe.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IPath _path;

        public AppDbContext(IPath path, DbContextOptions<AppDbContext> options)
        : base(options)
        {
            if (!File.Exists(path.GetDatabasePath()))
                Directory.CreateDirectory(path.GetDatabaseFolder());

            _path = path;
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<GameMove> GameMoves { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={_path.GetDatabasePath()}");
        }

    }
}
