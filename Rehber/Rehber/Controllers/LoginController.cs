using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rehber.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private RehberEntities1 db = new RehberEntities1();
        private static string UserKey = "Rehber.User";
        public ActionResult login()
        {
            return View("login");
        }

        
        [HttpPost]
        public ActionResult login(User u, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (RehberEntities1 dc = new RehberEntities1())
                {
                    
                    var v = dc.Users.Where(x => x.Username.Equals(u.Username) && x.Password.Equals(u.Password)).FirstOrDefault();
                    if (v == null)
                    {
                        //Session["LogedUserID"] = v.UserId.ToString();
                        ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(u.Username,true);
                        if(Url.IsLocalUrl(returnUrl) && returnUrl.Length>1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")&&!returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("AfterLogin");
                        }
                    }
                    
                }
            }
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] == null)
            {
                return View(db.Users.ToList());
            }
            else
            {
                return Content("su bo :(");
            }

            
           
        }

        public ActionResult RedirectToDefault()
        {
            string[] roles = Roles.GetRolesForUser();
            if (roles.Contains("Administrator"))
            {
                return RedirectToAction("index", "Admin");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
       
    }
}
