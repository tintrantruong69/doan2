using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiSua.Models;

namespace QuanLiSua.Areas.Admin.Controllers
{
    public class LoaiSuaController : Controller
    {
        private ShopSuaEntities db = new ShopSuaEntities();

        // GET: LoaiSua
        public ActionResult Index()
        {
            return View(db.LoaiSua.ToList());
        }

        // GET: LoaiSua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSua.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // GET: LoaiSua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoai")] LoaiSua loaiSua)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSua.Add(loaiSua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSua);
        }

        // GET: LoaiSua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSua.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // POST: LoaiSua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoai")] LoaiSua loaiSua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSua);
        }

        // GET: LoaiSua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSua.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // POST: LoaiSua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSua loaiSua = db.LoaiSua.Find(id);
            db.LoaiSua.Remove(loaiSua);
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
