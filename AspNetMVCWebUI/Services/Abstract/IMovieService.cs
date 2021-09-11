using Core.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVCWebUI.Services.Abstract
{
    public interface IMovieService
    {
        Task<DataResult<List<Movie>>> Get();
        Task<DataResult<Movie>> GetById(int movieId);
        Task<Result> Post(Movie movie);
        Task<Result> Put(Movie movie);
        Task<Result> Delete(int movieId);
        Result GetByGenreId(int genreId);
    }
}
