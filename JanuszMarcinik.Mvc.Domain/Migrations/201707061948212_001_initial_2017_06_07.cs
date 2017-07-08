namespace JanuszMarcinik.Mvc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001_initial_2017_06_07 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Questionnaire.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("Questionnaire.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "Questionnaire.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        Text = c.String(),
                        QuestionnaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("Questionnaire.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId);
            
            CreateTable(
                "Questionnaire.Questionnaires",
                c => new
                    {
                        QuestionnaireId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        EditDisable = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestionnaireId);
            
            CreateTable(
                "Questionnaire.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        IntervieweeId = c.Int(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("Questionnaire.Interviewees", t => t.IntervieweeId, cascadeDelete: true)
                .ForeignKey("Questionnaire.Questionnaires", t => t.QuestionnaireId)
                .ForeignKey("Questionnaire.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("Questionnaire.Answers", t => t.AnswerId)
                .Index(t => t.IntervieweeId)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "Questionnaire.Interviewees",
                c => new
                    {
                        IntervieweeId = c.Int(nullable: false, identity: true),
                        InterviewDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        SexId = c.Int(nullable: false),
                        SeniorityId = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                        PlaceOfResidenceId = c.Int(nullable: false),
                        MartialStatusId = c.Int(nullable: false),
                        MaterialStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntervieweeId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.EducationId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.MartialStatusId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.MaterialStatusId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.PlaceOfResidenceId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.SeniorityId)
                .ForeignKey("Dictionaries.BaseDictionaries", t => t.SexId)
                .Index(t => t.SexId)
                .Index(t => t.SeniorityId)
                .Index(t => t.EducationId)
                .Index(t => t.PlaceOfResidenceId)
                .Index(t => t.MartialStatusId)
                .Index(t => t.MaterialStatusId);
            
            CreateTable(
                "Dictionaries.BaseDictionaries",
                c => new
                    {
                        BaseDictionaryId = c.Int(nullable: false, identity: true),
                        DictionaryType = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.BaseDictionaryId);
            
            CreateTable(
                "Identity.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Identity.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Identity.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.UserRoles", "UserId", "Identity.Users");
            DropForeignKey("Identity.UserLogins", "UserId", "Identity.Users");
            DropForeignKey("Identity.UserClaims", "UserId", "Identity.Users");
            DropForeignKey("Identity.UserRoles", "RoleId", "Identity.Roles");
            DropForeignKey("Questionnaire.Results", "AnswerId", "Questionnaire.Answers");
            DropForeignKey("Questionnaire.Results", "QuestionId", "Questionnaire.Questions");
            DropForeignKey("Questionnaire.Results", "QuestionnaireId", "Questionnaire.Questionnaires");
            DropForeignKey("Questionnaire.Results", "IntervieweeId", "Questionnaire.Interviewees");
            DropForeignKey("Questionnaire.Interviewees", "SexId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "SeniorityId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "PlaceOfResidenceId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "MaterialStatusId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "MartialStatusId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "EducationId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Questions", "QuestionnaireId", "Questionnaire.Questionnaires");
            DropForeignKey("Questionnaire.Answers", "QuestionId", "Questionnaire.Questions");
            DropIndex("Identity.UserLogins", new[] { "UserId" });
            DropIndex("Identity.UserClaims", new[] { "UserId" });
            DropIndex("Identity.UserRoles", new[] { "RoleId" });
            DropIndex("Identity.UserRoles", new[] { "UserId" });
            DropIndex("Questionnaire.Interviewees", new[] { "MaterialStatusId" });
            DropIndex("Questionnaire.Interviewees", new[] { "MartialStatusId" });
            DropIndex("Questionnaire.Interviewees", new[] { "PlaceOfResidenceId" });
            DropIndex("Questionnaire.Interviewees", new[] { "EducationId" });
            DropIndex("Questionnaire.Interviewees", new[] { "SeniorityId" });
            DropIndex("Questionnaire.Interviewees", new[] { "SexId" });
            DropIndex("Questionnaire.Results", new[] { "AnswerId" });
            DropIndex("Questionnaire.Results", new[] { "QuestionId" });
            DropIndex("Questionnaire.Results", new[] { "QuestionnaireId" });
            DropIndex("Questionnaire.Results", new[] { "IntervieweeId" });
            DropIndex("Questionnaire.Questions", new[] { "QuestionnaireId" });
            DropIndex("Questionnaire.Answers", new[] { "QuestionId" });
            DropTable("Identity.UserLogins");
            DropTable("Identity.UserClaims");
            DropTable("Identity.Users");
            DropTable("Identity.UserRoles");
            DropTable("Identity.Roles");
            DropTable("Dictionaries.BaseDictionaries");
            DropTable("Questionnaire.Interviewees");
            DropTable("Questionnaire.Results");
            DropTable("Questionnaire.Questionnaires");
            DropTable("Questionnaire.Questions");
            DropTable("Questionnaire.Answers");
        }
    }
}
