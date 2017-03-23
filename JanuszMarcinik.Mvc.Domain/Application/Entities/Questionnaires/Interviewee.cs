using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires
{
    [Table("Interviewees", Schema = "Questionnaire")]
    public class Interviewee : IApplicationEntity
    {
        public Interviewee()
        {
            this.Results = new HashSet<Result>();
        }

        public long IntervieweeId { get; set; }

        public DateTime InterviewDate { get; set; }

        public long SexId { get; set; }
        [ForeignKey("SexId")]
        public virtual BaseDictionary Sex { get; set; }

        public long SeniorityId { get; set; }
        [ForeignKey("SeniorityId")]
        public virtual BaseDictionary Seniority { get; set; }

        public long PlaceOfResidenceId { get; set; }
        [ForeignKey("PlaceOfResidenceId")]
        public virtual BaseDictionary PlaceOfResidence { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}