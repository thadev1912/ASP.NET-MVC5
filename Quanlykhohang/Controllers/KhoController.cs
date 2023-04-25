using Quanlykhohang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using WebGrease.Css.Ast.Selectors;


namespace quanlykho.Controllers

{
    public class KhoController : Controller
    {
        quanlykhoEntities db = new quanlykhoEntities();
        // GET: Kho
        public ActionResult Index(string txt_search, int? page, int? pageSize)
        {

            if (page == null)
            {
                page = 1;

            }
            if (pageSize == null)
            {
                pageSize = 2;

            }
            List<kho> layds = new List<kho>(); // khởi tạo đối tượng mảng từ ds kho gắn vào biến "layds" với kiểu là mảng
            ViewBag.pageSize = pageSize;
            layds = db.khoes.ToList();
            if (txt_search != null)
            {
                layds = db.khoes.Where(m => m.ten_kho.Contains(txt_search)).ToList();
                return View(layds.ToPagedList((int)page, (int)pageSize));
            }

            return View(layds.ToPagedList((int)page, (int)pageSize));
        }

        // GET: Kho/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kho/Create
        [HttpPost]
        public ActionResult Create(kho kh)
        {
            if (ModelState.IsValid) //kiêm tra tính hợp trong validation
            {
                db.khoes.Add(kh);
                try  // không lỗi database sẽ lưu
                {
                    db.SaveChanges();


                }
                catch (InvalidCastException e) // bắn ra lỗi trong add database

                {
                    Console.WriteLine(e);
                }
                return RedirectToAction("Index");
            }
            else  // không hợp lệ chuyển đến view
            {
                return View();
            }
        }

        // GET: Kho/Edit/5
        public ActionResult Edit(int id)
        {
            kho kh = new kho();
            kh = db.khoes.FirstOrDefault(m => m.id == id);
            return View(kh);
        }

        // POST: Kho/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, kho kh)
        {
            if (ModelState.IsValid)
            {
                kho layds = new kho();
                layds = db.khoes.FirstOrDefault(m => m.id == id);
                layds.ma_kho = kh.ma_kho;
                layds.ten_kho = kh.ten_kho;
                layds.loai_kho = kh.loai_kho;
                layds.ghi_chu = kh.ghi_chu;
                try
                {
                    db.SaveChanges();
                }
                catch (InvalidCastException e) // bắn ra lỗi trong add database

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

        // GET: Kho/Delete/5
        public ActionResult Delete(int id)
        {
            kho kh = new kho();
            kh = db.khoes.FirstOrDefault(m => m.id == id);
            db.khoes.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Kho/Delete/5
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
        public ActionResult ajax(string get_data)
        {
            List<kho> layds = new List<kho>();
            layds = db.khoes.Where(m => m.ten_kho.Contains(get_data)).ToList();
            return Json(new
            {
                data = layds,
                totalItem = layds.Count,
                status = 200,
                messege = "Lấy dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
