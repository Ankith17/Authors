using AssignAuthor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignAuthor.Controllers
{
    public class AuthorController : Controller
    {
        AuthorContext db = new AuthorContext();
        public ActionResult Index()
        {
            var list = db.Authors.ToList();
            return View(list);
        }

        public ActionResult Insert()
        {
            Authors auth = new Authors();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Authors author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }
        public ActionResult Edit(int? id)
        {
            Authors temp = null;
            if (id != null)
            {
                temp = db.Authors.Find(id);
            }
            return View(temp);
        }
        [HttpPost]
        public ActionResult Edit(int? id, Authors author)
        {
            var list = db.Authors.Where(X => X.AuthorId == id).ToList();
            list.ForEach(x =>
            {
                x.FName = author.FName;
                x.LName = author.LName;
                x.Genre = author.Genre;
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            Authors temp = null;
            if (id != null)
            {
                temp = db.Authors.Find(id);
            }
            return View(temp);
        }
        [HttpPost]
        public ActionResult Delete(Authors author)
        {
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}