using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.Survey
{
    public class IntervieweeViewModel
    {
        public long IntervieweeId { get; set; }

        public DateTime InterviewDate { get; set; }

        [Required(ErrorMessage = "Wybierz płeć")]
        [Display(Name = "Płeć")]
        public long SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Required(ErrorMessage = "Wybierz staż pracy")]
        [Display(Name = "Staż pracy")]
        public long SeniorityId { get; set; }
        public IEnumerable<SelectListItem> Seniorities { get; set; }

        [Required(ErrorMessage = "Wybierz miejsce zamieszkania")]
        [Display(Name = "Miejsce zamieszkania")]
        public long PlaceOfResidenceId { get; set; }
        public IEnumerable<SelectListItem> PlacesOfResidence { get; set; }

        public void SetDictionaries(IEnumerable<BaseDictionary> dictionary)
        {
            this.Sexes = dictionary.Where(x => x.DictionaryType == DictionaryType.Sex)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.Seniorities = dictionary.Where(x => x.DictionaryType == DictionaryType.Seniority)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.PlacesOfResidence = dictionary.Where(x => x.DictionaryType == DictionaryType.PlaceOfResidence)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });
        }
    }
}