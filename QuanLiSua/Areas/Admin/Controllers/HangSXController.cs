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
    public class HangSXController : Controller
    {
        private ShopSuaEntities db = new ShopSuaEntities();

        // GET: HangSX
        public ActionResult Index()
        {
            return View(db.HangSX.ToList());
        }

        // GET: HangSX/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = db.HangSX.Find(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // GET: HangSX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangSX/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenHangSX")] HangSX hangSX)
        {
            if (ModelState.IsValid)
            {
                db.HangSX.Add(hangSX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangSX);
        }

        // GET: HangSX/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = db.HangSX.Find(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // POST: HangSX/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenHangSX")] HangSX hangSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangSX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangSX);
        }

        // GET: HangSX/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = db.HangSX.Find(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // POST: HangSX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangSX hangSX = db.HangSX.Find(id);
            db.HangSX.Remove(hangSX);
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
