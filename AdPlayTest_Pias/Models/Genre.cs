using AdPlayTest_Pias.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdPlayTest_Pias.Models
{
    public class Genre: IBaseModel<int>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column(TypeName ="varchar(30)")]
        public string? GenreName { get; set; }

        [JsonIgnore]
        public ICollection<Track>? Tracks { get; set; }

    }
}
