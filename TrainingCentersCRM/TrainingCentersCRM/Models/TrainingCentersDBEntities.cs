namespace TrainingCentersCRM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrainingCentersDBEntities : DbContext
    {
        public TrainingCentersDBEntities()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CertificationProvider> CertificationProviders { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<CertificationTaking> CertificationTakings { get; set; }
        public virtual DbSet<CourseModule> CourseModules { get; set; }
        public virtual DbSet<CourseTaking> CourseTakings { get; set; }
        public virtual DbSet<HoldCours> HoldCourses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Listener> Listeners { get; set; }
        public virtual DbSet<QualificationCertification> QualificationCertifications { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<QualificationTrainingCour> QualificationTrainingCours { get; set; }
        public virtual DbSet<RelatedCours> RelatedCourses { get; set; }
        public virtual DbSet<ScheduleTtrainingCours> ScheduleTtrainingCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TrainingCenterCours> TrainingCenterCourses { get; set; }
        public virtual DbSet<TrainingCenter> TrainingCenters { get; set; }
        public virtual DbSet<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }
        public virtual DbSet<TrainingCours> TrainingCourses { get; set; }
        public virtual DbSet<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
        public virtual DbSet<TrainingGroup> TrainingGroups { get; set; }
        public virtual DbSet<TrainingModule> TrainingModules { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CertificationProvider>()
                .HasMany(e => e.Certifications)
                .WithOptional(e => e.CertificationProvider)
                .HasForeignKey(e => e.IdProvider);

            modelBuilder.Entity<Certification>()
                .HasMany(e => e.QualificationCertifications)
                .WithOptional(e => e.Certification)
                .HasForeignKey(e => e.IdCertification)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CourseTaking>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CourseTaking>()
                .Property(e => e.Debt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CourseTaking>()
                .Property(e => e.IdObecjt)
                .IsFixedLength();

            modelBuilder.Entity<CourseTaking>()
                .HasMany(e => e.Listeners)
                .WithOptional(e => e.CourseTaking)
                .HasForeignKey(e => e.IdCourseTakings)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.QualificationCertifications)
                .WithOptional(e => e.Qualification)
                .HasForeignKey(e => e.IdQualification)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.QualificationTrainingCours)
                .WithOptional(e => e.Qualification)
                .HasForeignKey(e => e.IdQualification)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.Vacancies);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TrainingCenterTeachers)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TrainingCourseTeachers)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCenter>()
                .HasMany(e => e.ScheduleTtrainingCourses)
                .WithOptional(e => e.TrainingCenter)
                .HasForeignKey(e => e.IdTrainingCenter)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCenter>()
                .HasMany(e => e.TrainingCenterCourses)
                .WithOptional(e => e.TrainingCenter)
                .HasForeignKey(e => e.IdTrainingCenter)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCenter>()
                .HasMany(e => e.TrainingCenterTeachers)
                .WithOptional(e => e.TrainingCenter)
                .HasForeignKey(e => e.IdTrainingCenter)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .Property(e => e.PriceForOrganizations)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TrainingCours>()
                .Property(e => e.PriceForIndividuals)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TrainingCours>()
                .Property(e => e.CostOfOneHourForOrganizations)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TrainingCours>()
                .Property(e => e.CostOfOneHourForIndividuals)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.CourseModules)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.HoldCourses)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.QualificationTrainingCours)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCours)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.RelatedCourses)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.RelatedCourses1)
                .WithOptional(e => e.TrainingCours1)
                .HasForeignKey(e => e.IdTrainingCourseRelated);

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.ScheduleTtrainingCourses)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.TrainingCenterCourses)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingCours>()
                .HasMany(e => e.TrainingCourseTeachers)
                .WithOptional(e => e.TrainingCours)
                .HasForeignKey(e => e.IdTrainingCourse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingGroup>()
                .HasMany(e => e.HoldCourses)
                .WithOptional(e => e.TrainingGroup)
                .HasForeignKey(e => e.IdTrainingGroup);

            modelBuilder.Entity<TrainingGroup>()
                .HasMany(e => e.Listeners)
                .WithOptional(e => e.TrainingGroup)
                .HasForeignKey(e => e.IdTrainingGroup)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TrainingModule>()
                .HasMany(e => e.CourseModules)
                .WithOptional(e => e.TrainingModule)
                .HasForeignKey(e => e.IdTrainingModule)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vacancy>()
                .Property(e => e.Wages)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Vacancy>()
                .HasMany(e => e.Qualifications);
            modelBuilder.Entity<Article>();

            modelBuilder.Entity<AspNetUser>()
                .HasKey(e => e.UserId);
                //.HasRequired(a => a.User)
                //.WithMany()
                //.HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);;
        }
    }
}
