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
  /// { 'success': true, 'message': '', data: {} }
  /// </summary>
  public class SuccessModel<T> : IResponseModel
  {
    public bool success { get; set; }
    public T data { get; set; }

    public SuccessModel(T data)
    {
      success = true;
      this.data = data;
    }
  }
}

