

using AppCore.Business.Models.Results.Base;
using AppCore.Business.Models.Results.Enums;

namespace AppCore.Business.Models.Results
{
    public abstract class Result
    {
        public ResultStatus Status { get; set; }
        public string Message { get; set; }

        public Result(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }

    public abstract class Result<TResultType>: Result, IResultData<TResultType>
    {
        public TResultType Data { get; }
        public Result(ResultStatus status, string message, TResultType data): base (status, message)
        {
            Data = data;
        }
    }
}
