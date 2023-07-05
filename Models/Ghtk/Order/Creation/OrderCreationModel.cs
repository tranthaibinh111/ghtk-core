#region DotNet
using System.Collections.Generic;
#endregion

#region Package (third-party)
// Newtonsoft Json
using Newtonsoft.Json;

// Auto Mapper
using AutoMapper;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
  /// Tham số khởi tạo đơn giao hàng tiết kiệm
  /// </summary>
  public class OrderCreationModel
  {
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string id { get; set; }

    #region Thông tin điểm lấy hàng
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "pick_name", Required = Required.Always)]
    public string pickName { get; set; }
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "pick_address", Required = Required.Always)]
    public string pickAddress { get; set; }
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "pick_province", Required = Required.Always)]
    public string pickProvince { get; set; }
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(PropertyName = "pick_district", Required = Required.Always)]
    public string pickDistrict { get; set; }
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    public string pickWard { get; set; }
    /// <summary>
    /// Requirement: True
    ///
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    public string pickTel { get; set; }
    #endregion
    public string tel { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string province { get; set; }
    public string district { get; set; }
    public string ward { get; set; }
    public string hamlet { get; set; }
    public string isFreeship { get; set; }
    public string pickDate { get; set; }
    public string pickMoney { get; set; }
    public string note { get; set; }
    public string value { get; set; }
    public string transport { get; set; }
    public string pickOption { get; set; }
    public string deliverOption { get; set; }
    public string pickSession { get; set; }
    public string tags { get; set; }

    /// <summary>
    /// Requirement: True
    ///
    /// Danh sách các sản phẩm, mô tả tham số của từng sản phẩm xem trong bảng tiếp theo
    /// </summary>
    public IList<ProductCreationModel> products { get; set; }
  }
}

