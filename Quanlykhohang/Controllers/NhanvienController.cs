using Quanlykhohang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Quanlykhohang.Controllers
{
    public class NhanvienController : Controller
    {
        quanlykhoEntities db = new quanlykhoEntities();
        // GET: Nhanvien
        public ActionResult Index(int? page, int? pageSize)
        {
            if(page == null)
            {
                page = 1;
            }    
            if(pageSize==null)
            {
                pageSize = 2;
            }   
            ViewBag.PageSize = pageSize;
            List<nhanvien> layds= new List<nhanvien>(); 
            layds=db.nhanviens.ToList();
            return View(layds.ToPagedList((int)page,(int)pageSize));
        }

        // GET: Nhanvien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nhanvien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nhanvien/Create
        [HttpPost]
        public ActionResult Create(nhanvien nv)
        {
            if (ModelState.IsValid)
            {
                db.nhanviens.Add(nv);
            
            try
            {
                db.SaveChanges();
                
            }
            catch (InvalidCastException e)
                 {
                     Console.WriteLine(e);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }    
            
        }

        // GET: Nhanvien/Edit/5
        public ActionResult Edit(int id)
        {
           nhanvien layds = new nhanvien();
            layds= db.nhanviens.FirstOrDefault(x => x.id == id);    
            return View(layds);
        }

        // POST: Nhanvien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, nhanvien nv)
        {
            if (ModelState.IsValid)
            {
                nhanvien layds=new nhanvien();  
                layds=db.nhanviens.FirstOrDefault(y => y.id == id);
                layds.ma_nv = nv.ma_nv;
                layds.hoten_nv = nv.hoten_nv;
                layds.gioitinh_nv = nv.gioitinh_nv;
                layds.std_nv = Convert.ToInt32(nv.std_nv); // chuyển string thành số
                layds.diachi_nv = nv.diachi_nv;

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
            { return View(); }
        }

        // GET: Nhanvien/Delete/5
        public ActionResult Delete(int id)
        {
            nhanvien layds = new nhanvien();
            layds=db.nhanviens.FirstOrDefault(x => x.id == id);
            db.nhanviens.Remove(layds);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Nhanvien/Delete/5
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
