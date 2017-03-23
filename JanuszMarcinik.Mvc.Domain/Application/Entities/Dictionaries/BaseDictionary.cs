﻿using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries
{
    [Table("BaseDictionaries", Schema = "Dictionaries")]
    public class BaseDictionary : IApplicationEntity
    {
        public BaseDictionary()
        {
            this.Sexes = new HashSet<Interviewee>();
            this.Seniorities = new HashSet<Interviewee>();
            this.PlaceOfResidences = new HashSet<Interviewee>();
        }

        public long BaseDictionaryId { get; set; }
        public DictionaryType DictionaryType { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Interviewee> Sexes { get; set; }
        public virtual ICollection<Interviewee> Seniorities { get; set; }
        public virtual ICollection<Interviewee> PlaceOfResidences { get; set; }
    }

    public enum DictionaryType
    {
        [Description("Płeć")]
        Sex = 1,

        [Description("Staż pracy")]
        Seniority = 2,

        [Description("Miejsce zamieszkania")]
        PlaceOfResidence = 3
    }
}