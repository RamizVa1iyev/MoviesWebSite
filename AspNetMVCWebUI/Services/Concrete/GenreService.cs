using AspNetMVCWebUI.Services.Abstract;
using Core.Extensions;
using Core.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetMVCWebUI.Services.Concrete
{
    public class GenreService : IGenreService
    {
        private const string baseUrl = "https://localhost:44340/api/Genres";
        public async Task<DataResult<List<Genre>>> Get()
        {
            using HttpClient client = new HttpClient();
            var result = await client.GetJsonAsync<DataResult<List<Genre>>>(baseUrl);
            return result;
        }
    }
}
