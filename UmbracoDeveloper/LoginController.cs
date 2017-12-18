using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebServices;

namespace UmbracoDeveloper
{
    public class LoginController:SurfaceController
    {
        public const string REG_EXP_VALIDEMAIL = @"(.)*@gmail.com$";
        RegisterEntity user = new RegisterEntity();
    public ActionResult Index()
    {
        return RedirectToAction("Login");
    }
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        string user1 = user.RegisterUsers.Where(s => s.username == username && s.password == password).ToString();
        if (user1 != null)
        {
                List<IPublishedContent> list=CurrentPage.Children.ToList();
                RenderModel model = new RenderModel(list[0]);
                return View(@"~/Views/Home.cshtml",@"~/Views/HomeLayout.cshtml",model);
        }
        else
            ViewBag.InvalidUser = $"Username or password is invalid";
        return View();
    }
    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Register(string username, string password, string email)
    {
        List<RegisterUser> userList = user.RegisterUsers.Where(s => s.username.ToUpper() == username.ToUpper()).ToList();
        if (userList.Count == 0)
        {
            if (ModelState.IsValid && username != null && password != null && ValidateEmail(email))
            {
                RegisterUser addUser = new RegisterUser();
                addUser.email = email;
                addUser.username = username;
                addUser.password = password;
                user.RegisterUsers.Add(addUser);
                user.SaveChanges();
                return RedirectToAction("Login");
            }
            else
                ViewBag.InvalidDetails = "Invalid details";
        }
        else
            ViewBag.InvalidDetails = "UserName is not valid";
        return View();
    }
    public ActionResult ForgotPassword()
    {
        return View();
    }
    [HttpPost]
    public ActionResult ForgotPassword(string email,string password,string cpassword)
    {
        List<RegisterUser> userList = user.RegisterUsers.Where(s => s.email.ToUpper() == email.ToUpper()).ToList();
        if (userList.Count == 1)
        {
            ViewBag.EmailFound = "Valid";

            if (ModelState.IsValid && password == cpassword && password!=null)    //method check data posted cn be used to modify or not
            {
                userList[0].password = password;
                user.Entry(userList[0]).State = EntityState.Modified;
                user.SaveChanges();
                ViewBag.PasswordChange = "Password Successfully changed";
            }
            else
                ViewBag.InvalidPassword = "Password doesnot matches";
        }
        else
        {
            ViewBag.EmailFound = "Invalid  email";
        }
        return View(@"/Views/Login/ForgotPassword.cshtml");
    }
    public Boolean ValidateEmail(string email)
    {
        return Regex.IsMatch(email, REG_EXP_VALIDEMAIL);
    }
}
}