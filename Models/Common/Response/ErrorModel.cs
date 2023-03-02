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
      message = String.Empty;
    }

    public ErrorModel(string message)
    {
      success = false;
      this.message = message;
    }
  }
}

