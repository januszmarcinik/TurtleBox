using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Models
{
    public class TurtleBarrelViewModel
    {
        public NoteViewModel Note { get; set; }
        public IEnumerable<NoteImageViewModel> Images { get; set; }
    }
}