using System.ComponentModel;

namespace web_client.Helpers.Shared;

public enum ReturnCode
{
    [Description("Không có giá trị")]
    NotFound,
    [Description("Thành công")]
    Success,
    [Description("Đã có lỗi xảy ra !")]
    Badrequest,
    [Description("Đã có lỗi từ hệ thống")]
    Exception,
    [Description("Yêu cầu không hợp lệ")]
    RequestInvalid,
    [Description("Lưu thông tin thành công!")]
    SaveSuccess,
    [Description("Không thể lưu thông tin!")]
    SaveFail,
    [Description("Xóa thành công!")]
    DeleteSuccess,
    [Description("Xóa thất bại!")]
    DeleteFail,
    [Description("Tài khoản không tìm thấy !")]
    AccountNotFound,
    [Description("Mật khẩu không hợp lệ !")]
    PasswordWrong,
    [Description("Mã phòng ban đã tồn tại trong hệ thống !")]
    DepartmentExist,
    [Description("Không thể lưu thông tin phòng ban !")]
    DepartmentNotSave,
    [Description("Phải chọn ít nhất một giá trị!")]
    AtLeastOneSelect,
    [Description("Mã khóa học đã tồn tại trên hẹ thống!")]
    CourseExists,
    [Description("Đã tồn tại mã CMND/CCCD!")]
    ExistIdentityCardNumber,
    [Description("Đã tồn tại số xe này!")]
    ExistLicensePlate,
    [Description("Đã tồn tại mã này!")]
    ExistCode,
}