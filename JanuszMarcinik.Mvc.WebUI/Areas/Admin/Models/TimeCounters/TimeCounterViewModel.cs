using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeCounters
{
    public class TimeCounterViewModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Nazwa")]
        [StringLength(100, ErrorMessage = "Tytuł musi zawierać od 3 do 100 znaków.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Data docelowa")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public long Miliseconds
        {
            get
            {
                var referenceDate = new DateTime(1970, 1, 1);
                var miliseconds = (long)(this.Date - referenceDate).TotalMilliseconds;
                long twoHoursDiffrence = 2 * 60 * 60 * 1000;

                return miliseconds - twoHoursDiffrence;
            }
        }
    }
}