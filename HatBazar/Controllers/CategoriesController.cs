using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using HatBazar.Models;

namespace HatBazar.Controllers
{
    public class CategoriesController : Controller
    {
       


            private Hat_Bazar_databaseEntities db = new Hat_Bazar_databaseEntities();

            // GET: AdminCategories
            public ActionResult Index()
            {
                return View(db.Category.ToList());
            }

            // GET: AdminCategories/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Category.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }

            // GET: AdminCategories/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: AdminCategories/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,Name,Parent_id")] Category category)
            {
                if (ModelState.IsValid)
                {
                    db.Category.Add(category);
                    db.SaveChanges();
                               return RedirectToAction("Index", "Product_Information");
            }

                return View(category);
            }

            // GET: AdminCategories/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Category.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }

            // POST: AdminCategories/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,Name,Parent_id")] Category category)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }

            // GET: AdminCategories/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Category.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }

            // POST: AdminCategories/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Category category = db.Category.Find(id);
                db.Category.Remove(category);
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
