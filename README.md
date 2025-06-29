# Weather App

## Giới thiệu

Weather App là ứng dụng dự báo thời tiết được xây dựng bằng ngôn ngữ C# với giao diện WinForms. Ứng dụng cho phép người dùng xem thông tin thời tiết hiện tại và dự báo trong nhiều ngày cho các địa điểm khác nhau, sử dụng API dữ liệu thời tiết trực tuyến.

## Tính năng

- Tra cứu thời tiết hiện tại theo vị trí nhập vào
- Hiển thị dự báo thời tiết chi tiết (nhiệt độ, độ ẩm, tình trạng mây, gió, v.v.)
- Giao diện nhiều form trực quan, dễ sử dụng
- Hỗ trợ thay đổi theme giao diện
- Lưu lại lịch sử tra cứu (nếu có)
- Giao diện tiếng Việt thân thiện

## Cài đặt & Sử dụng

### Yêu cầu

- Windows 7/10/11
- .NET Framework phù hợp (4.7.2 trở lên)
- Visual Studio 2019/2022 (nếu muốn chỉnh sửa mã nguồn)

### Cách chạy ứng dụng

1. Clone repository về máy:
   ```sh
   git clone https://github.com/ntrduc1310/Weather-App.git
   ```
2. Mở file `WeatherForecast.sln` bằng Visual Studio.
3. Nhấn F5 hoặc bấm "Start" để chạy ứng dụng.

### Cấu trúc thư mục

```
Weather-App/
├── WeatherForecast.sln
├── src/
│   ├── WeatherForecast.csproj
│   ├── App.config
│   ├── Program.cs
│   ├── ThemeManager.cs
│   ├── packages.config
│   ├── Forms/
│   │   ├── Form1.cs, Form1.Designer.cs, Form1.resx
│   │   ├── Form2.cs, ...
│   ├── Properties/
│   └── Resources/
├── README.md
├── .gitignore
```

## Công nghệ sử dụng

- C# WinForms
- .NET Framework
- API thời tiết (ví dụ: OpenWeatherMap, WeatherAPI, ...)

## Đóng góp

Mọi ý kiến đóng góp, báo lỗi hoặc đề xuất tính năng mới vui lòng tạo issue hoặc pull request tại:  
https://github.com/ntrduc1310/Weather-App

## Tác giả

- ntrduc1310

---

> *Đồ án môn học - Ứng dụng dự báo thời tiết - C# WinForms*
> 
