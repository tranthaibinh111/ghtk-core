#region DotNet
using System;
using System.Collections.Generic;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class DeliveryModel
  {
    /// <summary>
    /// Mã đơn hàng của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "partner_id")]
    public string partnerId { get; set; }
    /// <summary>
    /// Nhãn đơn của GHTK
    /// </summary>
    [JsonProperty(PropertyName = "label")]
    public string code { get; set; }
    /// <summary>
    /// Tên gói cước phí được áp dụng
    /// </summary>
    public string area { get; set; }
    /// <summary>
    /// Phí GHTK
    /// </summary>
    [JsonProperty(PropertyName = "fee")]
    public int fee { private get; set; }
    /// <summary>
    /// Phí bảo hiểm
    /// </summary>
    [JsonProperty(PropertyName = "insurance_fee")]
    public string insuranceFee { get; set; }
    /// <summary>
    /// Thời gian dự tính lấy hàng
    /// </summary>
    [JsonProperty(PropertyName = "estimated_pick_time")]
    public string estimatedPickTime { get; set; }
    /// <summary>
    /// Thòi gian dự tính giao hàng
    /// </summary>
    [JsonProperty(PropertyName = "estimated_deliver_time")]
    public string estimatedDeliverTime { get; set; }
    /// <summary>
    /// Danh sách sản phẩm giao hàng
    /// </summary>
    public IList<ProductModel> products { get; set; }
    /// <summary>
    /// Trạng thái hiện tại của đơn hàng
    /// </summary>
    [JsonProperty(PropertyName = "status_id")]
    public int statusId { get; set; }
  }
}

