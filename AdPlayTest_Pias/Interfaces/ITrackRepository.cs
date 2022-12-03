using AdPlayTest_Pias.Models;
using AdPlayTest_Pias.ViewModels;

namespace AdPlayTest_Pias.Interfaces
{
    public interface ITrackRepository
    {
        Task<List<Track>> Search(TrackSearchViewModel trackSearchViewModel);
        Task<Track> Edit(TrackViewModel trackViewModel);
        Task<Track> Delete(long id);
    }
}
