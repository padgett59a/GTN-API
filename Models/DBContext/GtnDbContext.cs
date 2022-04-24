using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GTN_API.Models
{
    public partial class GtnDbContext : DbContext
    {
        public GtnDbContext()
        {
        }

        public GtnDbContext(DbContextOptions<GtnDbContext> options)
            : base(options)
        {
            //Turn off lazy loading
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCore> CourseCores { get; set; }
        public virtual DbSet<Curriculum> Curriculums { get; set; }
        public virtual DbSet<CustomPaySet> CustomPaySets { get; set; }
        public virtual DbSet<DistrSemesterCourse> DistrSemesterCourses { get; set; }
        public virtual DbSet<ExamTranslationLog> ExamTranslationLogs { get; set; }
        public virtual DbSet<ExamTranslationStep> ExamTranslationSteps { get; set; }
        public virtual DbSet<GenericStep> GenericSteps { get; set; }
        public virtual DbSet<LangCoursesTemp> LangCoursesTemps { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MasteringCustomPay> MasteringCustomPays { get; set; }
        public virtual DbSet<MasteringLog> MasteringLogs { get; set; }
        public virtual DbSet<MasteringStep> MasteringSteps { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguages { get; set; }
        public virtual DbSet<PersonPayRate> PersonPayRates { get; set; }
        public virtual DbSet<PersonPayment> PersonPayments { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterCore> SemesterCores { get; set; }
        public virtual DbSet<SemesterExam> SemesterExams { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionCore> SessionCores { get; set; }
        public virtual DbSet<SessionDist> SessionDists { get; set; }
        public virtual DbSet<SessionDistSet> SessionDistSets { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TranslationCustomPay> TranslationCustomPays { get; set; }
        public virtual DbSet<TranslationLog> TranslationLog { get; set; }
        public virtual DbSet<MasteringLog> MasteringLog { get; set; }
        public virtual DbSet<TranslationStep> TranslationSteps { get; set; }
        public virtual DbSet<DistrSemesterCourse> DistrSemesterCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleID, "IX_AspNetRoleClaims_RoleID");

                entity.Property(e => e.RoleID).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleID);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserID, "IX_AspNetUserClaims_UserID");

                entity.Property(e => e.UserID).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserID, "IX_AspNetUserLogins_UserID");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserID).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.RoleID });

                entity.HasIndex(e => e.RoleID, "IX_AspNetUserRoles_RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleID);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.courseCoreID, "idx_Courses_courseCoreID");

                entity.HasIndex(e => e.langID, "ncCourses_langID");

                entity.Property(e => e.courseID).HasColumnName("courseID");

                entity.Property(e => e.courseCoreID).HasColumnName("courseCoreID");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.HasOne(d => d.CourseCore)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.courseCoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__courseC__1A9EF37A");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__langID__1B9317B3");
            });

            modelBuilder.Entity<CourseCore>(entity =>
            {
                entity.HasIndex(e => e.SemesterCode, "ncCourseCores_SemesterCode");

                entity.Property(e => e.courseCoreID).HasColumnName("courseCoreID");

                entity.Property(e => e.CourseLetterCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.instructorID).HasColumnName("instructorID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.SemesterCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("semesterCode");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.CourseCores)
                    .HasForeignKey(d => d.instructorID)
                    .HasConstraintName("FK__coursesCo__instr__6CD828CA");

                entity.HasOne(d => d.SemesterCodeNavigation)
                    .WithMany(p => p.CourseCores)
                    .HasForeignKey(d => d.SemesterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__coursesCo__semes__6DCC4D03");
            });

            modelBuilder.Entity<Curriculum>(entity =>
            {
                entity.Property(e => e.curriculumID).HasColumnName("curriculumID");

                entity.Property(e => e.CurriculumName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomPaySet>(entity =>
            {
                entity.ToTable("CustomPaySet");

                entity.Property(e => e.customPaySetID).HasColumnName("customPaySetID");

                entity.Property(e => e.PaySetMonthYear)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PaySetType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistrSemesterCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DistrSemesterCourse");

                entity.Property(e => e.courseID).HasColumnName("courseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.LangName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamTranslationLog>(entity =>
            {
                entity.HasKey(e => e.examtlID);

                entity.ToTable("ExamTranslationLog");

                entity.Property(e => e.examtlID).HasColumnName("examtlID");

                entity.Property(e => e.DatePaid).HasColumnType("datetime");

                entity.Property(e => e.examtsID).HasColumnName("examtsID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.semexamID).HasColumnName("semexamID");

                entity.Property(e => e.statusID).HasColumnName("statusID");

                entity.Property(e => e.translatorID).HasColumnName("translatorID");

                entity.HasOne(d => d.Examts)
                    .WithMany(p => p.ExamTranslationLogs)
                    .HasForeignKey(d => d.examtsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExamTrans__exam-__1332DBDC");

                entity.HasOne(d => d.Semexam)
                    .WithMany(p => p.ExamTranslationLogs)
                    .HasForeignKey(d => d.semexamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExamTrans__semex__14270015");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExamTranslationLogs)
                    .HasForeignKey(d => d.statusID)
                    .HasConstraintName("FK__ExamTrans__statu__19DFD96B");

                entity.HasOne(d => d.Translator)
                    .WithMany(p => p.ExamTranslationLogs)
                    .HasForeignKey(d => d.translatorID)
                    .HasConstraintName("FK__ExamTrans__perso__151B244E");
            });

            modelBuilder.Entity<ExamTranslationStep>(entity =>
            {
                entity.HasKey(e => e.examtsID);

                entity.Property(e => e.examtsID).HasColumnName("examtsID");

                entity.Property(e => e.DefaultPayDollars).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Step)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GenericStep>(entity =>
            {
                entity.HasKey(e => e.gsID);

                entity.Property(e => e.gsID).HasColumnName("gsID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Step)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LangCoursesTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LangCoursesTemp");

                entity.Property(e => e.courseCoreID).HasColumnName("courseCoreID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.LangName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.lcID)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("lcID");

                entity.Property(e => e.SemesterCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.langID);

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.LangName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.locID);

                entity.Property(e => e.locID).HasColumnName("locID");

                entity.Property(e => e.City)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LocName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasteringCustomPay>(entity =>
            {
                entity.HasKey(e => e.mpID)
                    .HasName("PK_MasteringPay");

                entity.ToTable("MasteringCustomPay");

                entity.Property(e => e.mpID).HasColumnName("mpId");

                entity.Property(e => e.CustomPayDollars).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.customPaySetID).HasColumnName("customPaySetID");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.msID).HasColumnName("msId");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.CustomPaySet)
                    .WithMany(p => p.MasteringCustomPays)
                    .HasForeignKey(d => d.customPaySetID)
                    .HasConstraintName("FK__Mastering__custo__6225902D");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.MasteringCustomPays)
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mastering__langI__0D44F85C");

                entity.HasOne(d => d.Ms)
                    .WithMany(p => p.MasteringCustomPays)
                    .HasForeignKey(d => d.msID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MasteringP__msId__0C50D423");
            });

            modelBuilder.Entity<MasteringLog>(entity =>
            {
                entity.HasKey(e => e.mlID);

                entity.ToTable("MasteringLog");

                entity.HasIndex(e => e.statusID, "idx_mrxLog_statusid");

                entity.HasIndex(e => e.sessionID, "idx_mrxlog_sessionid");

                entity.Property(e => e.mlID).HasColumnName("mlID");

                entity.Property(e => e.DatePaid).HasColumnType("datetime");

                entity.Property(e => e.mastererID).HasColumnName("mastererID");

                entity.Property(e => e.msID).HasColumnName("msID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.sessionID).HasColumnName("sessionID");

                entity.Property(e => e.statusID).HasColumnName("statusID");

                entity.Property(e => e.StepPaymentAmount).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Masterer)
                    .WithMany(p => p.MasteringLogs)
                    .HasForeignKey(d => d.mastererID)
                    .HasConstraintName("FK__Mastering__maste__6754599E");

                entity.HasOne(d => d.Ms)
                    .WithMany(p => p.MasteringLogs)
                    .HasForeignKey(d => d.msID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MasteringL__msID__3B0BC30C");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.MasteringLogs)
                    .HasForeignKey(d => d.sessionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mastering__sessi__44952D46");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MasteringLogs)
                    .HasForeignKey(d => d.statusID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mastering__statu__693CA210");
            });

            modelBuilder.Entity<MasteringStep>(entity =>
            {
                entity.HasKey(e => e.msID);

                entity.Property(e => e.msID).HasColumnName("msID");

                entity.Property(e => e.DefaultPayDollars).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Step)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.mediaTypeID).HasColumnName("mediaTypeID");

                entity.Property(e => e.MediaTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.orgID);

                entity.Property(e => e.orgID).HasColumnName("orgID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.OrgLocation)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.OrgName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.personID).HasColumnName("personID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.locID).HasColumnName("locID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.orgID).HasColumnName("orgID");

                entity.Property(e => e.personTypeID).HasColumnName("personTypeID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.locID)
                    .HasConstraintName("FK__Persons__locID__6BAEFA67");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.orgID)
                    .HasConstraintName("FK__Persons__orgID__7F2BE32F");

                entity.HasOne(d => d.PersonType)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.personTypeID)
                    .HasConstraintName("FK__Persons__PersonT__00200768");
            });

            modelBuilder.Entity<PersonLanguage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonLanguage");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.personID).HasColumnName("personID");

                entity.HasOne(d => d.Lang)
                    .WithMany()
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translato__langI__45BE5BA9");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.personID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translato__perso__44CA3770");
            });

            modelBuilder.Entity<PersonPayRate>(entity =>
            {
                entity.Property(e => e.personPayRateID).HasColumnName("personPayRateID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.personID).HasColumnName("personID");

                entity.Property(e => e.stepID).HasColumnName("stepID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPayRates)
                    .HasForeignKey(d => d.personID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonPay__perso__02FC7413");
            });

            modelBuilder.Entity<PersonPayment>(entity =>
            {
                entity.HasKey(e => e.personpaytID)
                    .HasName("PK_PersonPaymentTranslation");

                entity.Property(e => e.personpaytID).HasColumnName("personpaytID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.personID).HasColumnName("personID");

                entity.Property(e => e.stepID).HasColumnName("stepID");
            });

            modelBuilder.Entity<PersonType>(entity =>
            {
                entity.Property(e => e.personTypeID).HasColumnName("personTypeID");

                entity.Property(e => e.PersonTypeName)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.semesterID).HasColumnName("semesterID");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.SemesterCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Semesters__langI__72910220");

                entity.HasOne(d => d.SemesterCodeNavigation)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.SemesterCode)
                    .HasConstraintName("FK__Semesters__Semes__719CDDE7");
            });

            modelBuilder.Entity<SemesterCore>(entity =>
            {
                entity.HasKey(e => e.SemesterCode);

                entity.Property(e => e.SemesterCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.curriculumID).HasColumnName("curriculumID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Curriculum)
                    .WithMany(p => p.SemesterCores)
                    .HasForeignKey(d => d.curriculumID)
                    .HasConstraintName("FK__SemesterC__curri__489AC854");
            });

            modelBuilder.Entity<SemesterExam>(entity =>
            {
                entity.HasKey(e => e.semexamID);

                entity.Property(e => e.semexamID).HasColumnName("semexamID");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.SemesterCode)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.semesterID).HasColumnName("semesterID");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterExams)
                    .HasForeignKey(d => d.semesterID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SemesterE__semes__2EA5EC27");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasIndex(e => e.langID, "idx_Sessions_langID");

                entity.HasIndex(e => e.sessionCoreID, "idx_sessioncoress_sessionCoreID");

                entity.HasIndex(e => e.sessionCoreID, "idx_sessions_sessionCoreID");

                entity.Property(e => e.sessionID).HasColumnName("sessionID");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.sessionCoreID).HasColumnName("sessionCoreID");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sessions__langID__1E6F845E");

                entity.HasOne(d => d.SessionCore)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.sessionCoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sessions__sessio__1D7B6025");
            });

            modelBuilder.Entity<SessionCore>(entity =>
            {
                entity.HasIndex(e => e.courseCoreID, "idx_SessionCores_courseCoreID");

                entity.Property(e => e.sessionCoreID).HasColumnName("sessionCoreID");

                entity.Property(e => e.courseCoreID).HasColumnName("courseCoreID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.SessionCode).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.SessionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CourseCore)
                    .WithMany(p => p.SessionCores)
                    .HasForeignKey(d => d.courseCoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sessions__Course__6EC0713C");
            });

            modelBuilder.Entity<SessionDist>(entity =>
            {
                entity.ToTable("SessionDist");

                entity.Property(e => e.sessionDistID)
                    .ValueGeneratedNever()
                    .HasColumnName("sessionDistID");

                entity.Property(e => e.ArchiveFormat)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DistDate).HasColumnType("datetime");

                entity.Property(e => e.locID).HasColumnName("locID");

                entity.Property(e => e.medTypeID).HasColumnName("medTypeID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.personID).HasColumnName("personID");

                entity.Property(e => e.sessionID).HasColumnName("sessionID");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.SessionDists)
                    .HasForeignKey(d => d.locID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SessionDi__locID__5C6CB6D7");

                entity.HasOne(d => d.MedType)
                    .WithMany(p => p.SessionDists)
                    .HasForeignKey(d => d.medTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SessionDi__medTy__5D60DB10");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.SessionDists)
                    .HasForeignKey(d => d.personID)
                    .HasConstraintName("FK__SessionDi__perso__5E54FF49");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionDists)
                    .HasForeignKey(d => d.sessionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SessionDi__sessi__5B78929E");
            });

            modelBuilder.Entity<SessionDistSet>(entity =>
            {
                entity.HasKey(e => e.sessionDistID);

                entity.ToTable("SessionDistSet");

                entity.Property(e => e.sessionDistID).HasColumnName("sessionDistID");

                entity.Property(e => e.DistMonthYear)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("distMonthYear");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.statusID).HasColumnName("statusID");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TranslationCustomPay>(entity =>
            {
                entity.HasKey(e => e.tpID)
                    .HasName("PK_TranslationPay");

                entity.ToTable("TranslationCustomPay");

                entity.Property(e => e.tpID).HasColumnName("tpId");

                entity.Property(e => e.CustomPayDollars).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.customPaySetID).HasColumnName("customPaySetID");

                entity.Property(e => e.langID).HasColumnName("langID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.tsID).HasColumnName("tsId");

                entity.HasOne(d => d.CustomPaySet)
                    .WithMany(p => p.TranslationCustomPays)
                    .HasForeignKey(d => d.customPaySetID)
                    .HasConstraintName("FK__Translati__custo__6319B466");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.TranslationCustomPays)
                    .HasForeignKey(d => d.langID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translati__langI__09746778");

                entity.HasOne(d => d.Ts)
                    .WithMany(p => p.TranslationCustomPays)
                    .HasForeignKey(d => d.tsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translatio__tsId__0880433F");
            });

            modelBuilder.Entity<TranslationLog>(entity =>
            {
                entity.HasKey(e => e.tlID);

                entity.ToTable("TranslationLog");

                entity.HasIndex(e => e.statusID, "idx_trxLog_statusid");

                entity.HasIndex(e => e.sessionID, "idx_trxlog_sessionid");

                entity.Property(e => e.tlID).HasColumnName("tlID");

                entity.Property(e => e.DatePaid).HasColumnType("datetime");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.sessionID).HasColumnName("sessionID");

                entity.Property(e => e.statusID).HasColumnName("statusID");

                entity.Property(e => e.StepPaymentAmount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.translatorID).HasColumnName("translatorID");

                entity.Property(e => e.tsID).HasColumnName("tsID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.TranslationLogs)
                    .HasForeignKey(d => d.sessionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translati__sessi__4589517F");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TranslationLogs)
                    .HasForeignKey(d => d.statusID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translati__statu__6383C8BA");

                entity.HasOne(d => d.Translator)
                    .WithMany(p => p.TranslationLogs)
                    .HasForeignKey(d => d.translatorID)
                    .HasConstraintName("FK__Translati__trans__1AD3FDA4");

                entity.HasOne(d => d.Ts)
                    .WithMany(p => p.TranslationLogs)
                    .HasForeignKey(d => d.tsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Translatio__tsID__60A75C0F");
            });

            modelBuilder.Entity<TranslationStep>(entity =>
            {
                entity.HasKey(e => e.tsID);

                entity.Property(e => e.tsID).HasColumnName("tsID");

                entity.Property(e => e.DefaultPayDollars).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Step)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
