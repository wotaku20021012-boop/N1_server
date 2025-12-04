using Microsoft.EntityFrameworkCore;

namespace personalbeauty.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 実際のモデルに合わせて追加
        public DbSet<Question> Questions { get; set; }
        public DbSet<OptionItem> Options { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<ChatLog> ChatLogs { get; set; }
    }
}
