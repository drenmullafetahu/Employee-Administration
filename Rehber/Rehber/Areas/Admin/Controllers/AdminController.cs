using Rehber.Areas.Admin.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Rehber.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Departman> Departman { get; set; }
        public IEnumerable<Role> Role { get; set; }
        RehberEntities1 dc = new RehberEntities1();
        //
        // GET: /Admin/Admin/
        private RehberEntities1 db = new RehberEntities1();
        private static string UserKey = "Rehber.User";

        public ActionResult Index(User u)
        {
            return View(
              Users = db.Users.ToList());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(UsersNew form)
        {
            //RehberEntities1 db = new RehberEntities1();
            //ViewBag.Departemnts = new SelectList(db.Departmen, "id", "Name");

            if (dc.Users.Where(x => x.Username == form.Username).Count() > 0)
            {
                ModelState.AddModelError("username", "Usernames must me unique");
            }


            if (!ModelState.IsValid)
            {
                return View(form);
            }


            var user = new User()
            {
                Username = form.Username,
                Password = form.Password,
                Isim = form.Isim,
                Soyisim = form.Soyisim,
                Telefon = form.Telefon,
                Departman = form.Departman,
                Rol = form.Rol


            };
            var role = new Role()
            {
                name = form.Rol
            };
            dc.Users.Add(user);

            dc.SaveChanges();

            return RedirectToAction("index");

        }
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(user);
           
        }
        public ActionResult ResetPassword(int id)
        {
            User user = db.Users.Find(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult ResetPassword(UsersResetPassword user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(user);
           
        }
        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);

            return View(user);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        
       
    }
}
