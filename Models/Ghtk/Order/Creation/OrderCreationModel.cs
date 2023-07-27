#region DotNet
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
#endregion

#region Package (third-party)
using AutoMapper;
#endregion

#region GHTK
// Enumerates
using GhtkCore.Enumerates.Ghtk;

// Interface
using GhtkCore.Interfaces.Models.Ghtk;
#endregion

namespace GhtkCore.Models.Ghtk
{
  /// <summary>
  /// https://docs.giaohangtietkiem.vn/?http#ng-n-h-ng
  /// Tham số khởi tạo đơn giao hàng tiết kiệm
  /// </summary>
  public class OrderCreationModel: IOrderCreationModel
  {
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Mã đơn hàng thuộc hệ thống của đối tác
    /// </summary>
    public string id { get; set; }

    #region Thông tin điểm lấy hàng
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên người liên hệ lấy hàng hóa
    /// </summary>
    public string pickName { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số tiền CoD. Nếu bằng 0 thì không thu tiền CoD. Tính theo VNĐ
    /// </summary>
    public int pickMoney { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// ID địa điểm lấy hàng của shop trong trang quản lý đơn hàng dành cho khách hàng. Nếu trường này khác rỗng sẽ được ưu tiên sử dụng
    /// </summary>
    public string pickAddressId { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Địa chỉ ngắn gọn để lấy nhận hàng hóa.<br />
    /// Ví dụ: nhà số 5, tổ 3, ngách 11, ngõ 45
    /// </summary>
    public string pickAddress { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên tỉnh/thành phố nơi lấy hàng hóa
    /// </summary>
    public string pickProvince { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên quận/huyện nơi lấy hàng hóa
    /// </summary>
    public string pickDistrict { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Tên phường/xã nơi lấy hàng hóa
    /// </summary>
    public string pickWard { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Tên đường/phố nơi lấy hàng hóa
    /// </summary>
    public string pickStreet { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số điện thoại liên hệ nơi lấy hàng hóa
    /// </summary>
    public string pickTel { get; set; }
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Email liên hệ nơi lấy hàng hóa
    /// </summary>
    public string pickEmail { get; set; }
    #endregion

    #region Thông tin điểm giao hàng
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên người nhận hàng
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Địa chỉ chi tiết của người nhận hàng<br/>
    /// Ví dụ: Chung cư CT1, ngõ 58, đường Trần Bình
    /// </summary>
    public string address { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Tên tỉnh/thành phố của người nhận hàng hóa
    /// </summary>
    public string province { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Tên quận/huyện của người nhận hàng hóa
    /// </summary>
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
    public string hamlet { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Số điện thoại người nhận hàng hóa
    /// </summary>
    public string tel { get; set; }
    /// DateTime: 2021-11-24 00:38
    ///
    /// Author: BinhTT
    ///
    /// Update: Giao hàng một phần
    /// <summary>
    /// Requirement: False<br />
    /// <br />
    /// Giao hàng một phần
    /// </summary>
    public int? isPartDeliver { get; set; } = 0;
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
    public int? usedReturnAddress { get; set; } = 0;
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Tên người nhận hàng trả
    /// </summary>
    public string returnName { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Địa chỉ chi tiết của người nhận hàng.<br />
    /// Ví dụ: nhà A, ngõ 100
    /// </summary>
    public string returnAddress { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    ///Tên tỉnh/thành phố của người nhận hàng hóa
    /// </summary>
    public string returnProvince { get; set; }
    /// <summary>
    /// Requirement<br />
    ///     When use_return_address == 1 then Requirement = True<br />
    ///     When use_return_address == 0 then Requirement = Fase<br />
    /// <br />
    /// Tên quận/huyện của người nhận hàng hóa
    /// </summary>
    public string returnDistrict { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Tên phường/xã của người nhận hàng hóa
    /// </summary>
    public string returnWard { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Tên đường/phố của người nhận hàng hóa
    /// </summary>
    public string returnStreet { get; set; }
    /// <summary>
    /// Requirement: True
    /// <br />
    /// Số điện thoại người nhận hàng hóa
    /// </summary>
    public string returnTel { get; set; }
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Email người nhận hàng hóa
    /// </summary>
    public string returnEmail { get; set; }
    #endregion

    #region Các thông tin thêm
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Freeship cho người nhận hàng.<br/>
    /// Nếu bằng 1 COD sẽ chỉ thu người nhận hàng số tiền bằng pick_money.<br/>
    /// Nếu bằng 0 COD sẽ thu tiền người nhận số tiền bằng pick_money + phí ship của đơn hàng.<br/>
    /// <br/>
    /// Mặc định bằng 0
    /// </summary>
    public int? isFreeship { get; set; } = 0;
    /// <summary>
    /// Requirement: False
    /// <br />
    /// Đơn vị khối lượng của các sản phẩm có trong gói hàng<br/>
    /// Nhận một trong hai giá trị gram và kilogram.<br/>
    /// <br/>
    /// Mặc định là kilogram.
    /// </summary>
    public string weightOption { get; set; } = "kilogram";
    /// <summary>
    /// Tổng khối lượng của đơn hàng.<br/>
    /// <br/>
    /// Mặc định sẽ tính theo products.weight nếu không truyền giá trị này
    /// </summary>
    public double? totalWeight { get; set; }
    /// <summary>
    /// Nếu set bằng 3 đơn hàng sẽ lấy vào buổi tối.<br/>
    /// Nếu set bằng 2: đơn hàng sẽ lấy vào buổi chiều.<br/>
    /// Nếu set bằng 1: đơn hàng sẽ lấy vào buổi sáng.<br/>
    /// <br/>
    /// Mặc định GHTK set theo ca tự tính.
    /// </summary>
    public int? pickWorkShift { get; set; }
    /// <summary>
    /// Nếu set bằng 3 đơn hàng sẽ được giao vào buổi tối.<br/>
    /// Nếu set bằng 2: đơn hàng sẽ được giao vào buổi chiều.<br/>
    /// Nếu set bằng 1: đơn hàng sẽ được giao vào buổi sáng.<br/>
    /// <br/>
    /// Mặc định GHTK set theo ca tự tính.
    /// </summary>
    public int? deliverWorkShift { get; set; }
    /// <summary>
    /// Mã vận đơn được cấp trước cho đối tác.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    public string labelId { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD<br/>
    /// Hẹn ngày lấy hàng.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    public string pickDate { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD<br/>
    /// Hẹn ngày giao hàng.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    public string deliverDate { get; set; }
    /// <summary>
    /// Format: YYYY/MM/DD hh:mm:ss<br/>
    /// Thời gian tự động.<br/>
    /// <br/>
    /// Mặc định không sử dụng được field này, cấu hình riêng cho từng gói dịch vụ.
    /// </summary>
    public string expired { get; set; }
    /// <summary>
    /// Requirement: True<br />
    /// <br />
    /// Giá trị đóng bảo hiểm, là căn cứ để tính phí bảo hiểm và bồi thường khi có sự cố.
    /// </summary>
    public int value { get; set; }
    /// <summary>
    /// 1. đơn chỉ thu tiền, 0. default
    /// </summary>
    public int? opm { get; set; } = 0;
    /// <summary>
    /// Nhận một trong hai giá trị cod và post<br/>
    /// <br/>
    /// Mặc định là cod, biểu thị lấy hàng bởi COD hoặc Shop sẽ gửi tại bưu cục.
    /// </summary>
    public string pickOption { get; set; } = PickEnum.Shop;
    /// <summary>
    /// Trường này lưu đường vận chuyển của đơn hàng<br/>
    /// Nếu đơn hàng được chuyển bằng đường bộ (road), bạn sẽ nhận được thông báo của GHTK.<br/>
    /// <br/>
    /// Mặc định là đường bay (fly).
    /// </summary>
    public string actualTransferMethod { get; set; } = TransportEnum.Fly;
    /// <summary>
    /// Phương thức vận chuyển road ( bộ ) , fly (bay).<br/>
    /// Nếu phương thức vận chuyển không hợp lệ thì GHTK sẽ tự động nhảy về PTVC mặc định
    /// </summary>
    public string transport { get; set; }
    /// <summary>
    /// Gía trị là xteam nếu lựa chọn phương thức vận chuyển xfast
    /// </summary>
    public string deliverOption { get; set; }
    /// <summary>
    /// Giá trị lấy từ response của API check dịch vụ XFAST (phiên lấy xfast)
    /// </summary>
    public string pickSession { get; set; }
    /// <summary>
    /// Gắn nhãn cho đơn hàng, truyền lên mảng , mô tả tham số của nhãn đơn hàng trong bảng tiếp theo
    /// </summary>
    public IList<int> tags { get; set; }
    #endregion

    #region Generates
    public ExpandoObject generateGhtk()
    {
      try
      {
        var otherAddress = "Khác";
        dynamic data = new ExpandoObject();

        // Mã đơn hàng thuộc hệ thống của đối tác
        data.id = id;

        #region Thông tin điểm lấy hàng
        // Tên người liên hệ lấy hàng hóa
        data.pick_name = pickName;
        // Số tiền CoD
        data.pick_money = pickMoney;

        // ID địa điểm lấy hàng của shop trong trang quản lý đơn hàng dành cho khách hàng
        if (!String.IsNullOrEmpty(pickAddressId))
          data.pick_address_id = pickAddressId;

        // Địa chỉ ngắn gọn để lấy nhận hàng hóa
        data.pick_address = pickAddress;
        // Tên tỉnh/thành phố nơi lấy hàng hóa
        data.pick_province = pickProvince;
        // Tên quận/huyện nơi lấy hàng hóa
        data.pick_district = pickDistrict;

        /// DateTime: 2023-07-06 11:36
        /// 
        /// Author: BinhTT
        ///
        /// Fix bug: Bắt buộc
        if (String.IsNullOrEmpty(pickWard) && String.IsNullOrEmpty(pickStreet))
          data.pick_ward = otherAddress;
        else
        {
          // Tên phường/xã nơi lấy hàng hóa
          if (!String.IsNullOrEmpty(pickWard))
            data.pick_ward = pickWard;

          // Tên đường/phố nơi lấy hàng hóa
          if (!String.IsNullOrEmpty(pickStreet))
            data.pick_street = pickWard;
        }

        // Số điện thoại liên hệ nơi lấy hàng hóa
        data.pick_tel = pickTel;

        if (!String.IsNullOrEmpty(pickEmail))
          data.pick_email = pickEmail;
        #endregion

        #region Thông tin điểm giao hàng
        // Tên người nhận hàng
        data.name = name;
        // Địa chỉ chi tiết của người nhận hàng
        data.address = address;
        // Tên tỉnh/thành phố của người nhận hàng hóa
        data.province = province;
        // Tên quận/huyện của người nhận hàng hóa
        data.district = district;

        /// DateTime: 2023-07-06 11:36
        ///
        /// Author: BinhTT
        ///
        /// Fix bug
        /// Tên phường/xã của người nhận hàng hóa (Bắt buộc khi không có đường/phố)
        /// Tên đường/phố của người nhận hàng hóa (Bắt buộc khi không có phường/xã)
        if (String.IsNullOrEmpty(ward) && String.IsNullOrEmpty(street))
          data.ward = otherAddress;
        else
        {
          // Tên phường/xã của người nhận hàng hóa
          if (!String.IsNullOrEmpty(ward))
            data.ward = ward;

          // Tên đường/phố của người nhận hàng hóa
          if (!String.IsNullOrEmpty(street))
            data.street = street;
        }

        /// DateTime: 2021-11-20 12:58
        ///
        /// Author: BinhTT
        ///
        /// Update Version 1.5.4
        /// Trường hợp một số địa chỉ cấp độ 4 không có trường hợp "Khác"
        if (String.IsNullOrEmpty(hamlet))
          data.hamlet = otherAddress;
        else
          data.hamlet = hamlet;

        // Số điện thoại người nhận hàng hóa
        data.tel = tel;

        /// DateTime: 2021-11-24 00:38
        ///
        /// Author: BinhTT
        ///
        /// Giao hàng một phần
        data.is_part_deliver = isPartDeliver;

        // Ghi chú đơn hàng
        if (!String.IsNullOrEmpty(note))
          data.note = note;

        // Email người nhận hàng hóa
        if (!String.IsNullOrEmpty(email))
          data.email = email;
        #endregion

        #region Thông tin điểm trả hàng
        data.use_return_address = usedReturnAddress;

        // Sử dụng địa chỉ trả hàng khác địa chỉ lấy hàng
        if (usedReturnAddress == 1)
        {
          // Tên người nhận hàng trả
          data.return_name = returnName;
          data.return_address = returnAddress;
          data.return_province = returnProvince;
          data.return_district = returnDistrict;

          /// DateTime: 2023-07-06 11:36
          ///
          /// Author: BinhTT
          ///
          /// Fix bug
          /// Tên phường/xã của người nhận hàng hóa (Bắt buộc khi không có đường/phố)
          /// Tên đường/phố của người nhận hàng hóa (Bắt buộc khi không có phường/xã)
          if (String.IsNullOrEmpty(returnWard) && String.IsNullOrEmpty(returnStreet))
            data.return_ward = otherAddress;
          else
          {
            // Tên phường/xã của người nhận hàng hóa
            if (!String.IsNullOrEmpty(returnWard))
              data.return_ward = returnWard;

            // Tên đường/phố của người nhận hàng hóa
            if (!String.IsNullOrEmpty(returnStreet))
              data.return_street = returnStreet;
          }

          // Số điện thoại người nhận hàng hóa
          data.return_tel = returnTel;

          // Email người nhận hàng hóa
          if (!String.IsNullOrEmpty(returnEmail))
            data.return_email = returnEmail;
        }
        #endregion

        #region Các thông tin thêm
        // Freeship cho người nhận hàng
        data.is_freeship = isFreeship;

        // Đơn vị khối lượng của các sản phẩm có trong gói hàng
        data.weight_option = weightOption;

        // Tổng khối lượng của đơn hàng
        if (totalWeight.HasValue)
          data.total_weight = totalWeight;

        // Buổi sẽ lấy hàng
        if (pickWorkShift.HasValue)
          data.pick_work_shift = pickWorkShift.Value;

        // Buổi sẽ giao hàng
        if (deliverWorkShift.HasValue)
          data.deliver_work_shift = deliverWorkShift;

        // Mã vận đơn được cấp trước cho đối tác
        if (!String.IsNullOrEmpty(labelId))
          data.label_id = labelId;

        // Hẹn ngày lấy hàng
        if (!String.IsNullOrEmpty(pickDate))
          data.pick_date = pickDate;

        // Hẹn ngày giao hàng
        if (!String.IsNullOrEmpty(deliverDate))
          data.deliver_date = deliverDate;

        // Thời gian tự động
        if (!String.IsNullOrEmpty(expired))
          data.expired = expired;

        // Giá trị đóng bảo hiểm
        data.value = value;

        // Đơn có thu tiền hay không
        data.opm = opm;

        // Lấy hàng bởi COD hoặc Shop sẽ gửi tại bưu cục
        data.pick_option = pickOption;

        // Lưu đường vận chuyển của đơn hàng
        if (!String.IsNullOrEmpty(transport))
          data.actual_transfer_method = transport;
        else
          data.actual_transfer_method = actualTransferMethod;

        // Phương thức vận chuyển
        if (!String.IsNullOrEmpty(transport))
          data.transport = transport;

        // Phương thức vận chuyển xfast
        if (!String.IsNullOrEmpty(deliverOption))
          data.deliver_option = deliverOption;

        // Giá trị lấy từ response của API check dịch vụ XFAST
        if (!String.IsNullOrEmpty(pickSession))
          data.pick_session = pickSession;

        // Gắn nhãn cho đơn hàng
        if (tags != null && tags.Any())
          data.tags = tags;
        #endregion

        return data;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }
    #endregion

    #region Map
    public static OrderCreationModel map<T>(T source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<T, OrderCreationModel>()
      );

      var map = new Mapper(config);
      var result = map.Map<T, OrderCreationModel>(source);
      #endregion

      #region Cập nhật các giá trị mặc định
      // Giao hàng một phần
      if (!result.isPartDeliver.HasValue)
        result.isPartDeliver = 0;

      // Trả hàng giống địa chỉ lấy hàng
      if (!result.usedReturnAddress.HasValue)
        result.usedReturnAddress = 0;

      // Freeship cho người nhận hàng
      if (!result.isFreeship.HasValue)
        result.isFreeship = 0;

      // Đơn vị khối lượng của các sản phẩm có trong gói hàng
      if (String.IsNullOrEmpty(result.weightOption))
        result.weightOption = "kilogram";

      // Đơn chỉ thu tiền
      if (!result.opm.HasValue)
        result.opm = 0;

      // Địa điểm lấy hàng
      if (String.IsNullOrEmpty(result.pickOption))
        result.pickOption = PickEnum.Shop;

      // Lưu đường vận chuyển của đơn hàng
      if (String.IsNullOrEmpty(result.actualTransferMethod))
      {
        if (!String.IsNullOrEmpty(result.transport))
          result.actualTransferMethod = result.transport;
        else
          result.actualTransferMethod = TransportEnum.Fly;
      }
      #endregion

      return result;
    }
    #endregion
  }
}

