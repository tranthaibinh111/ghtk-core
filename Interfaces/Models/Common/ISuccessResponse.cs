namespace GhtkCore.Interfaces.Models.Common
{
  public interface ISuccessResponse: IResponseModel
  {
  }

  public interface ISuccessResponse<T> : IResponseModel
  {
    T data { get; set; }
  }
}
