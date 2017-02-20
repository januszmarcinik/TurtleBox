using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Images", Schema = "Storage")]
    public class Image : IApplicationEntity
    {
        public long ImageId { get; set; }
        public string Container { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}