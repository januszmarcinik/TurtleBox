using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.CV
{
    public class SkillsSetViewModel
    {
        public string Head { get; set; }
        public string Icon { get; set; }

        public List<SkillViewModel> Skills { get; set; }
    }
}