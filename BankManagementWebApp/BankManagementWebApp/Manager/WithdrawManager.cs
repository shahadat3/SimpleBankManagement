using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankManagementWebApp.Gateway;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Manager
{
    public class WithdrawManager
    {
        public WithdrawGateway withdrawGateway;
        public AccountGateway accountGateway;

        public WithdrawManager()
        {

            withdrawGateway = new WithdrawGateway();
            accountGateway = new AccountGateway();
        }

        public string Save(Withdraw withdraw)
        {
            int rowAffect = withdrawGateway.Save(withdraw);
            int affect = accountGateway.WithdrawBalByAcNo(withdraw.Ammount, withdraw.AccountId);

            if (rowAffect != 0 && affect!=0)
            {
                return "Successful";
            }

            else
            {
                return "Failed";
            }
        }
    }
}