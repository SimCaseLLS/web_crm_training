﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingCentersCRM.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrainingCentersDBEntities : DbContext
    {
        public TrainingCentersDBEntities()
            : base("name=TrainingCentersDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
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
        public virtual DbSet<QualificationVacancy> QualificationVacancies { get; set; }
        public virtual DbSet<RelatedCours> RelatedCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TrainingCenterCours> TrainingCenterCourses { get; set; }
        public virtual DbSet<TrainingCenter> TrainingCenters { get; set; }
        public virtual DbSet<TrainingCenterTeacher> TrainingCenterTeachers { get; set; }
        public virtual DbSet<TrainingCours> TrainingCourses { get; set; }
        public virtual DbSet<TrainingCourseTeacher> TrainingCourseTeachers { get; set; }
        public virtual DbSet<TrainingGroup> TrainingGroups { get; set; }
        public virtual DbSet<TrainingModule> TrainingModules { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
<<<<<<< HEAD
        public virtual DbSet<ScheduleTtrainingCours> ScheduleTtrainingCourses { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
=======
>>>>>>> #wcrm-10 complete task
    }
}
