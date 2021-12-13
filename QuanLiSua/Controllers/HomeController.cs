﻿using QuanLiSua.Libs;
using QuanLiSua.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSua.Controllers
{
	public class HomeController : Controller
	{
		private ShopSuaEntities db = new ShopSuaEntities();
		public ActionResult Index()
		{
			var t = db.Sua.Where(r => r.SoLuong > 0);
			return View(t);
		}

		public ActionResult ChiTiet(int masp)
		{
			var ChiTiet = (from sp in db.Sua
						   where (sp.ID == masp)

						   select new SuaModel()
						   {
							   ID = masp,
							   TenSua = sp.TenSua,
							   HinhAnhBia = sp.AnhMau,
							   MoTa = sp.MoTa,
							   HangSX = sp.HangSX,
						   }).ToList();

			return View(ChiTiet);
		}
		
		public ActionResult MuaNhieuNhat()
		{
			var ShopPhone = db.DatHang_ChiTiet.Where(r => r.SoLuong > 0).OrderByDescending(r => r.SoLuong).ToList();
			var MuaNhieuNhat = (from sp in db.Sua
								join chitiet in db.DatHang_ChiTiet on sp.ID equals chitiet.Sua_ID
								where (chitiet.SoLuong > 0)
								select new SuaModel()
								{
									TenSua = sp.TenSua,
									HinhAnhBia = sp.AnhMau,
									DonGia = sp.DonGia,
									ID = sp.ID,
									SoLuong = chitiet.SoLuong
								}).OrderByDescending(chitiet => chitiet.SoLuong).ToList();

			return View(MuaNhieuNhat);
		}

		public ActionResult Logout()
		{
			Session.Remove("MaKhachHang");
			Session.Remove("HoTenKhachHang");
			Session.Remove("TenDangNhap");
			return RedirectToAction("Login", "Home");
		}

		public ActionResult Login()
		{
			ModelState.AddModelError("LoginError", "");
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(KhachHangLogin khachHang)
		{
			if (ModelState.IsValid)
			{
				string matKhauMaHoa = SHA1.ComputeHash(khachHang.MatKhau);
				var taiKhoan = db.KhachHang.Where(r => r.TenDangNhap == khachHang.TenDangNhap && r.MatKhau == matKhauMaHoa).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(khachHang);
				}
				else
				{
					// Đăng ký SESSION
					Session["MaKhachHang"] = taiKhoan.ID;
					Session["HoTenKhachHang"] = taiKhoan.HoVaTen;
					Session["TenDangNhap"] = taiKhoan.TenDangNhap;
					// Quay về trang chủ
					return RedirectToAction("Index", "Home");
				}
			}

			return View(khachHang);
		}
		public ActionResult ChangePassword()
		{
			ModelState.AddModelError("ChangePassword", "");
			return View();
		}

		// POST: Home/ChangePassword
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ChangePassword(ChangePassword khachHang)
		{

			if (ModelState.IsValid)
			{

				string matKhauCu = SHA1.ComputeHash(khachHang.MatKhauCu);
				string matKhauMoi = SHA1.ComputeHash(khachHang.MatKhauMoi);
				string xacnhanmatkhau = SHA1.ComputeHash(khachHang.XacNhanMatKhau);
				string tendangnhap = Session["TenDangNhap"].ToString();
				var taiKhoan = db.KhachHang.Where(r => r.TenDangNhap == tendangnhap && r.MatKhau == matKhauCu).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("ChangePassword", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(khachHang);
				}
				else
				{
					if (matKhauMoi == xacnhanmatkhau)
					{
						taiKhoan.MatKhau = matKhauMoi;
						taiKhoan.XacNhanMatKhau = matKhauMoi;
						db.Entry(taiKhoan).State = EntityState.Modified;
						db.SaveChanges();
						ModelState.AddModelError("ChangePasswordSucess", "Đổi mật khẩu thành công");
						return View(khachHang);
					}
				}
			}
			return View(khachHang);
		}


		public ActionResult KhachHangSignUp()
		{
			ModelState.AddModelError("SignUpError", "");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult KhachHangSignUp(KhachHang kh)
		{
			if (ModelState.IsValid)
			{
				var check = db.KhachHang.FirstOrDefault(r => r.TenDangNhap == kh.TenDangNhap);
				if (check == null)
				{
					kh.MatKhau = SHA1.ComputeHash(kh.MatKhau);
					kh.XacNhanMatKhau = SHA1.ComputeHash(kh.XacNhanMatKhau);
					db.Configuration.ValidateOnSaveEnabled = false;
					db.KhachHang.Add(kh);
					db.SaveChanges();
					return RedirectToAction("Login");
				}
				else
				{
					ViewBag.error = "Tên đăng nhập đã tồn tại !!!";
					return View();
				}
			}
			return View();
		}


		public ActionResult ThanhToan()
		{
			if (Session["MaKhachHang"] == null)
			{
				return RedirectToAction("GioHang", "Home");
			}
			else
			{
				return View();
			}
		}

		// POST: Home/ThanhToan
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ThanhToan(DatHang datHang)
		{
			if (ModelState.IsValid)
			{
				// Lưu vào bảng DatHang
				DatHang dh = new DatHang();
				dh.DiaChiGiaoHang = datHang.DiaChiGiaoHang;
				dh.DienThoaiGiaoHang = datHang.DienThoaiGiaoHang;
				dh.NgayDatHang = DateTime.Now;
				dh.KhachHang_ID = Convert.ToInt32(Session["MaKhachHang"]);
				dh.TinhTrang = 0;
				db.DatHang.Add(dh);
				db.SaveChanges();

				// Lưu vào bảng DatHang_ChiTiet
				List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
				foreach (var item in cart)
				{
					DatHang_ChiTiet ct = new DatHang_ChiTiet();

					ct.DatHang_ID = dh.ID;
					ct.Sua_ID = item.sua.ID;
					ct.SoLuong = Convert.ToInt16(item.soLuongTrongGio);
					ct.DonGia = item.sua.DonGia;
					db.DatHang_ChiTiet.Add(ct);
					db.SaveChanges();
				}

				// Xóa giỏ hàng
				cart.Clear();

				// Quay về trang chủ
				return RedirectToAction("Index", "Home");
			}

			return View(datHang);
		}

		/*public ActionResult MyOders()
		{
			/*int makh = Convert.ToInt32(Session["MaKhachHang"].ToString());
			var dh = db.DatHang_ChiTiet.Where(r => r.DatHang.KhachHang_ID == makh && r.DatHang.TinhTrang != 3).ToList();
			return View(dh);*/

		/*int makh = Convert.ToInt32(Session["MaKhachHang"]);
		var DonHangCuaToi = (from sp in db.Sua
							 join chitiet in db.DatHang_ChiTiet on sp.ID equals chitiet.Sua_ID
							 join dhang in db.DatHang on chitiet.DatHang_ID equals dhang.ID
							 join kh in db.KhachHang on dhang.KhachHang_ID equals kh.ID
							 where (kh.ID == makh)

							 select new DonHangCuaToi()
							 {
								 TenSua = sp.TenSua,
								 HinhAnhBia = sp.AnhMau,
								 DonGia = chitiet.DonGia,
								 ID = kh.ID,
								 SoLuong = chitiet.SoLuong,
								 NgayDatHang = dhang.NgayDatHang

							 }).OrderByDescending(dhang => dhang.NgayDatHang).ToList();

		return View(DonHangCuaToi);
	}*/
		[HttpPost]
		public ActionResult Search(FormCollection collection)
		{
			// contains chứa
			string text_search = collection["TuKhoa"].ToString();

			var baikiem_search = db.Sua.Where(r => r.SoLuong > 1 && (r.TenSua.Contains(text_search))).ToList();
			return View(baikiem_search);
		}
	}
}