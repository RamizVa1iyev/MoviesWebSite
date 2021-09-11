
using Newtonsoft.Json;

namespace Core.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
