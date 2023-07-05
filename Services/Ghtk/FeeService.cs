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
    public async Task<IResponseModel> getFee(FeeFilterModel filter)
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        #region Thiết lập URL
        var url = $"{domain}/services/shipment/fee";

        #region Query Parameters
        var query = new Dictionary<string, dynamic>();

        // pick_address_id
        if (!String.IsNullOrEmpty(filter.pickAddressId))
          query.Add("pick_address_id", filter.pickAddressId);
        // pick_address
        if (!String.IsNullOrEmpty(filter.pickAddress))
          query.Add("pick_address", Uri.EscapeDataString(filter.pickAddress));
        // pick_province
        query.Add("pick_province", Uri.EscapeDataString(filter.pickProvince));
        // pick_district
        query.Add("pick_district", Uri.EscapeDataString(filter.pickDistrict));
        // pick_ward
        if (!String.IsNullOrEmpty(filter.pickWard))
          query.Add("pick_ward", Uri.EscapeDataString(filter.pickWard));
        // pick_street
        if (!String.IsNullOrEmpty(filter.pickStreet))
          query.Add("pick_street", Uri.EscapeDataString(filter.pickStreet));
        // address
        if (!String.IsNullOrEmpty(filter.address))
          query.Add("address", Uri.EscapeDataString(filter.address));
        // province
        query.Add("province", Uri.EscapeDataString(filter.province));
        // district
        query.Add("district", Uri.EscapeDataString(filter.district));
        // ward
        if (!String.IsNullOrEmpty(filter.ward))
          query.Add("ward", Uri.EscapeDataString(filter.ward));
        // street
        if (!String.IsNullOrEmpty(filter.street) && filter.street != filter.address)
          query.Add("ward", Uri.EscapeDataString(filter.street));
        // Weight
        query.Add("weight", filter.weight);
        // Value
        if (filter.value.HasValue)
          query.Add("value", filter.value.Value);
        // Transport
        if (!String.IsNullOrEmpty(filter.transport))
          query.Add("transport", filter.transport);
        // Deliver option
        query.Add("deliver_option", filter.deliverOption);

        if (query.Count > 0)
          url += $"?{QueryHelpers.stringify(query)}";
        #endregion
        #endregion
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var resp = await _httpClient.GetAsync(url);
        var parsed = await resp.Content.ReadAsStringAsync();
        var json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(parsed);
        var success = Convert.ToBoolean(json.GetValueOrDefault("success", false));

        if (success == false)
        {
          var errMsg = Convert.ToString(json.GetValueOrDefault("message", String.Empty));

          return new ErrorModel((string)errMsg);
        }
        #endregion

        #region Tổng hợp dữ liệu
        var data = JsonConvert.DeserializeObject<FeeModel>(json["fee"].ToString());
        var result = new SuccessModel<FeeModel>(data);
        #endregion

        return result;
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

