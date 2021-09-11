using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetMVCWebUI.Services.Abstract;
using Core.Extensions;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Entities.Concrete;

namespace AspNetMVCWebUI.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private const string baseUrl = "https://localhost:44340/api/Movies";
        public async Task<Result> Delete(int movieId)
        {
            using HttpClient client = new HttpClient();
            var result = await client.DeleteJsonAsync<Result>(baseUrl+"?movieId="+movieId);
            return result;
        }

        public async Task<DataResult<Movie>> GetById(int movieId)
        {
            using HttpClient client = new HttpClient();
            var result = await client.GetJsonAsync<DataResult<Movie>>($"{baseUrl}/getById?movieId={movieId}");
            return result;
        }
        public async Task<DataResult<List<Movie>>> Get()
        {
            using HttpClient client = new HttpClient();
            var result = await client.GetJsonAsync<DataResult<List<Movie>>>(baseUrl);
            return result;
        }


        public Result GetByGenreId(int genreId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Post(Movie movie)
        {
            using HttpClient client = new HttpClient();
            var result = await client.PostJsonAsync<Result, Movie>(baseUrl, movie);
            return result;
        }

        public async Task<Result> Put(Movie movie)
        {
            using HttpClient client = new HttpClient();
            var result = await client.PutJsonAsync<Result, Movie>(baseUrl,movie);
            return result;
        }
    }
}
