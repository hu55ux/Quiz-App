using Microsoft.EntityFrameworkCore;
using QuizGame.Entities;


public class QuizGameDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Result> Results { get; set; }

    public QuizGameDBContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=QuizGame;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //-----------------------   User    -------------------------------//
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                  .ValueGeneratedOnAdd(); 
           
            entity.Property(u => u.Username)
                  .IsRequired()
                  .HasMaxLength(50);
            entity.Property(u => u.Password)
                  .IsRequired()
                  .HasMaxLength(100);
        });

        //-----------------------   Quiz    -------------------------------//
        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(q => q.Id);
           
            entity.Property(q => q.Id)
                  .ValueGeneratedOnAdd();


            entity.Property(q => q.Title)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(q => q.Category)
                  .IsRequired();

            entity.HasMany(q => q.Questions)
                  .WithOne(q => q.Quiz)
                  .HasForeignKey(qn => qn.QuizId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //-----------------------   Question    -------------------------------//
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(qn => qn.Id);

            entity.Property(qn => qn.Id)
             .ValueGeneratedOnAdd();

            entity.Property(qn => qn.Text)
                  .IsRequired();

            entity.Property(qn => qn.isMultipleChoice)
                  .IsRequired();

            entity.HasMany(qn => qn.Answers)
                  .WithOne(a => a.Question)
                  .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //-----------------------   Answer    -------------------------------//
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(a => a.Text)
                  .IsRequired();

            entity.Property(a => a.IsCorrect)
                  .IsRequired();
        });

        //-----------------------   Result    -------------------------------//
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Id)
                  .ValueGeneratedOnAdd();

            entity.HasOne(r => r.User)
                  .WithMany()
                  .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Quiz)
                  .WithMany()
                  .HasForeignKey(r => r.QuizId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(r => r.Score)
                  .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }

}

