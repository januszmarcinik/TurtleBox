using JanuszMarcinik.Mvc.Domain.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires
{
    [Table("Results", Schema = "Questionnaire")]
    public class Result : IApplicationEntity
    {
        public int ResultId { get; set; }

        public int IntervieweeId { get; set; }
        public virtual Interviewee Interviewee { get; set; }

        public int QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}