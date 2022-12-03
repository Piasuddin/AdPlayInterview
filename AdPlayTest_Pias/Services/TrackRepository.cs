using AdPlayTest_Pias.Interfaces;
using AdPlayTest_Pias.Models;
using AdPlayTest_Pias.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdPlayTest_Pias.Services
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ChinookDbContext chinookDbContext;

        public TrackRepository(ChinookDbContext chinookDbContext)
        {
            this.chinookDbContext = chinookDbContext;
        }
        public async Task<Track> Delete(long id)
        {
            var track = await chinookDbContext.Tracks.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (track == null)
            {
                chinookDbContext.Remove(track);
                chinookDbContext.SaveChanges();
            }
            return track;
        }

        public async Task<Track> Edit(TrackViewModel trackViewModel)
        {
            var track = await chinookDbContext.Tracks.Where(e => e.Id == trackViewModel.Id).FirstOrDefaultAsync();
            if (track == null)
            {
                track.Name = trackViewModel.Name; 
                track.GenreId = trackViewModel.GenreId;
                track.ComposerName = trackViewModel.ComposerName;
                chinookDbContext.Tracks.Update(track);
                chinookDbContext.SaveChanges();
            }
            return track;
        }

        public async Task<List<Track>> Search(TrackSearchViewModel trackSearchViewModel)
        {
            return await chinookDbContext.Tracks
                .Include(e => e.Genre)
                .Where(e => e.Name.Contains(trackSearchViewModel.TrackName) || e.Genre.GenreName.Contains(trackSearchViewModel.Genre))
                .ToListAsync();
        }
    }
}
