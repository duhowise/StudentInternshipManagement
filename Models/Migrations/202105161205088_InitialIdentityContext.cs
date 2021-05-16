namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialIdentityContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        AdminName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Avatar = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyDescription = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyTrainingMajors",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        TrainingMajorId = c.Int(nullable: false),
                        TotalTraineeCount = c.Int(nullable: false),
                        AvailableTraineeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.TrainingMajorId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.TrainingMajors", t => t.TrainingMajorId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.TrainingMajorId);
            
            CreateTable(
                "dbo.TrainingMajors",
                c => new
                    {
                        TrainingMajorId = c.Int(nullable: false, identity: true),
                        TrainingMajorName = c.String(nullable: false, maxLength: 50),
                        SubjectId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainingMajorId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        TrainingMajorId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        LeaderId = c.String(maxLength: 128),
                        TeacherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.LearningClasses", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.LeaderId)
                .ForeignKey("dbo.CompanyTrainingMajors", t => new { t.CompanyId, t.TrainingMajorId }, cascadeDelete: true)
                .Index(t => new { t.CompanyId, t.TrainingMajorId })
                .Index(t => t.ClassId)
                .Index(t => t.LeaderId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.LearningClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        SubjectId = c.String(maxLength: 128),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.LearningClassStudents",
                c => new
                    {
                        ClassId = c.Int(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        MidTermPoint = c.Single(),
                        EndTermPoint = c.Single(),
                        TotalPoint = c.Single(),
                    })
                .PrimaryKey(t => new { t.ClassId, t.StudentId })
                .ForeignKey("dbo.LearningClasses", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Avatar = c.String(nullable: false, maxLength: 50),
                        Cpa = c.Single(nullable: false),
                        Program = c.String(nullable: false, maxLength: 50),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.StudentClasses", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        File = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        Time = c.DateTime(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        TeacherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        TeacherName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Avatar = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Internships",
                c => new
                    {
                        InternshipId = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        ClassId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        TrainingMajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InternshipId)
                .ForeignKey("dbo.LearningClasses", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyTrainingMajors", t => new { t.CompanyId, t.TrainingMajorId }, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => new { t.CompanyId, t.TrainingMajorId });
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 100),
                        Url = c.String(nullable: false, maxLength: 50),
                        Time = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.StatisticId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        Student_StudentId = c.String(nullable: false, maxLength: 128),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Group_GroupId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Internships", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Internships", new[] { "CompanyId", "TrainingMajorId" }, "dbo.CompanyTrainingMajors");
            DropForeignKey("dbo.Internships", "ClassId", "dbo.LearningClasses");
            DropForeignKey("dbo.Groups", new[] { "CompanyId", "TrainingMajorId" }, "dbo.CompanyTrainingMajors");
            DropForeignKey("dbo.Groups", "LeaderId", "dbo.Students");
            DropForeignKey("dbo.Groups", "ClassId", "dbo.LearningClasses");
            DropForeignKey("dbo.LearningClasses", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.LearningClasses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Messages", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Groups", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Messages", "StudentId", "dbo.Students");
            DropForeignKey("dbo.LearningClassStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.StudentGroups", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.StudentClasses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.LearningClassStudents", "ClassId", "dbo.LearningClasses");
            DropForeignKey("dbo.TrainingMajors", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CompanyTrainingMajors", "TrainingMajorId", "dbo.TrainingMajors");
            DropForeignKey("dbo.CompanyTrainingMajors", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Admins", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.StudentGroups", new[] { "Student_StudentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Internships", new[] { "CompanyId", "TrainingMajorId" });
            DropIndex("dbo.Internships", new[] { "ClassId" });
            DropIndex("dbo.Internships", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Messages", new[] { "TeacherId" });
            DropIndex("dbo.Messages", new[] { "StudentId" });
            DropIndex("dbo.StudentClasses", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.LearningClassStudents", new[] { "StudentId" });
            DropIndex("dbo.LearningClassStudents", new[] { "ClassId" });
            DropIndex("dbo.LearningClasses", new[] { "SemesterId" });
            DropIndex("dbo.LearningClasses", new[] { "SubjectId" });
            DropIndex("dbo.Groups", new[] { "TeacherId" });
            DropIndex("dbo.Groups", new[] { "LeaderId" });
            DropIndex("dbo.Groups", new[] { "ClassId" });
            DropIndex("dbo.Groups", new[] { "CompanyId", "TrainingMajorId" });
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.TrainingMajors", new[] { "SubjectId" });
            DropIndex("dbo.CompanyTrainingMajors", new[] { "TrainingMajorId" });
            DropIndex("dbo.CompanyTrainingMajors", new[] { "CompanyId" });
            DropIndex("dbo.Admins", new[] { "DepartmentId" });
            DropTable("dbo.StudentGroups");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Statistics");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.News");
            DropTable("dbo.Internships");
            DropTable("dbo.Semesters");
            DropTable("dbo.Teachers");
            DropTable("dbo.Messages");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Students");
            DropTable("dbo.LearningClassStudents");
            DropTable("dbo.LearningClasses");
            DropTable("dbo.Groups");
            DropTable("dbo.Subjects");
            DropTable("dbo.TrainingMajors");
            DropTable("dbo.CompanyTrainingMajors");
            DropTable("dbo.Companies");
            DropTable("dbo.Departments");
            DropTable("dbo.Admins");
        }
    }
}
