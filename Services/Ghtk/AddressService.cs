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

#region GHTK
// Models
using GhtkCore.Models.Ghtk;

// Service
using GhtkCore.Services.Abstract;
#endregion


namespace GhtkCore.Services.Ghtk
{
  public sealed class AddressService : AbstractGhtkService
  {
    public AddressService(string token) : base(token) { }

    #region Public
    /// <summary>
    /// https://docs.giaohangtietkiem.vn/#l-y-danh-sa-ch-i-a-chi-c-p-4
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<AddressLevel4ResponseModel> getAddressLevel4(AddressLevel4FilterModel filter)
    {
      try
      {
        #region Thiết lập API Giao Hàng Tiết Kiệm
        // Thiết lập Header
        setHeaders();

        #region Thiết lập URL
        var url = "/services/address/getAddressLevel4";

        #region Query Parameters
        var query = new Dictionary<string, dynamic>();

        // Tên tỉnh/thành phố cần lấy danh sách địa chỉ cấp 4
        query.Add("province", Uri.EscapeDataString(filter.province));

        // Tên quận/huyện cần lấy danh sách địa chỉ cấp 4
        query.Add("district", Uri.EscapeDataString(filter.district));

        // Tên đường/phường cần lấy danh sách địa chỉ cấp 4
        query.Add("ward_street", Uri.EscapeDataString(filter.ward));

        if (query.Count > 0)
          url += $"?{QueryHelpers.stringify(query)}";
        #endregion
        #endregion
        #endregion

        #region Thực thi API Giao Hàng Tiết Kiệm
        var httpResp = await _httpClient.GetAsync(url);
        var parsed = await httpResp.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<AddressLevel4ResponseModel>(parsed);
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
