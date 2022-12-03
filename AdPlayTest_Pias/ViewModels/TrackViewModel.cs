using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdPlayTest_Pias.ViewModels
{
    public class TrackViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ComposerName { get; set; }
        public int GenreId { get; set; }
    }
}
