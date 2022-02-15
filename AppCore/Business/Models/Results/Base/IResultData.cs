namespace AppCore.Business.Models.Results.Base
{
    public interface IResultData<out TResultType>
    {
        TResultType Data { get; }
    }
}
