#region DotNet
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Interface
using GhtkCore.Interfaces.Services;
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
// Parameters
using GhtkCore.Parameters.Ghtk;

// Models
using GhtkCore.Models.Ghtk;

// Service
using GhtkCore.Services.Abstract;
using System.Reflection.PortableExecutable;
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
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<IResponseModel> getFee(FeeParameter parameters)
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
        if (!String.IsNullOrEmpty(parameters.pickAddressId))
          query.Add("pick_address_id", parameters.pickAddressId);
        // pick_address
        if (!String.IsNullOrEmpty(parameters.pickAddress))
          query.Add("pick_address", Uri.EscapeDataString(parameters.pickAddress));
        // pick_province
        query.Add("pick_province", Uri.EscapeDataString(parameters.pickProvince));
        // pick_district
        query.Add("pick_district", Uri.EscapeDataString(parameters.pickDistrict));
        // pick_ward
        if (!String.IsNullOrEmpty(parameters.pickWard))
          query.Add("pick_ward", Uri.EscapeDataString(parameters.pickWard));
        // pick_street
        if (!String.IsNullOrEmpty(parameters.pickStreet))
          query.Add("pick_street", Uri.EscapeDataString(parameters.pickStreet));
        // address
        if (!String.IsNullOrEmpty(parameters.address))
          query.Add("address", Uri.EscapeDataString(parameters.address));
        // province
        query.Add("province", Uri.EscapeDataString(parameters.province));
        // district
        query.Add("district", Uri.EscapeDataString(parameters.district));
        // ward
        if (!String.IsNullOrEmpty(parameters.ward))
          query.Add("ward", Uri.EscapeDataString(parameters.ward));
        // street
        if (!String.IsNullOrEmpty(parameters.street) && parameters.street != parameters.address)
          query.Add("ward", Uri.EscapeDataString(parameters.street));
        // Weight
        query.Add("weight", parameters.weight.Value);
        // Value
        if (parameters.value.HasValue)
          query.Add("value", parameters.value.Value);
        // Transport
        if (!String.IsNullOrEmpty(parameters.transport))
          query.Add("transport", parameters.transport);
        // Deliver option
        query.Add("deliver_option", "none");

        if (query.Count > 0)
          url += $"?{QueryHelpers.stringify(query)}";
        #endregion
        #endregion
        #endregion

        IResponseModel result;

        #region Thực thi API KiotViet
        var response = await _httpClient.GetAsync(url);
        var parsed = await response.Content.ReadAsStringAsync();

        result = JsonConvert.DeserializeObject<ErrorModel>(parsed);

        if (!result.success)
          return result;
        #endregion

        #region Tổng hợp dữ liệu
        var json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(parsed);
        var data = JsonConvert.DeserializeObject<FeeModel>(json["fee"].ToString());

        result = new SuccessModel<FeeModel>(data);
        #endregion

        return result;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);

        throw;
      }
    }
    #endregion
  }
}

