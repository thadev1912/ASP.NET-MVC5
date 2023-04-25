using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using Quanlykhohang.Models;

namespace Quanlykhohang.Controllers
{
    public class VattuController : Controller
    {
        quanlykhoEntities db=new quanlykhoEntities();
        // GET: Vattu
        public ActionResult Index(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
            ViewBag.PageSize = pageSize;
            List<vattu> layds = new List<vattu>();
            layds = db.vattus.ToList();
            return View(layds.ToPagedList((int)page, (int)pageSize));
        }
    

    // GET: Vattu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vattu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vattu/Create
        [HttpPost]
        public ActionResult Create(vattu vt)
        {
            if (ModelState.IsValid)
            {
                db.vattus.Add(vt);
                try
                {
                    db.SaveChanges();

                    
                }
                catch(InvalidCastException e)
                {
                    return View(e);
                }
                return RedirectToAction("Index");
            }
            else
                {
                return View();
                   }
        }

        // GET: Vattu/Edit/5
        public ActionResult Edit(int id)
        {
            vattu layds=new vattu();
            layds=db.vattus.FirstOrDefault(x => x.id == id);    
            return View(layds);
        }

        // POST: Vattu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, vattu vt)
        {
            if (ModelState.IsValid)
            {
                vattu layds=new vattu();    
               layds=db.vattus.FirstOrDefault(m=>m.id== id);
                layds.ma_vt = vt.ma_vt;
                layds.ten_vt = vt.ten_vt; 
                layds.dvt_vt = vt.dvt_vt;
                layds.soluong_vt = vt.soluong_vt;
                layds.loai_vt = vt.loai_vt;

                try
                {
                    db.SaveChanges();


                }
                catch
                {
                   
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }    
            
        }

        // GET: Vattu/Delete/5
        public ActionResult Delete(int id)
        {
            vattu layds=new vattu();
            layds=db.vattus.FirstOrDefault(y=>y.id== id);
            db.vattus.Remove(layds);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Vattu/Delete/5
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
