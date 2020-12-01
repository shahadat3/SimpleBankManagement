using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagementWebApp.Manager;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Controllers
{
    public class AccountSaveController : Controller
    {
        //
        // GET: /Account/
        private AccountManager accountManager;

        public AccountSaveController()
        {
            accountManager = new AccountManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (ModelState.IsValid)
            {
                string message = accountManager.Save(account);
                ViewBag.Message = message;
                if (message == "Account Successfully Created!")
                {
                    ModelState.Clear();
                }
            }

            else
            {
                ViewBag.Message = "ModelState Is not valid";
            }

            return View();
        }
        public ActionResult Search()
        {
            List<Account> accounts = accountManager.GetAllInfoById();
            return View(accounts);
        }

      
    }
}