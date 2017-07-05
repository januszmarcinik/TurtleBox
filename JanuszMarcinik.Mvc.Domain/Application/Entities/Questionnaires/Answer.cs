using JanuszMarcinik.Mvc.Domain.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires
{
    [Table("Answers", Schema = "Questionnaire")]
    public class Answer : IApplicationEntity
    {
        public Answer()
        {
            this.Results = new HashSet<Result>();
        }

        public long AnswerId { get; set; }

        public int OrderNumber { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}