namespace JanuszMarcinik.Mvc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteQuestionnaireAddTurtleBarrel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Questionnaire.Answers", "QuestionId", "Questionnaire.Questions");
            DropForeignKey("Questionnaire.Questions", "QuestionnaireId", "Questionnaire.Questionnaires");
            DropForeignKey("Questionnaire.Interviewees", "EducationId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "MartialStatusId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "MaterialStatusId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "PlaceOfResidenceId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "SeniorityId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Interviewees", "SexId", "Dictionaries.BaseDictionaries");
            DropForeignKey("Questionnaire.Results", "IntervieweeId", "Questionnaire.Interviewees");
            DropForeignKey("Questionnaire.Results", "QuestionnaireId", "Questionnaire.Questionnaires");
            DropForeignKey("Questionnaire.Results", "QuestionId", "Questionnaire.Questions");
            DropForeignKey("Questionnaire.Results", "AnswerId", "Questionnaire.Answers");
            DropIndex("Questionnaire.Answers", new[] { "QuestionId" });
            DropIndex("Questionnaire.Questions", new[] { "QuestionnaireId" });
            DropIndex("Questionnaire.Results", new[] { "IntervieweeId" });
            DropIndex("Questionnaire.Results", new[] { "QuestionnaireId" });
            DropIndex("Questionnaire.Results", new[] { "QuestionId" });
            DropIndex("Questionnaire.Results", new[] { "AnswerId" });
            DropIndex("Questionnaire.Interviewees", new[] { "SexId" });
            DropIndex("Questionnaire.Interviewees", new[] { "SeniorityId" });
            DropIndex("Questionnaire.Interviewees", new[] { "EducationId" });
            DropIndex("Questionnaire.Interviewees", new[] { "PlaceOfResidenceId" });
            DropIndex("Questionnaire.Interviewees", new[] { "MartialStatusId" });
            DropIndex("Questionnaire.Interviewees", new[] { "MaterialStatusId" });
            CreateTable(
                "TurtleBarrel.NoteImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TurtleBarrel.Notes", t => t.NoteId, cascadeDelete: true)
                .Index(t => t.NoteId);
            
            CreateTable(
                "TurtleBarrel.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Text = c.String(maxLength: 1000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("Questionnaire.Answers");
            DropTable("Questionnaire.Questions");
            DropTable("Questionnaire.Questionnaires");
            DropTable("Questionnaire.Results");
            DropTable("Questionnaire.Interviewees");
            DropTable("Dictionaries.BaseDictionaries");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.IntervieweeId);
            
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
                .PrimaryKey(t => t.ResultId);
            
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
                "Questionnaire.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        Text = c.String(),
                        QuestionnaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
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
                .PrimaryKey(t => t.AnswerId);
            
            DropForeignKey("TurtleBarrel.NoteImages", "NoteId", "TurtleBarrel.Notes");
            DropIndex("TurtleBarrel.NoteImages", new[] { "NoteId" });
            DropTable("TurtleBarrel.Notes");
            DropTable("TurtleBarrel.NoteImages");
            CreateIndex("Questionnaire.Interviewees", "MaterialStatusId");
            CreateIndex("Questionnaire.Interviewees", "MartialStatusId");
            CreateIndex("Questionnaire.Interviewees", "PlaceOfResidenceId");
            CreateIndex("Questionnaire.Interviewees", "EducationId");
            CreateIndex("Questionnaire.Interviewees", "SeniorityId");
            CreateIndex("Questionnaire.Interviewees", "SexId");
            CreateIndex("Questionnaire.Results", "AnswerId");
            CreateIndex("Questionnaire.Results", "QuestionId");
            CreateIndex("Questionnaire.Results", "QuestionnaireId");
            CreateIndex("Questionnaire.Results", "IntervieweeId");
            CreateIndex("Questionnaire.Questions", "QuestionnaireId");
            CreateIndex("Questionnaire.Answers", "QuestionId");
            AddForeignKey("Questionnaire.Results", "AnswerId", "Questionnaire.Answers", "AnswerId");
            AddForeignKey("Questionnaire.Results", "QuestionId", "Questionnaire.Questions", "QuestionId", cascadeDelete: true);
            AddForeignKey("Questionnaire.Results", "QuestionnaireId", "Questionnaire.Questionnaires", "QuestionnaireId");
            AddForeignKey("Questionnaire.Results", "IntervieweeId", "Questionnaire.Interviewees", "IntervieweeId", cascadeDelete: true);
            AddForeignKey("Questionnaire.Interviewees", "SexId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Interviewees", "SeniorityId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Interviewees", "PlaceOfResidenceId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Interviewees", "MaterialStatusId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Interviewees", "MartialStatusId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Interviewees", "EducationId", "Dictionaries.BaseDictionaries", "BaseDictionaryId");
            AddForeignKey("Questionnaire.Questions", "QuestionnaireId", "Questionnaire.Questionnaires", "QuestionnaireId", cascadeDelete: true);
            AddForeignKey("Questionnaire.Answers", "QuestionId", "Questionnaire.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
