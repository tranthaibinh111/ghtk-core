#region DotNet
using System;
using System.Collections.Generic;
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
  #region Error Response
  /// <summary>
  /// Error Response
  /// { 'success': true, 'message': '' }
  /// </summary>
  public class ErrorModel : IResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }

    public ErrorModel()
    {
      success = false;
    }
  }
  #endregion

  #region Success Response
  /// <summary>
  /// Success Response
  /// { 'success': true, 'message': '', data: {} }
  /// </summary>
  public class SuccessModel<T> : ErrorModel
  {
    public T data { get; set; }

    public SuccessModel(T data)
    {
      success = true;
      message = String.Empty;
      this.data = data;
    }
  }
  #endregion
}

