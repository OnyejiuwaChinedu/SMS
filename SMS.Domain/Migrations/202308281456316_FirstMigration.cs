namespace SMS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(),
                        Course_Description = c.String(),
                        School_Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time_Start = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Course_Id_Id = c.Int(),
                        Staff_Id_Id = c.Int(),
                        Student_Id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id_Id)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id_Id)
                .Index(t => t.Course_Id_Id)
                .Index(t => t.Staff_Id_Id)
                .Index(t => t.Student_Id_Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        FirstName = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_Id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id_Id)
                .Index(t => t.Course_Id_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Transaction_Name = c.String(),
                        Transaction_Date = c.DateTime(nullable: false),
                        Student_Id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id_Id)
                .Index(t => t.Student_Id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Student_Id_Id", "dbo.Students");
            DropForeignKey("dbo.Subjects", "Course_Id_Id", "dbo.Courses");
            DropForeignKey("dbo.Schedules", "Student_Id_Id", "dbo.Students");
            DropForeignKey("dbo.Schedules", "Staff_Id_Id", "dbo.Staffs");
            DropForeignKey("dbo.Schedules", "Course_Id_Id", "dbo.Courses");
            DropIndex("dbo.Transactions", new[] { "Student_Id_Id" });
            DropIndex("dbo.Subjects", new[] { "Course_Id_Id" });
            DropIndex("dbo.Schedules", new[] { "Student_Id_Id" });
            DropIndex("dbo.Schedules", new[] { "Staff_Id_Id" });
            DropIndex("dbo.Schedules", new[] { "Course_Id_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Staffs");
            DropTable("dbo.Schedules");
            DropTable("dbo.Courses");
        }
    }
}
