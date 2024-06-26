#region DotNet
using System;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Common
// Interfaces
using GhtkCore.Interfaces.Models.Common;

// Models
using GhtkCore.Models.Common;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class FeeResponseModel : ResponseModel, ISuccessResponse<FeeModel>, IErrorResponse
  {
    [JsonProperty(PropertyName = "fee")]
    public FeeModel data { get; set; }
  }
}

