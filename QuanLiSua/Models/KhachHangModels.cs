﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiSua.Models
{
    public class KhachHangEdit
    {
        public KhachHangEdit()
        {
        }

        public KhachHangEdit(KhachHang n)
        {
            ID = n.ID;
            HoVaTen = n.HoVaTen;
            DienThoai = n.DienThoai;
            DiaChi = n.DiaChi;
            TenDangNhap = n.TenDangNhap;
            MatKhau = n.MatKhau;
            XacNhanMatKhau = n.XacNhanMatKhau;
        }

        [Display(Name = "Mã KH")]
        public int ID { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được bỏ trống!")]
        public string HoVaTen { get; set; }

        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Điện thoại không được bỏ trống!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không đúng định dạng.")]
        public string DienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống!")]
        public string DiaChi { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }
    }
    public class KhachHangSignUp
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được bỏ trống!")]
        public string HoVaTen { get; set; }

        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Điện thoại không được bỏ trống!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không đúng định dạng.")]
        public string DienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống!")]
        public string DiaChi { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }
    }
    public class KhachHangLogin
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }

    public class ChangePassword
    {
        [Display(Name = "Mật khẩu cũ")]
        [DataType(DataType.Password)]
        public string MatKhauCu { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [DataType(DataType.Password)]
        public string MatKhauMoi { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }
    }

}