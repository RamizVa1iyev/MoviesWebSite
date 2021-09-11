using System.Collections.Generic;
using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGenreService
    {
        IResult Add(Genre genre);
        IResult Update(Genre genre);
        IResult Delete(Genre genre);
        IDataResult<List<Genre>> GetAll();
    }
}