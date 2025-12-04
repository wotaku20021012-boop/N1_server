using Microsoft.EntityFrameworkCore;
using System;

namespace personalbeauty.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuestionFlow> QuestionFlows { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<CosmeticTag> CosmeticTags { get; set; }
        public DbSet<FormSubmission> FormSubmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ç‡Çµç≈èâÇ©ÇÁÉVÅ[ÉhÇµÇΩÇØÇÍÇŒÇ±Ç±Ç… HasData Çí«â¡
        }
    }

    public class User { public int Id { get; set; } public string Name { get; set; } public string Email { get; set; } public string PasswordHash { get; set; } }
    public class Question { public int Id { get; set; } public string Text { get; set; } public bool IsTerminal { get; set; } }
    public class Option { public int Id { get; set; } public int QuestionId { get; set; } public string Text { get; set; } }
    public class QuestionFlow { public int Id { get; set; } public int QuestionId { get; set; } public int OptionId { get; set; } public int? NextQuestionId { get; set; } }
    public class Cosmetic { public int Id { get; set; } public string Name { get; set; } public string Brand { get; set; } public string Description { get; set; } public int? Price { get; set; } public string ImageUrl { get; set; } public DateTime CreatedAt { get; set; } }
    public class CosmeticTag { public int Id { get; set; } public int CosmeticId { get; set; } public string Tag { get; set; } }
    public class FormSubmission { public int Id { get; set; } public int? UserId { get; set; } public string FormJson { get; set; } public DateTime CreatedAt { get; set; } = DateTime.UtcNow; }
}
