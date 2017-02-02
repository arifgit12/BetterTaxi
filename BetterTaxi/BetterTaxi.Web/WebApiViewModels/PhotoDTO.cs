using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BetterTaxi.Web.WebApiViewModels
{
    public class PhotoDTO
    {
        [JsonProperty(PropertyName = "photoId")]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [Required]
        [StringLength(3)]
        [JsonProperty(PropertyName = "fileExtension")]
        public string FileExtension { get; set; }
    }
}