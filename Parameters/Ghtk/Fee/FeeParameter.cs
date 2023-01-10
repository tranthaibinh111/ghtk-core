#region DotNet
using System;
using System.ComponentModel.DataAnnotations;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace GhtkCore.Parameters.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#t-nh-ph-v-n-chuy-n
  /// Tham số truy vấn phí vận chuyển
  /// </summary>
  public class FeeParameter
  {
    public string pickAddressId { get; set; }
    public string pickAddress { get; set; }
    [Required(ErrorMessage = "Pick Province is required")]
    public string pickProvince { get; set; }
    [Required(ErrorMessage = "Pick District is required")]
    public string pickDistrict { get; set; }
    public string pickWard { get; set; }
    public string pickStreet { get; set; }
    public string address { get; set; }
    [Required(ErrorMessage = "Province is required")]
    public string province { get; set; }
    [Required(ErrorMessage = "District is required")]
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }
    [Required(ErrorMessage = "Weight is required")]
    [Range(0, Int32.MaxValue, ErrorMessage = "Weight must be greater than 0")]
    public int? weight { get; set; }
    public int? value { get; set; }
    public string transport { get; set; }
  }
}

