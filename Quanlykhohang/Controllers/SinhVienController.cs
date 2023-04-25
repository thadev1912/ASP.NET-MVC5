using Microsoft.Ajax.Utilities;
using Quanlykhohang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Web.UI;
using PagedList;

namespace Quanlykhohang.Controllers
{
    public class SinhVienController : Controller
    {
        quanlykhoEntities db=new quanlykhoEntities();

        // GET: SinhVien
        public ActionResult Index(int? page, int? pageSize)
        {
            List<getlopViewModel> layds= new List<getlopViewModel>();
            if (page == null)
            {
                page = 1;

            }
            if (pageSize == null)
            {
                pageSize = 2;

            }

            layds = (from sv in db.sinhviens
                 join lp in db.lophops
                 on sv.ma_lop equals lp.ma_lop
                 join kh in db.khoas
                  on sv.ma_kh equals kh.ma_khoa
                     select new getlopViewModel
                 {
                     Id=sv.id,
                     tensv=sv.ten_sv,
                     masv = sv.ma_sv,
                     tenlop = lp.ten_lop,
                     dia_chi = sv.diachi,
                     tenkhoa = kh.ten_khoa,

                 }).ToList();
          
            return View(layds.ToPagedList((int)page, (int)pageSize));
        }

        // GET: SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SinhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
