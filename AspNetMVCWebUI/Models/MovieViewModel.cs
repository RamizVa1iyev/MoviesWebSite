using Core.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetMVCWebUI.Models
{
    public class MovieViewModel
    {
        public DataResult<List<Movie>> MoviesData { get; set; }
        public DataResult<Movie> Movie { get; set; }
        public SelectList Genres { get; set; }
    }
}
