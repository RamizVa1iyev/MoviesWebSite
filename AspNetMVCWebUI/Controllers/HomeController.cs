using AspNetMVCWebUI.Models;
using AspNetMVCWebUI.Services.Abstract;
using AspNetMVCWebUI.Services.Concrete;
using Core.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public HomeController(IMovieService movieService,IGenreService genreService)
        {
            this._movieService = movieService;
            this._genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            MovieViewModel model = new MovieViewModel();
            var moviesData = await _movieService.Get();
            model.MoviesData = moviesData;
            ViewData["Title"] = "Test";
            return View(model);
        }
        public async Task<IActionResult> MovieDetail(int id)
        {
            MovieViewModel model = new MovieViewModel();
            var movie = await _movieService.GetById(id);
            var genres = await this._genreService.Get();
            model.Genres = new SelectList(genres.Data, "GenreId","GenreName");
            model.Movie = movie;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MovieDetail(DataResult<Movie> movie)
        {
            var result = await _movieService.Put(movie.Data);
            if (result.Success)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddMovie()
        {
            MovieViewModel model = new MovieViewModel();
            var genres = await this._genreService.Get();
            model.Genres = new SelectList(genres.Data, "GenreId", "GenreName");
            model.Movie = new DataResult<Movie>();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(DataResult<Movie> movie)
        {
            var result = await this._movieService.Post(movie.Data);
            if (result.Success)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            await this._movieService.Delete(movieId);
            return RedirectToAction("Index");
        }
    }
}
