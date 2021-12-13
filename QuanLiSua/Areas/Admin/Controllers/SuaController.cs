using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiSua.Models;

namespace QuanLiSua.Areas.Admin.Controllers
{
    public class SuaController : Controller
    {
        private ShopSuaEntities db = new ShopSuaEntities();

        // GET: Admin/Sua
        public ActionResult Index()
        {
            var sua = db.Sua.Include(s => s.HangSX).Include(s => s.LoaiSua);
            return View(sua.ToList());
        }

        // GET: Admin/Sua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            return View(sua);
        }

        // GET: Admin/Sua/Create
        public ActionResult Create()
        {
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX");
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai");
            ModelState.AddModelError("UploadError", "");
            return View();
        }

        // POST: Admin/Sua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HangSX_ID,LoaiSua_ID,TenSua,DonGia,SoLuong,HinhAnhBia,MoTa")] Sua sua)
        {
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX",sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai",sua.LoaiSua_ID);
            if (!ModelState.IsValid)
            {
                if (sua.HinhAnhBia != null)
                {
                    string folder = "Storage/";
                    string fileExtension = Path.GetExtension(sua.HinhAnhBia.FileName).ToLower();

                    // Kiểm tra kiểu
                    var fileTypeSupported = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    if (!fileTypeSupported.Contains(fileExtension))
                    {
                        ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin JPG, PNG, GIF!");
                        return View(sua);
                    }
                    else if (sua.HinhAnhBia.ContentLength > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin từ 2MB trở xuống!");
                        return View(sua);
                    }
                    else
                    {
                        string fileName = Guid.NewGuid().ToString() + fileExtension;
                        string filePath = Path.Combine(Server.MapPath("~/" + folder), fileName);
                        sua.HinhAnhBia.SaveAs(filePath);

                        // Cập nhật đường dẫn vào CSDL
                        sua.AnhMau = folder + fileName;

                        db.Sua.Add(sua);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("UploadError", "Hình ảnh mẫu không được bỏ trống!");
                    return View(sua);
                }

            }
            return View(sua);
        }

        // GET: Admin/Sua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX", sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai", sua.LoaiSua_ID);
            return View(sua);
        }

        // POST: Admin/Sua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HangSX_ID,LoaiSua_ID,TenSua,DonGia,SoLuong,AnhMau,MoTa")] Sua sua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX", sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai", sua.LoaiSua_ID);
            return View(sua);
        }

        // GET: Admin/Sua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            return View(sua);
        }

        // POST: Admin/Sua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sua sua = db.Sua.Find(id);
            db.Sua.Remove(sua);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
