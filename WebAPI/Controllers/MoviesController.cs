using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]  // www.k201.com/api/movies/getall
    [ApiController] 
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult Add(Movie movie) // www.k201.com/api/movies/add
        {
            var result = this._movieService.Add(movie);

            if (result.Success)
            {
                return Ok(result);  // 200
            }

            return BadRequest(result); // 400
        }

        [HttpPut]
        public IActionResult Update(Movie movie) 
        {
            var result = this._movieService.Update(movie);

            if (result.Success)
            {
                return Ok(result);  // 200
            }

            return BadRequest(result); // 400
        }

        [HttpDelete]
        public IActionResult Delete(int movieId)
        {
            var result = this._movieService.Delete(new Movie() { MovieId=movieId});

            if (result.Success)
            {
                return Ok(result);  // 200
            }

            return BadRequest(result); // 400
        }

        [HttpGet]
        public IActionResult GetAll() // www.k201.com/api/movies/getall
        {
            var result = this._movieService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int movieId) 
        {
            var result = this._movieService.GetById(movieId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getByGenreId")]
        public IActionResult GetByGenreId(int genreId) // ../api/movies/getgenres?genreId=1
        {
            var result = this._movieService.GetByGenreId(genreId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
