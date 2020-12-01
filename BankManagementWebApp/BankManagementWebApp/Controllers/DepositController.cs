using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagementWebApp.Manager;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Controllers
{
    public class DepositController : Controller
    {
        private DepositManager depositManager;
        private AccountManager accountManager;

        public DepositController()
        {
            depositManager = new DepositManager();
            accountManager = new AccountManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            //accountManager.SearchBalanceByAcNo(acNo)
            return View();
        }

        [HttpPost]

        public ActionResult Save(Deposit deposit)
        {
            if (!accountManager.AcExist(deposit.AccountId))
            {
                ViewBag.Message = "Wrong! Account No!!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string message = depositManager.Save(deposit);


                    if (message == "Successful")
                    {
                        int bal = accountManager.SearchBalanceByAcNo(deposit.AccountId);
                        ViewBag.Message = "Successful!!!  New Balance Is : " + bal;
                        ModelState.Clear();
                    }
                }

                else
                {
                    ViewBag.Message = "ModelState Is not valid";
                }
            }

            return View();
        }
	}
}