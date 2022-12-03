using AdPlayTest_Pias.Controllers;
using AdPlayTest_Pias.Interfaces;
using AdPlayTest_Pias.Models;
using AdPlayTest_Pias.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdPlayTest
{
    public class TrackControllerTest
    {
        //here i keep the test simple because of time matter
        //here we need to create a fakedb set and perform more test opertion
        [Fact]
        public void Search_Should_Sucess()
        {
            // Arrange
            var service = new Mock<ITrackRepository>();
            var searchTearm = new TrackSearchViewModel
            {
                Genre = "Genre 1",
                TrackName = "Test",
            };
            var tracks = new List<Track>()
            {
                new Track
                {
                    Id = 1,
                    ComposerName = "Test",
                    Genre = new Genre
                    {
                        GenreName= "Genre 1",
                        Id= 1
                    },
                    Name = "Test"
                }
            };
            service.Setup(obj => obj.Search(searchTearm)).Returns(Task.FromResult(tracks));
            var controller = new TrackController(service.Object);
            // Act  
            var result = controller.Search(searchTearm);
            // Assert
            Assert.True(result is List<Track>);
            Assert.NotNull(result);
        }


        [Fact]
        public void Search_Should_Failed()
        {
            // Arrange
            var service = new Mock<ITrackRepository>();
            var searchTearm = new TrackSearchViewModel
            {
                Genre = "Genre 1",
                TrackName = "Test",
            };
            List<Track> tracks = null;
            service.Setup(obj => obj.Search(searchTearm)).Returns(Task.FromResult(tracks));
            var controller = new TrackController(service.Object);
            // Act  
            var result = controller.Search(searchTearm);
            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void Edit_Should_Sucess()
        {
            // Arrange
            var service = new Mock<ITrackRepository>();
            var track = new TrackViewModel
            {
                Id = 1,
                ComposerName = "Test",
                GenreId = 1,
                Name = "Test"
            };
            var returnTrack =
                new Track
                {
                    Id = 1,
                    ComposerName = "Test",
                    Genre = new Genre
                    {
                        GenreName = "Genre 1",
                        Id = 1
                    },
                    Name = "Test"
                };
            service.Setup(obj => obj.Edit(track)).Returns(Task.FromResult(returnTrack));
            var controller = new TrackController(service.Object);
            // Act  
            var result = controller.Edit(track);
            // Assert
            Assert.True(result is Track);
            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Should_Sucess()
        {
            // Arrange
            var service = new Mock<ITrackRepository>();
            var track =
                new Track
                {
                    Id = 1,
                    ComposerName = "Test",
                    Genre = new Genre
                    {
                        GenreName = "Genre 1",
                        Id = 1
                    },
                    Name = "Test"
                };
            service.Setup(obj => obj.Delete(1)).Returns(Task.FromResult(track));
            var controller = new TrackController(service.Object);
            // Act  
            var result = controller.Delete(1);
            // Assert
            Assert.True(result is Track);
            Assert.NotNull(result);
        }
    }
}
