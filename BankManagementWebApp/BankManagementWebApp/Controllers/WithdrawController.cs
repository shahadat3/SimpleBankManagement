using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManagementWebApp.Manager;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Controllers
{
    public class WithdrawController : Controller
    {
        private WithdrawManager withdrawManager;
        private AccountManager accountManager;

        public WithdrawController()
        {
            withdrawManager = new WithdrawManager();
            accountManager = new AccountManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Save(Withdraw withdraw)
        {
            int baln = accountManager.SearchBalanceByAcNo(withdraw.AccountId);
            if (baln < withdraw.Ammount)
            {
                ViewBag.Message = "Ops!! Insufficient Balance";
            }
            else
            {
                if (!accountManager.AcExist(withdraw.AccountId))
                {
                    ViewBag.Message = "Wrong! Account No!!";
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        string message = withdrawManager.Save(withdraw);


                        if (message == "Successful")
                        {
                            int bal = accountManager.SearchBalanceByAcNo(withdraw.AccountId);
                            ViewBag.Message = "Successful!!!  New Balance Is : " + bal;
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewBag.Message = "ModelState Is not valid";
                        }
                    }

                   
                }
            }

            return View();
        }
	}
}