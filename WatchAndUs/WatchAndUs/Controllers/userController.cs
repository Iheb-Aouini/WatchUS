using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAndUs.Models;

namespace WatchAndUs.Controllers
{
    public class userController : Controller
    {
        myDBContext myDb = new myDBContext();
        // GET: user
       [HttpGet]
        public ActionResult SignIn()
        {
            if (Session["username"]==null){
                return View("SignIn");
                    }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult SignIn(user myuser)
        {
            watchEntities1 dbb = new watchEntities1();
           // dbb.users
            user check;
            String hashed = Hash.ComputeSha256Hash(myuser.passwordHash);
            myuser.passwordHash = hashed;
            check = (from xyz in myDb.users
                     where xyz.email == myuser.email && xyz.passwordHash == myuser.passwordHash select xyz).FirstOrDefault();
            if (check == null)
            {
                return View("SignIn");
            }
            else
            {
                ViewData["mes"] = "hel^p me";
                Session["username"] = check.fullName;
              //  Console.WriteLine(Session["username"]);
                return View("Signup");
                
            }
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(user myuser)
        {
            /*user myuser = new user();
            myuser.email = "ihebaouini7@gmail.com";
            myuser.passwordHash = "testwalid123";
            myuser.fullName = "houbatoubas";
            myDb.users.Add(myuser);
            myDb.SaveChanges();
            */
            String hashed = Hash.ComputeSha256Hash(myuser.passwordHash);
            myuser.passwordHash = hashed;
            if (isDuplicate(myuser.email) == false)
            {
                myDb.users.Add(myuser);
                myDb.SaveChanges();
                return RedirectToAction("SignIn");
            }
            else
            {
                ViewData["error"] = "Your Email is used  ";  //this message is only accessible via the signup view 5ater heya li returnitha fel le5er
                return View("SignUp");
            }
        }

        public bool isDuplicate(String email)
        {

            user check = (from xyz in myDb.users
                     where xyz.email == email 
                     select xyz).FirstOrDefault();
            if (check == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("SignIn");
        }
    }
}