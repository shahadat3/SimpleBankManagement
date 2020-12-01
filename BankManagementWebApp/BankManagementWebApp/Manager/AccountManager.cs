using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankManagementWebApp.Gateway;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Manager
{
    public class AccountManager
    {
        public AccountGateway accountGateway;

        public AccountManager()
        {
            accountGateway = new AccountGateway();
        }
        public string Save(Account account)
        {
            if (accountGateway.AcExist(account.AcNo))
            {
                return "This Account No Is Already Exist!";
            }
            else
            {
                int rowAffect = accountGateway.Save(account);

                if (rowAffect > 0)
                {
                    return "Account Successfully Created!";
                }

                else
                {
                    return "Account Creation Failed!";
                }
            }
        }

        public int SearchBalanceByAcNo(string acNo)
        {
            return accountGateway.SearchBalanceByAcNo(acNo);
        }

        public List<Account> GetAllInfoById()
        {
            return accountGateway.GetAllInfoById();
        }

        public bool AcExist(string acNo)
        {
            return accountGateway.AcExist(acNo);
        }
    }
}