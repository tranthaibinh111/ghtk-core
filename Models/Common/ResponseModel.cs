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
  /// Success Response
  /// { 'success': true, 'message': '' }
  /// </summary>
  public class ResponseModel : IResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }

    public ResponseModel()
    {
      success = true;
    }

    public ResponseModel(string message)
    {
      success = true;
      this.message = message;
    }
  }
}

