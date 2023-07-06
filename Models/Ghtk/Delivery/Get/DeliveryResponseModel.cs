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
  public class DeliveryResponseModel: ResponseModel, ISuccessResponse<DeliveryModel>, IErrorResponse<DeliveryErrorModel>
  {
    [JsonProperty(PropertyName = "order")]
    public DeliveryModel data { get; set; }
    public DeliveryErrorModel error { get; set; }
  }
}

