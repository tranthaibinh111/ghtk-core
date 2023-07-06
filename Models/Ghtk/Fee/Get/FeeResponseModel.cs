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
  public class FeeResponseModel : SuccessModel
  {
    [JsonProperty(PropertyName = "fee")]
    public FeeModel data { get; set; }

    #region Generates
    public ErrorModel generateErrorResponse()
    {
      try
      {
        var resp = new ErrorModel(message);

        return resp;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    public SuccessModel<FeeModel> generateSuccessResponse()
    {
      try
      {
        var resp = new SuccessModel<FeeModel>(data);

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

