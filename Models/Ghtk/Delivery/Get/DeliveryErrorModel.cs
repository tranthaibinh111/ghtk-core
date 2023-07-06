#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class DeliveryErrorModel
  {
    /// <summary>
    /// Mã lỗi API GHTK trả về
    /// </summary>
    public string code { get; set; }
    /// <summary>
    /// Mã đơn hàng của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "partner_id")]
    public string partnerId { get; set; }
    /// <summary>
    /// Nhãn đơn của GHTK
    /// </summary>
    [JsonProperty(PropertyName = "ghtk_label")]
    public string ghtkLabel { get; set; }
    /// <summary>
    /// Thời gian đơn hàng được tạo
    /// </summary>
    public string created { get; set; }
    /// <summary>
    /// Trạng thái hiện tại của đơn hàng
    /// </summary>
    public int status { get; set; }
  }
}

