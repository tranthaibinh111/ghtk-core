#region DotNet
using System;
#endregion

#region Common
// Interfaces
using GhtkCore.Interfaces.Models.Common;
#endregion

#region GHTK
// Models
using GhtkCore.Models.Ghtk;
#endregion

namespace GhtkCore.Models.Common
{
  /// <summary>
  /// Error Response
  /// { 'success': false, 'message': '' }
  /// </summary>
  public class ErrorModel : IResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }

    public ErrorModel()
    {
      success = false;
      message = String.Empty;
    }

    public ErrorModel(string message)
    {
      success = false;
      this.message = message;
    }
  }

  /// <summary>
  /// Validation Response
  /// { 'success': false, 'message': '', 'error': {}}
  /// </summary>
  public class ErrorModel<T> : ErrorModel
  {
    public T error { get; set; }

    public ErrorModel() : base() {}

    public ErrorModel(string message) : base(message) { }

    public ErrorModel(T error)
    {
      success = false;
      this.error = error;
    }

    public ErrorModel(string message, T error)
    {
      success = false;
      this.message = message;
      this.error = error;
    }
  }
}

