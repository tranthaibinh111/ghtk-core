#region DotNet
using System;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Common
using GhtkCore.Models.Common;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class DeliveryResponseModel: SuccessModel
  {
    [JsonProperty(PropertyName = "order")]
    public DeliveryModel delivery { get; set; }
    public DeliveryErrorModel error { get; set; }

    #region Generates
    public ErrorModel<DeliveryErrorModel> generateErrorResponse()
    {
      try
      {
        var resp = new ErrorModel<DeliveryErrorModel>(message, error);

        return resp;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    public SuccessModel<DeliveryModel> generateSuccessResponse()
    {
      try
      {
        var resp = new SuccessModel<DeliveryModel>(delivery);

        return resp;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }
    #endregion
  }
}

