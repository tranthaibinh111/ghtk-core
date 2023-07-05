#region DotNet
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
  public class OrderCreationModel
  {
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string id { get; set; }

    #region Thông tin điểm lấy hàng
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên người liên hệ lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_name", Required = Required.Always)]
    public string pickName { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số tiền CoD. Nếu bằng 0 thì không thu tiền CoD. Tính theo VNĐ
    /// </summary>
    [JsonProperty(PropertyName = "pick_money", Required = Required.Always)]
    public int? pickMoney { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// ID địa điểm lấy hàng của shop trong trang quản lý đơn hàng dành cho khách hàng. Nếu trường này khác rỗng sẽ được ưu tiên sử dụng
    /// </summary>
    [JsonProperty(PropertyName = "pick_address_id")]
    public string pickAddressId { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Địa chỉ ngắn gọn để lấy nhận hàng hóa.<br />
    /// Ví dụ: nhà số 5, tổ 3, ngách 11, ngõ 45
    /// </summary>
    [JsonProperty(PropertyName = "pick_address", Required = Required.Always)]
    public string pickAddress { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    ///Tên tỉnh/thành phố nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_province", Required = Required.Always)]
    public string pickProvince { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên quận/huyện nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_district", Required = Required.Always)]
    public string pickDistrict { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Tên phường/xã nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_ward")]
    public string pickWard { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Tên đường/phố nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_street")]
    public string pickStreet { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số điện thoại liên hệ nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_tel", Required = Required.Always)]
    public string pickTel { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Email liên hệ nơi lấy hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "pick_email")]
    public string pickEmail { get; set; }
    #endregion

    #region Thông tin điểm giao hàng
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên người nhận hàng
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string name { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Địa chỉ chi tiết của người nhận hàng<br/>
    /// Ví dụ: Chung cư CT1, ngõ 58, đường Trần Bình
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string address { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên tỉnh/thành phố của người nhận hàng hóa
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string province { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Tên quận/huyện của người nhận hàng hóa
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string district { get; set; }
    /// <summary>
    /// Requirement:<br />
    ///     When street is null then Requirement = True<br />
    ///     When street is not null then Requirement = Fase<br />
    /// <br />
    /// Tên phường/xã của người nhận hàng hóa (Bắt buộc khi không có đường/phố)
    /// </summary>
    public string ward { get; set; }
    /// <summary>
    /// Requirement:<br />
    ///     When street is not null then Requirement = True<br />
    ///     When street is null then Requirement = Fase<br />
    /// <br />
    /// Tên đường/phố của người nhận hàng hóa (Bắt buộc khi không có phường/xã)
    /// </summary>
    public string street { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên thôn/ấp/xóm/tổ/… của người nhận hàng hóa<br/>
    /// Nếu không có, vui lòng điền “Khác”
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string hamlet { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số điện thoại người nhận hàng hóa
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string tel { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Ghi chú đơn hàng.<br/>
    /// Từ 24/2/2020 ghi chú tối đa cho phép là 120 kí tự<br/>
    /// Vd: Khối lượng tính cước tối đa: 1.00 kg
    /// </summary>
    public string note { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Email người nhận hàng hóa
    /// </summary>
    public string email { get; set; }
    #endregion

    #region Thông tin điểm trả hàng
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Field này có thể truyền vào một trong hai giá trị 0 hoặc 1.<br/>
    /// Bằng 0 nghĩa là địa chỉ trả hàng giống địa chỉ lấy hàng nên các field địa chỉ trả hàng không cần truyền qua.<br/>
    /// Bằng 1 nghĩa là sử dụng địa chỉ trả hàng khác địa chỉ lấy hàng và cần truyền vào giá trị cho các field tiếp theo.<br/>
    /// <br/>
    /// Mặc định là 0.<br/>
    /// </summary>
    [JsonProperty(PropertyName = "use_return_address")]
    public int usedReturnMoney { get; set; } = 0;
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Tên người nhận hàng trả
    /// </summary>
    [JsonProperty(PropertyName = "return_name")]
    public string returnName { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Địa chỉ chi tiết của người nhận hàng.<br />
    /// Ví dụ: nhà A, ngõ 100
    /// </summary>
    [JsonProperty(PropertyName = "return_address")]
    public string returnAddress { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    ///Tên tỉnh/thành phố của người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_province")]
    public string returnProvince { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Tên quận/huyện của người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_district")]
    public string returnDistrict { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Tên phường/xã của người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_ward")]
    public string returnWard { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Tên đường/phố của người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_street")]
    public string returnStreet { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Số điện thoại người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_tel")]
    public string returnTel { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Email người nhận hàng hóa
    /// </summary>
    [JsonProperty(PropertyName = "return_email")]
    public string returnEmail { get; set; }
    #endregion

    #region Các thông tin thêm
    /// <summary>
    /// Freeship cho người nhận hàng.<br/>
    /// Nếu bằng 1 COD sẽ chỉ thu người nhận hàng số tiền bằng pick_money.<br/>
    /// Nếu bằng 0 COD sẽ thu tiền người nhận số tiền bằng pick_money + phí ship của đơn hàng.<br/>
    /// <br/>
    /// Mặc định bằng 0
    /// </summary>
    [JsonProperty(PropertyName = "is_freeship")]
    public int isFreeship { get; set; } = 0;
    /// <summary>
    /// Đơn vị khối lượng của các sản phẩm có trong gói hàng<br/>
    /// Nhận một trong hai giá trị gram và kilogram.<br/>
    /// <br/>
    /// Mặc định là kilogram.
    /// </summary>
    [JsonProperty(PropertyName = "weight_option")]
    public string weightOption { get; set; } = "kilogram";
    /// <summary>
    /// Tổng khối lượng của đơn hàng.<br/>
    /// <br/>
    /// Mặc định sẽ tính theo products.weight nếu không truyền giá trị này
    /// </summary>
    [JsonProperty(PropertyName = "total_weight")]
    public double? totalWeight { get; set; }
    /// <summary>
    /// Nếu set bằng 3 đơn hàng sẽ lấy vào buổi tối.<br/>
    /// Nếu set bằng 2: đơn hàng sẽ lấy vào buồi chiều.<br/>
    /// Nếu set bằng 1: đơn hàng sẽ lấy vào buổi sáng.<br/>
    /// <br/>
    /// Mặc định GHTK set theo ca tự tính.
    /// </summary>
    [JsonProperty(PropertyName = "pick_work_shift")]
    public int? pickWorkShift { get; set; }
    /// <summary>
    /// Nếu set bằng 3 đơn hàng sẽ được giao vào buổi tối.<br/>
    /// Nếu set bằng 2: đơn hàng sẽ được giao vào buồi chiều.<br/>
    /// Nếu set bằng 1: đơn hàng sẽ được giao vào buổi sáng.<br/>
    /// <br/>
    /// Mặc định GHTK set theo ca tự tính.
    /// </summary>
    [JsonProperty(PropertyName = "deliver_work_shift")]
    public int? deliverWorkShift { get; set; }
    /// <summary>
    /// Mã vận đơn được cấp trước cho đối tác.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    [JsonProperty(PropertyName = "label_id")]
    public string labelId { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD<br/>
    /// Hẹn ngày lấy hàng.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    [JsonProperty(PropertyName = "pick_date")]
    public string pickDate { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD<br/>
    /// Hẹn ngày giao hàng.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    [JsonProperty(PropertyName = "deliver_date")]
    public string deliverDate { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD hh:mm:ss<br/>
    /// Thời gian tự động .<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    public string expired { get; set; }
    /// <summary>
    /// Giá trị đóng bảo hiểm, là căn cứ để tính phí bảo hiểm và bồi thường khi có sự cố.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int? value { get; set; }
    /// <summary>
    /// 1. đơn chỉ thu tiền, 0. default
    /// </summary>
    public int? opm { get; set; } = 0;
    /// <summary>
    /// Nhận một trong hai giá trị cod và post<br/>
    /// <br/>
    /// Mặc định là cod, biểu thị lấy hàng bởi COD hoặc Shop sẽ gửi tại bưu cục.
    /// </summary>
    [JsonProperty(PropertyName = "pick_option")]
    public string pickOption { get; set; } = "cod";
    /// <summary>
    /// Trường này lưu đường vận chuyển của đơn hàng<br/>
    /// Nếu đơn hàng được chuyển bằng đường bộ (road), bạn sẽ nhận được thông báo của GHTK.<br/>
    /// <br/>
    /// Mặc định là đường bay (fly).
    /// </summary>
    [JsonProperty(PropertyName = "actual_transfer_method")]
    public string actualTransferMethod { get; set; }
    /// <summary>
    /// Phương thức vâng chuyển road ( bộ ) , fly (bay).<br/>
    /// Nếu phương thức vận chuyển không hợp lệ thì GHTK sẽ tự động nhảy về PTVC mặc định
    /// </summary>
    public string transport { get; set; }
    /// <summary>
    /// Gía trị là xteam nếu lựa chọn phương thức vận chuyển xfast
    /// </summary>
    [JsonProperty(PropertyName = "deliver_option")]
    public string deliverOption { get; set; }
    /// <summary>
    /// Giá trị lấy từ response của API check dịch vụ XFAST (phiên lấy xfast)
    /// </summary>
    [JsonProperty(PropertyName = "pick_session")]
    public string pickSession { get; set; }
    /// <summary>
    /// Gắn nhãn cho đơn hàng, truyền lên mảng , mô tả tham số của nhãn đơn hàng trong bảng tiếp theo
    /// </summary>
    public IList<string> tags { get; set; }
    #endregion
  }
}

