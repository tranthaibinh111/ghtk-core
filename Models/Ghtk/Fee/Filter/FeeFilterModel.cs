#region DotNet
using System;
#endregion

#region Package (third-party)
using AutoMapper;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#t-nh-ph-v-n-chuy-n
  /// Tham số truy vấn phí vận chuyển
  /// </summary>
  public class FeeFilterModel
  {
    public string pickAddressId { get; set; }
    public string pickAddress { get; set; }
    public string pickProvince { get; set; }
    public string pickDistrict { get; set; }
    public string pickWard { get; set; }
    public string pickStreet { get; set; }
    public string address { get; set; }
    public string province { get; set; }
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Cân nặng của gói hàng, đơn vị sử dụng Gram
    /// </summary>
    public int weight { get; set; }
    public int? value { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Phương thức vâng chuyển road ( bộ ) , fly (bay).
    /// Nếu phương thức vận chuyển không hợp lệ thì GHTK sẽ tự động nhảy về PTVC mặc định
    /// </summary>
    public string transport { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Sử dụng phương thức vận chuyển xfast. Nhận 1 trong 2 giá trị xteam/none
    /// </summary>
    public string deliverOption { get; set; }

    #region Map
    public static FeeFilterModel map<T>(T source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<T, FeeFilterModel>()
      );

      var map = new Mapper(config);
      var result = map.Map<T, FeeFilterModel>(source);
      #endregion

      #region Cập nhật các giá trị mặc định
      /// Sử dụng phương thức vận chuyển xfast
      /// Nhận 1 trong 2 giá trị xteam/none
      if (String.IsNullOrEmpty(result.deliverOption))
        result.deliverOption = "none";
      #endregion

      return result;
    }
    #endregion
  }
}

