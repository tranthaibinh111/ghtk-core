#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// Phản hồi phí vận chuyền
  /// 
  /// https://docs.giaohangtietkiem.vn/?http#t-nh-ph-v-n-chuy-n
  /// </summary>
  public class FeeModel
  {
    /// <summary>
    /// Tên gói cước được áp dụng, các giá trị có thể: area1, area2, area3
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// Cước vận chuyển tính theo VNĐ
    /// </summary>
    public int fee { get; set; }
    /// <summary>
    /// Giá bảo hiểm tính theo VNĐ
    /// </summary>
    [JsonProperty("insurance_fee")]
    public int insuranceFee { get; set; }
    /// <summary>
    /// Hỗ trợ giao ở địa chỉ này chưa, nếu điểm giao đã được GHTK hỗ trợ giao trả về true,
    /// nếu GTHK chưa hỗ trợ giao đến khu vực này thì trả về false
    /// </summary>
    public bool delivery { get; set; }
  }
}

