namespace GhtkCore.Interfaces.Models.Common
{
  public interface IResponseModel
  {
    bool success { get; set; }
    string message { get; set; }
  }
}
