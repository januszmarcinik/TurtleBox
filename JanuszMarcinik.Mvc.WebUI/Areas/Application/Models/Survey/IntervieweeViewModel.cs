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
        public int IntervieweeId { get; set; }

        public DateTime InterviewDate { get; set; }

        [Required(ErrorMessage = "Wybierz wiek")]
        [Display(Name = "Wiek")]
        [Range(minimum: 20, maximum: 67, ErrorMessage = "Wiek musi być z przedziału od 20 do 67 lat.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Wybierz płeć")]
        [Display(Name = "Płeć")]
        public int SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Required(ErrorMessage = "Wybierz staż pracy")]
        [Display(Name = "Staż pracy")]
        public int SeniorityId { get; set; }
        public IEnumerable<SelectListItem> Seniorities { get; set; }

        [Required(ErrorMessage = "Wybierz miejsce zamieszkania")]
        [Display(Name = "Miejsce zamieszkania")]
        public int PlaceOfResidenceId { get; set; }
        public IEnumerable<SelectListItem> PlacesOfResidence { get; set; }

        [Required(ErrorMessage = "Wybierz wykształcenie")]
        [Display(Name = "Wykształcenie")]
        public int EducationId { get; set; }
        public IEnumerable<SelectListItem> Educations { get; set; }

        [Required(ErrorMessage = "Wybierz stan cywilny")]
        [Display(Name = "Stan cywilny")]
        public int MartialStatusId { get; set; }
        public IEnumerable<SelectListItem> MartialStatuses { get; set; }

        [Required(ErrorMessage = "Wskaż ocenę swojego stanu materialnego")]
        [Display(Name = "Ocena swojego stanu materialnego")]
        public int MaterialStatusId { get; set; }
        public IEnumerable<SelectListItem> MaterialStatuses { get; set; }

        public void SetDictionaries(IEnumerable<BaseDictionary> dictionary)
        {
            this.Sexes = dictionary.Where(x => x.DictionaryType == DictionaryType.Sex)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.Seniorities = dictionary.Where(x => x.DictionaryType == DictionaryType.Seniority)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.PlacesOfResidence = dictionary.Where(x => x.DictionaryType == DictionaryType.PlaceOfResidence)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.Educations = dictionary.Where(x => x.DictionaryType == DictionaryType.Education)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.MartialStatuses = dictionary.Where(x => x.DictionaryType == DictionaryType.MartialStatus)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });

            this.MaterialStatuses = dictionary.Where(x => x.DictionaryType == DictionaryType.MaterialStatus)
                .Select(x => new SelectListItem() { Text = x.Value, Value = x.BaseDictionaryId.ToString() });
        }
    }
}