﻿using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Api.Entities.Task;

namespace Api.Context;

public partial class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompletedWork> CompletedWorks { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Discipline> Disciplines { get; set; } = null!;

    public virtual DbSet<Group> Groups { get; set; } = null!;

    public virtual DbSet<GroupWork> GroupWorks { get; set; } = null!;

    public virtual DbSet<Mark> Marks { get; set; } = null!;

    public virtual DbSet<Semester> Semesters { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Task> Tasks { get; set; } = null!;

    public virtual DbSet<Teacher> Teachers { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<Work> Works { get; set; } = null!;

    public virtual DbSet<WorkMark> WorkMarks { get; set; } = null!;

    public virtual DbSet<WorkType> WorkTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompletedWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("completed_work_pkey");

            entity.ToTable("completed_work");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MarkId).HasColumnName("mark_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.Mark).WithMany(p => p.CompletedWorks)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("completed_work_fk_mark");

            entity.HasOne(d => d.Student).WithMany(p => p.CompletedWorks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("completed_work_fk_student");

            entity.HasOne(d => d.Work).WithMany(p => p.CompletedWorks)
                .HasForeignKey(d => d.WorkId)
                .HasConstraintName("completed_work_fk_work");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("course_pkey");

            entity.ToTable("course");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Courses_id_seq\"'::regclass)")
                .HasColumnName("id");

            entity.HasData(new() { Id = 1 }, new() { Id = 2 }, new() { Id = 3 }, new() { Id = 4 }, new() { Id = 5 });
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discipline_pkey");

            entity.ToTable("discipline");

            entity.HasIndex(e => e.Name, "discipline_unique_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Disciplines_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_pkey");

            entity.ToTable("group");

            entity.HasIndex(e => new { e.Name, e.Year }, "group_unique_name_year").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Groups_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.SemesterId).HasColumnName("semester_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Course).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("group_fk_course");

            entity.HasOne(d => d.Semester).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("group_fk_semester");

            entity.HasMany(d => d.Disciplines).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("DisciplineId")
                        .HasConstraintName("group_discipline_fk_discipline"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("group_discipline_fk_group"),
                    j =>
                    {
                        j.HasKey("GroupId", "DisciplineId").HasName("group_discipline_pkey");
                        j.ToTable("group_discipline");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                        j.IndexerProperty<int>("DisciplineId").HasColumnName("discipline_id");
                    });
        });

        modelBuilder.Entity<GroupWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_work_pkey");

            entity.ToTable("group_work");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.SemesterId).HasColumnName("semester_id");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.Course).WithMany(p => p.GroupWorks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("group_work_fk_course");

            entity.HasOne(d => d.Discipline).WithMany(p => p.GroupWorks)
                .HasForeignKey(d => d.DisciplineId)
                .HasConstraintName("group_work_fk_discipline");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupWorks)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("group_work_fk_group");

            entity.HasOne(d => d.Semester).WithMany(p => p.GroupWorks)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("group_work_fk_semester");

            entity.HasOne(d => d.Work).WithMany(p => p.GroupWorks)
                .HasForeignKey(d => d.WorkId)
                .HasConstraintName("group_work_fk_work");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mark_pkey");

            entity.ToTable("mark");

            entity.HasIndex(e => e.Value, "mark_unique_value").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Mark_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasData(new() { Id = 1, Value = 5 }, new() { Id = 2, Value = 4 }, new() { Id = 3, Value = 3 },
                new() { Id = 4, Value = 2 });
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("semester_pkey");

            entity.ToTable("semester");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Semesters_id_seq\"'::regclass)")
                .HasColumnName("id");

            entity.HasData(new() { Id = 1 }, new() { Id = 2 });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Students_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.IsRetired)
                .HasDefaultValue(false)
                .HasColumnName("is_retired");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("student_fk_group");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("student_fk_user");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .HasColumnName("title");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.Work).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.WorkId)
                .HasConstraintName("task_fk_work");

            entity.HasMany(d => d.CompletedWorks).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "CompletedWorkTask",
                    r => r.HasOne<CompletedWork>().WithMany()
                        .HasForeignKey("CompletedWorkId")
                        .HasConstraintName("completed_work_task_fk_completed_work"),
                    l => l.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .HasConstraintName("completed_work_task_fk_task"),
                    j =>
                    {
                        j.HasKey("TaskId", "CompletedWorkId").HasName("completed_work_task_pkey");
                        j.ToTable("completed_work_task");
                        j.IndexerProperty<int>("TaskId").HasColumnName("task_id");
                        j.IndexerProperty<int>("CompletedWorkId").HasColumnName("completed_work_id");
                    });
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Teachers_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("teacher_fk_user");

            entity.HasMany(d => d.Groups).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherGroup",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("teacher_group_fk_group"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("teacher_group_fk_teacher"),
                    j =>
                    {
                        j.HasKey("TeacherId", "GroupId").HasName("teacher_group_pkey");
                        j.ToTable("teacher_group");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("teacher_id");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Login, "user_unique_login").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Users_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_pkey");

            entity.ToTable("work");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .HasColumnName("name");
            entity.Property(e => e.WorkTypeId).HasColumnName("work_type_id");

            entity.HasOne(d => d.WorkType).WithMany(p => p.Works)
                .HasForeignKey(d => d.WorkTypeId)
                .HasConstraintName("work_fk_work_type");
        });

        modelBuilder.Entity<WorkMark>(entity =>
        {
            entity.HasKey(e => e.WorkId).HasName("work_mark_pkey");

            entity.ToTable("work_mark");

            entity.HasIndex(e => new { e.WorkId, e.TaskCount }, "work_mark_unique_work_id_task_count").IsUnique();

            entity.Property(e => e.WorkId)
                .ValueGeneratedNever()
                .HasColumnName("work_id");
            entity.Property(e => e.MarkId).HasColumnName("mark_id");
            entity.Property(e => e.TaskCount).HasColumnName("task_count");

            entity.HasOne(d => d.Mark).WithMany(p => p.WorkMarks)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("work_mark_fk_mark");

            entity.HasOne(d => d.Work).WithMany(p => p.WorkMarks)
                .HasForeignKey(d => d.WorkId)
                .HasConstraintName("work_mark_fk_work");
        });

        modelBuilder.Entity<WorkType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_type_pkey");

            entity.ToTable("work_type");

            entity.HasIndex(e => e.Name, "work_type_unique_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"WorkType_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}