using Asp.NETMVC_KrutiNayee.DBModel;
using Asp.NETMVC_KrutiNayee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVC_KrutiNayee.Controllers
{
    public class LoginRegisterController : Controller
    {
        mvcDBEntities mvcdb = new mvcDBEntities();
        // GET: LoginRegister
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserRegisterModel userreg = new UserRegisterModel();
            return View(userreg);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userreg)
        {
            if (ModelState.IsValid)
            {
                if (!mvcdb.Users.Any(m => m.emailId == userreg.emailId))
                {
                    User u = new DBModel.User();
                    u.createdOn = DateTime.Now;
                    u.emailId = userreg.emailId;
                    u.firstName = userreg.firstName;
                    u.lastName = userreg.lastName;
                    u.Password = userreg.Password;

                    mvcdb.Users.Add(u);
                    mvcdb.SaveChanges();
                    userreg = new UserRegisterModel();
                    userreg.SuccessMessage = "User Registered Successfully!!!";
                    return RedirectToAction("Login", "LoginRegister");
                }
                else
                {
                    ModelState.AddModelError("Error", "EmailId already exixts!!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            UserLoginModel ulm = new UserLoginModel();
            return View(ulm);
        }

        [HttpPost]
        public ActionResult Login(string emailid, string password)
        {
            using (var mvcdb = new mvcDBEntities())
            {
                var user = mvcdb.Users.FirstOrDefault(u => u.emailId == emailid);
                if (user == null)
                {
                    // User does not exist
                    TempData["ErrorMessage"] = "The user has not registered with us";
                    return View();
                }
                else if (user.Password == password)
                {
                    // Login successful
                    TempData["SuccessMessage"] = "Login Successful!!!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Password is not correct
                    TempData["ErrorMessage"] = "Password is not correct";
                    return View();
                }
            }
            //if (ModelState.IsValid)
            //{
            //    if(mvcdb.Users.Where(m=>m.emailId == ulm.emailId && m.Password == ulm.Password).FirstOrDefault() == null)
            //    {
            //        ModelState.AddModelError("Error", "User has not registered with us.");
            //        return View();
            //    }
            //    else
            //    {
            //        Session["emailId"] = ulm.emailId;
            //        ViewData["messages"] = "Login Successful!!!";
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            
        
        }

    }
}
