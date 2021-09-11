
namespace Core.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
