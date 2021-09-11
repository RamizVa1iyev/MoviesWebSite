using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result(bool success, string message) : this(success)
        {
            this.Message = message;
        }

        public Result(bool success)
        {
            this.Success = success;
        }
        public Result()
        {

        }
    }
}
