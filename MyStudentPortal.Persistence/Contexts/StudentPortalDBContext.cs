﻿using Microsoft.EntityFrameworkCore;
using MyStudentPortal.Domain.Entities;
using System.Reflection;

namespace MyStudentPortal.Persistence.Contexts
{
    public class StudentPortalDBContext : DbContext
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentPortalDBContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public StudentPortalDBContext(DbContextOptions<StudentPortalDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        /// <summary>
        /// Gets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets the enrollments.
        /// </summary>
        /// <value>
        /// The enrollments.
        /// </value>
        public DbSet<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public DbSet<Student> Students { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the database.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
        /// to discover any changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </para>
        /// <para>
        /// Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
        /// includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
        /// Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
        /// in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information
        /// and examples.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
        /// </para>
        /// </remarks>
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
        /// to discover any changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </para>
        /// <para>
        /// Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
        /// includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
        /// Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
        /// in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more
        /// information and examples.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
        /// </para>
        /// </remarks>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=studentportal.db");
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(nameof(ApplicationUser));
                entity.HasKey(entity => entity.Id);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable(nameof(Course));
                entity.HasKey(entity => entity.Id);

                entity.HasData(
                     new Course { Name = "Bookkeeping & Accounting Studies" },
                     new Course { Name = "Business Studies" },
                     new Course { Name = "Child Care Studies" },
                     new Course { Name = "CIMA: Management Accounting Studies" },
                     new Course { Name = "CompTIA Studies" },
                     new Course { Name = "Computer Studies" },
                     new Course { Name = "Creative Studies" },
                     new Course { Name = "Decor & Design Studies" },
                     new Course { Name = "Event Management Studies" });
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable(nameof(Enrollment));
                entity.HasKey(entity => entity.Id);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable(nameof(Student));
                entity.HasKey(entity => entity.Id);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
        }

        #endregion Protected Methods
    }
}