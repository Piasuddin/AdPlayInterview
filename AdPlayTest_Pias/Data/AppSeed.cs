using AdPlayTest_Pias.Models;
using Microsoft.EntityFrameworkCore;

namespace AdPlayTest_Pias.Data
{
    public static class AppSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Track>().HasData(
                new Track { Id = 1, Name = "Track 1",ComposerName = "ComposerName 1", GenreId = 1 },
                new Track { Id = 2, Name = "Track 2",ComposerName = "ComposerName 2", GenreId = 1 },
                new Track { Id = 3, Name = "Track 3",ComposerName = "ComposerName 3", GenreId = 2 },
                new Track { Id = 4, Name = "Track 4",ComposerName = "ComposerName 4", GenreId = 1 },
                new Track { Id = 5, Name = "Track 5",ComposerName = "ComposerName 5", GenreId = 3 },
                new Track { Id = 6, Name = "Track 6", ComposerName = "ComposerName 6", GenreId = 1 }
                );
            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreName = "GenreName 1" },
                new Genre { Id = 2, GenreName = "GenreName 2" },
                new Genre { Id = 3, GenreName  = "GenreName 3" }
                );
        }
    }
}
