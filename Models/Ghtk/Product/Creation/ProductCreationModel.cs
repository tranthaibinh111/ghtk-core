#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
  /// Tham số khởi tạo đơn giao hàng tiết kiệm
  /// </summary>
  public class ProductCreationModel
  {
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Tên hàng hóa
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string name { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Giá trị hàng hóa
    /// </summary>
    public int? price { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Khối lượng hàng hóa Tính theo đơn vị KG
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public double? weight { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Số lượng hàng hóa
    /// </summary>
    public int? quantity { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Mã sản phẩm được lấy từ api lấy danh sách thông tin sản phẩm
    /// </summary>
    public int? productCcode { get; set; }
  }
}

