using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Rent_A_Car
{
    public partial class RentACarContext : DbContext
    {
        public RentACarContext()
        {
        }

        public RentACarContext(DbContextOptions<RentACarContext> options): base(options)
        {
        }

        public virtual DbSet<BookedCar> BookedCars { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress02;Database=RentACar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BookedCar>(entity =>
            {
                entity.HasKey(e => e.BookCarId)
                    .HasName("PK_book_car_id");

                entity.ToTable("Booked_cars");

                entity.Property(e => e.BookCarId).HasColumnName("book_car_id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.EndDay)
                    .HasColumnType("date")
                    .HasColumnName("end_day");

                entity.Property(e => e.StartDay)
                    .HasColumnType("date")
                    .HasColumnName("start_day");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.BookedCars)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booked_cars_cars");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookedCars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cars_users");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.Brand).HasColumnName("brand");
                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.CarYear).HasColumnName("car_year");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.PricaPerDay).HasColumnType("decimal(2, 0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61647B9AE8EA")
                    .IsUnique();

                entity.HasIndex(e => e.Egn, "UQ__Users__C190274629C20443")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5724EE3AA55")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Egn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EGN");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_first_name");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_last_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
