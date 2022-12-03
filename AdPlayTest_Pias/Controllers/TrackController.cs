using AdPlayTest_Pias.Interfaces;
using AdPlayTest_Pias.Models;
using AdPlayTest_Pias.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdPlayTest_Pias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackRepository trackRepository;

        public TrackController(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        [HttpPost]
        [Route("Delete")]
        [ProducesResponseType(typeof(Track), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(long id)
        {
            var track = await trackRepository.Delete(id);
            if(track != null) {
                return Ok(track);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Edit")]
        [ProducesResponseType(typeof(Track), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Edit(TrackViewModel trackViewModel)
        {
            var track = await trackRepository.Edit(trackViewModel);
            if (track != null)
            {
                return Ok(track);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Search")]
        [ProducesResponseType(typeof(List<Track>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Search(TrackSearchViewModel trackSearchViewModel)
        {
            var tracks = await trackRepository.Search(trackSearchViewModel);
            if (tracks != null)
            {
                return Ok(tracks);
            }
            return NotFound();
        }
    }
}
