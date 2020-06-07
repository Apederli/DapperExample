using Dapper.Business;
using Dapper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dapper.UI.Controllers
{
    public class HomeController : Controller
    {
        UserManager userManager = new UserManager();
        public ActionResult Index()
        {
            var result = userManager.list().ToList();
            return View(result);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            var result = new User
            {
                Name = model.Name,
                Surname = model.Surname
            };
            userManager.Insert(result);

            return RedirectToAction("Index", model);
        }
       
        public ActionResult Delete(User model)
        {
            userManager.Delete(model);
            return RedirectToAction("Index", model);
        }

        public ActionResult Update(int id)
        {
            var result= userManager.Get(id);
            
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(User model)
        {
            
            userManager.Update(model);
            return RedirectToAction("Index");
        }
    }
}