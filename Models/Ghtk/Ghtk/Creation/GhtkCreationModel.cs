#region DotNet
using System;
using System.Collections.Generic;
#endregion

#region Package (third-party)
// Newtonsoft Json
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
  /// Tham số khởi tạo đơn giao hàng tiết kiệm
  /// </summary>
  public class GhtkCreationModel
  {
    /// <summary>
    /// Requirement: True<br/>
    /// <br/>
    /// Thông tin đơn hàng gửi sang GHTK
    /// </summary>
    public OrderCreationModel order { get; set; }
    /// <summary>
    /// Requirement: True<br/>
    /// <br/>
    /// Danh sách các sản phẩm, mô tả tham số của từng sản phẩm xem trong bảng tiếp theo
    /// </summary>
    public IList<ProductCreationModel> products { get; set; }

    /// <summary>
    /// Chuyển Object thành JSON
    /// </summary>
    /// <returns></returns>
    public string toJson() => JsonConvert.SerializeObject(this);
  }
}
