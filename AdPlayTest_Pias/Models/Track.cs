using AdPlayTest_Pias.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdPlayTest_Pias.Models
{
    public class Track : IBaseModel<long>
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? ComposerName { get; set; }

        //navigation property
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
