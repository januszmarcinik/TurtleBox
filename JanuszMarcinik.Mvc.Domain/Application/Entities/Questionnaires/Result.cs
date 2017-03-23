using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires
{
    [Table("Results", Schema = "Questionnaire")]
    public class Result : IApplicationEntity
    {
        public long ResultId { get; set; }

        public long IntervieweeId { get; set; }
        public virtual Interviewee Interviewee { get; set; }

        public long QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public long AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}