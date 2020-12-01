using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagementWebApp.Manager;

namespace BankManagementWebApp.Controllers
{
    public class InfoController : Controller
    {
        private AccountManager accountManager;

        public InfoController()
        {
            accountManager = new AccountManager();
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Info(string acNo)
        {
            if (!accountManager.AcExist(acNo))
            {
                ViewBag.Message = "This AcNo is Not Exist!";
            }
            else
            {
                int bal = accountManager.SearchBalanceByAcNo(acNo);
                ViewBag.Message = "Balance = " + bal;
            }
            return View();
        }
	}
}