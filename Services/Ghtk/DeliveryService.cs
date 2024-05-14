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
  public sealed class DeliveryService : AbstractGhtkService
  {
    public DeliveryService(string token) : base(token) { }

    #region Public
    /// <summary>
    /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
    /// </summary>
    /// <param name="order">Thông tin đăng ký giao hàng tiết kiệm</param>
    /// <param name="products">Thông tin danh sách sản phẩm giao hàng</param>
    /// <returns></returns>
    public async Task<DeliveryResponseModel> registerDelivery(
      OrderCreationModel order,
      IList<ProductCreationModel> products,
      bool isFirst = true
    )
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        #region Thiết lập URL
        var url = "/services/shipment/order";

        #region Query Parameters
        var query = new Dictionary<string, dynamic>();

        /// DateTime: 2023-07-06 16:51
        ///
        /// Author: Binh-TT
        ///
        /// Update new version
        query.Add("ver", "1.5");

        if (query.Count > 0)
          url += $"?{QueryHelpers.stringify(query)}";
        #endregion

        #region POST Data
        var delivery = new DeliveryCreationModel(order, products);
        var ghtk = delivery.generateGhtk();
        var post = JsonConvert.SerializeObject(ghtk);
        var content = new StringContent(post, Encoding.UTF8, "application/json");
        #endregion
        #endregion
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var httpResp = await _httpClient.PostAsync(url, content);
        var parsed = await httpResp.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<DeliveryResponseModel>(parsed);
        #endregion

        // Fix bug: Trường hợp tồn tại mã đơn hàng trên hệ thống
        if (!resp.success && resp.error != null)
        {
          var errCode = resp.error.code;

          if (errCode == "ORDER_ID_EXIST" && isFirst)
          {
            order.id = $"{order.id}_{DateTime.Now:yyyyMMddHHmmss}";

            return await registerDelivery(order, products, isFirst = false);
          }
        }

        return resp;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);

        throw;
      }
    }

    public async Task<IResponseModel> cancelDelivery(String code)
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        // Thiết lập URL
        var url = $"/services/shipment/cancel/{code}";
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var httpResp = await _httpClient.PostAsync(url, null);
        var parsed = await httpResp.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<ResponseModel>(parsed);
        #endregion

        return resp;
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

