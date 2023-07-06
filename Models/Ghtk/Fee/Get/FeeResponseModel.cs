#region DotNet
using System;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Common
using GhtkCore.Models.Common;
using GhtkCore.Interfaces.Models.Common;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class FeeResponseModel : ResponseModel, ISuccessResponse<FeeModel>, IErrorResponse
  {
    [JsonProperty(PropertyName = "fee")]
    public FeeModel data { get; set; }
  }
}

