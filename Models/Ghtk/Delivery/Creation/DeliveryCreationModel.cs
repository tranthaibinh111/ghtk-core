#region DotNet
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
#endregion

#region GHTK
// Interface
using GhtkCore.Interfaces.Models.Ghtk;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
  /// Tham số khởi tạo đơn giao hàng tiết kiệm
  /// </summary>
  public class DeliveryCreationModel: IDeliveryCreationModel
  {
    /// <summary>
    /// Requirement: True<br/>
    /// <br/>
    /// Thông tin đơn hàng gửi sang GHTK
    /// </summary>
    public IOrderCreationModel order { get; set; }
    /// <summary>
    /// Requirement: True<br/>
    /// <br/>
    /// Danh sách các sản phẩm, mô tả tham số của từng sản phẩm xem trong bảng tiếp theo
    /// </summary>
    public IList<IProductCreationModel> products { get; set; }

    public DeliveryCreationModel(IOrderCreationModel order, IList<ProductCreationModel> products)
    {
      this.order = order;

      if (products == null)
        this.products = new List<IProductCreationModel>();
      else
        this.products = products.Select(x => (IProductCreationModel)x).ToList();
    }

    #region Generates
    /// <summary>
    /// Chuyển Object thành JSON
    /// </summary>
    /// <returns></returns>
    public ExpandoObject generateGhtk()
    {
      try
      {
        dynamic data = new ExpandoObject();

        // Thông tin đơn hàng gửi sang GHTK
        data.order = order.generateGhtk();
        // Danh sách các sản phẩm, mô tả tham số của từng sản phẩm xem trong bảng tiếp theo
        data.products = products.Select(x => x.generateGhtk()).ToList();

        return data;
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
