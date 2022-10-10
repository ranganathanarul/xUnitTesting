using DemoAPIwithSample.Controllers;
using DemoAPIwithSample.Data.Services;
using DemoAPIwithSample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DemoAPIwithSample.xUnit
{
    public class MoviesController_xUnitTest
    {
        private MoviesController _controller;
        private IMovieService _service;
        private ILogger _logger;

        public MoviesController_xUnitTest()
        {
            _service = new MovieService();
            _controller = new MoviesController(_service,_logger);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange

            //Act
            var result = _controller.GetAll();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Movies>>(list.Value);

            var listMovies = list.Value as List<Movies>;

            Assert.Equal(5, listMovies.Count);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", "ab2bd817-98cd-4cf3-a80a-53ea0cd9c111")]
        public void GetMovieByIdTest(string guid1, string guid2)
        {
            //Arrange
            var validGuid = new Guid(guid1);
            var invalidGuid = new Guid(guid2);

            //Act
            var notFoundResult = _controller.Get(invalidGuid);
            var okResult = _controller.Get(validGuid);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            Assert.IsType<OkObjectResult>(okResult.Result);


            //Now we need to check the value of the result for the ok object result.
            var item = okResult.Result as OkObjectResult;

            //We Expect to return a single Movie
            Assert.IsType<Movies>(item.Value);

            //Now, let us check the value itself.
            var movieItem = item.Value as Movies;
            Assert.Equal(validGuid, movieItem.Id);
            Assert.Equal("Managing Oneself", movieItem.Title);
        }

        [Fact]
        public void AddMovieTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeMovie = new Movies()
            {
                Director = "Ranganathan",
                Title = "Xunit for API's",
                Description = "fun wrighting the API test"
            };

            //Act
            var createdResponse = _controller.Post(completeMovie);

            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);

            //value of the result
            var item = createdResponse as CreatedAtActionResult;
            Assert.IsType<Movies>(item.Value);

            //check value of this Movies
            var movieItem = item.Value as Movies;
            Assert.Equal(completeMovie.Director, movieItem.Director);
            Assert.Equal(completeMovie.Title, movieItem.Title);
            Assert.Equal(completeMovie.Description, movieItem.Description);

            //OK RESULT TEST END

            //BADREQUEST AND MODELSTATE ERROR TEST START

            //Arrange
            var incompleteMovie = new Movies()
            {
                Director = "Ranganathan Palanisamy",
                Description = "Still working on the Movie"
            };

            //Act
            _controller.ModelState.AddModelError("Title", "Title is a requried filed");
            var badResponse = _controller.Post(incompleteMovie);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);



            //BADREQUEST AND MODELSTATE ERROR TEST END
        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", "ab2bd817-98cd-4cf3-a80a-53ea0cd9c111")]
        public void RemoveMovieByIdTest(string guid1, string guid2)
        {
            //Arrange
            var validGuid = new Guid(guid1);
            var invalidGuid = new Guid(guid2);

            //Act
            var notFoundResult = _controller.RemoveMovie(invalidGuid);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.Equal(5, _service.GetAll().Count());

            //Act
            var okResult = _controller.RemoveMovie(validGuid);


            //Assert
            Assert.IsType<OkResult>(okResult);
            Assert.Equal(4, _service.GetAll().Count());
        }
    }
}

