using Core.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVCWebUI.Services.Abstract
{
    public interface IGenreService
    {
        Task<DataResult<List<Genre>>> Get();
    }
}
