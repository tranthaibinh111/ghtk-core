namespace GhtkCore.Interfaces.Models.Common
{
  public interface IErrorResponse : IResponseModel
  {
  }

  public interface IErrorResponse<T> : IResponseModel
  {
    T error { get; set; }
  }
}
