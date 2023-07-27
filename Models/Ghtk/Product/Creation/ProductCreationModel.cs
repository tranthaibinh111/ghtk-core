#region DotNet
using System;
using System.Dynamic;
#endregion

#region Package (third-party)
using AutoMapper;
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
  public class ProductCreationModel: IProductCreationModel
  {
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Tên hàng hóa
    /// </summary>
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

    #region Generates
    public ExpandoObject generateGhtk()
    {
      try
      {
        dynamic data = new ExpandoObject();

        // Tên hàng hóa
        data.name = name;

        // Giá trị hàng hóa
        if (price.HasValue)
          data.price = price.Value;

        // Khối lượng hàng hóa
        data.weight = weight;

        // Số lượng hàng hóa
        if (quantity.HasValue)
          data.quantity = quantity;

        // Mã sản phẩm được lấy từ api lấy danh sách thông tin sản phẩm
        if (productCcode.HasValue)
          data.product_code = productCcode;

        return data;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }
    #endregion

    #region Map
    public static ProductCreationModel map<T>(T source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<T, ProductCreationModel>()
      );

      var map = new Mapper(config);
      #endregion

      return map.Map<T, ProductCreationModel>(source);
    }
    #endregion
  }
}

