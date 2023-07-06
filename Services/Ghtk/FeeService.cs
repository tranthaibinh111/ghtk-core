#region DotNet
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
  public sealed class FeeService: AbstractGhtkService
  {
    public FeeService(string token): base(token) {}
    
    #region Public
    /// <summary>
    /// https://docs.giaohangtietkiem.vn/?http#t-nh-ph-v-n-chuy-n
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<FeeResponseModel> getFee(FeeFilterModel filter)
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        #region Thiết lập URL
        var url = "/services/shipment/fee";

        #region Query Parameters
        var query = new Dictionary<string, dynamic>();

        #region Thông tin lấy hàng
        // Địa điểm lấy hàng của shop trong trang quản lý đơn hàng dành cho khách hàng
        if (!String.IsNullOrEmpty(filter.pickAddressId))
          query.Add("pick_address_id", filter.pickAddressId);

        // Địa chỉ ngắn gọn để lấy nhận hàng hóa
        if (!String.IsNullOrEmpty(filter.pickAddress))
          query.Add("pick_address", Uri.EscapeDataString(filter.pickAddress));

        // Tên tỉnh/thành phố nơi lấy hàng hóa
        query.Add("pick_province", Uri.EscapeDataString(filter.pickProvince));

        // Tên quận/huyện nơi lấy hàng hóa
        query.Add("pick_district", Uri.EscapeDataString(filter.pickDistrict));

        // Tên phường/xã nơi lấy hàng hóa
        if (!String.IsNullOrEmpty(filter.pickWard))
          query.Add("pick_ward", Uri.EscapeDataString(filter.pickWard));

        // Tên đường/phố nơi lấy hàng hóa
        if (!String.IsNullOrEmpty(filter.pickStreet))
          query.Add("pick_street", Uri.EscapeDataString(filter.pickStreet));
        #endregion

        #region Thông tin điểm giao hàng
        // Địa chỉ chi tiết của người nhận hàng
        if (!String.IsNullOrEmpty(filter.address))
          query.Add("address", Uri.EscapeDataString(filter.address));

        // Tên tỉnh/thành phố của người nhận hàng hóa
        query.Add("province", Uri.EscapeDataString(filter.province));

        // Tên quận/huyện của người nhận hàng hóa
        query.Add("district", Uri.EscapeDataString(filter.district));

        // Tên phường/xã của người nhận hàng hóa
        if (!String.IsNullOrEmpty(filter.ward))
          query.Add("ward", Uri.EscapeDataString(filter.ward));

        // Tên đường/phố của người nhận hàng hóa
        if (!String.IsNullOrEmpty(filter.street) && filter.street != filter.address)
          query.Add("street", Uri.EscapeDataString(filter.street));
        #endregion

        #region Các thông tin thêm
        // Cân nặng của gói hàng
        query.Add("weight", filter.weight);

        // Giá trị thực của đơn hàng áp dụng để tính phí bảo hiểm, đơn vị sử dụng
        if (filter.value.HasValue)
          query.Add("value", filter.value.Value);

        // Phương thức vâng chuyển
        if (!String.IsNullOrEmpty(filter.transport))
          query.Add("transport", filter.transport);

        // Phương thức vận chuyển xfast
        query.Add("deliver_option", filter.deliverOption);
        #endregion

        if (query.Count > 0)
          url += $"?{QueryHelpers.stringify(query)}";
        #endregion
        #endregion
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var httpResp = await _httpClient.GetAsync(url);
        var parsed = await httpResp.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<FeeResponseModel>(parsed);
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

