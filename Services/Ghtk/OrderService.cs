#region DotNet
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Utils
using GhtkCore.Utils;
#endregion

#region Common
// Interfaces
using GhtkCore.Interfaces.Models.Common;

// Models
using GhtkCore.Models.Common;
#endregion

#region GHTK
// Models
using GhtkCore.Models.Ghtk;

// Service
using GhtkCore.Services.Abstract;
#endregion

namespace GhtkCore.Services.Ghtk
{
  public class OrderService : AbstractGhtkService
  {
    public OrderService(string token) : base(token) { }

    #region Public
    /// <summary>
    /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
    /// </summary>
    /// <returns></returns>
    public async Task<IResponseModel> registerOrder(OrderCreationModel data)
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        #region Thiết lập URL
        var url = $"{domain}/services/shipment/order/?ver=1.5";
        
        var content = new StringContent(parameter.toJson(), Encoding.UTF8, "application/json");
        #endregion
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var resp = await _httpClient.PostAsync(url, content);
        var parsed = await resp.Content.ReadAsStringAsync();
        var json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(parsed);
        var success = Convert.ToBoolean(json.GetValueOrDefault("success", false));

        if (success == false)
        {
          var errMsg = Convert.ToString(json.GetValueOrDefault("message", String.Empty));

          return new ErrorModel((string)errMsg);
        }
        #endregion
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);

        throw;
      }
    }
    #endregion
  }
}

