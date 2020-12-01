using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankManagementWebApp.Gateway;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Manager
{
    public class DepositManager
    {
        public DepositGateway depositGateway;
        public AccountGateway accountGateway;

        public DepositManager()
        {
            depositGateway = new DepositGateway();
            accountGateway = new AccountGateway();
        }

        public string Save(Deposit deposit)
        {
            int rowAffect = depositGateway.Save(deposit);
            int affect = accountGateway.UpdateBalByAcNo(deposit.Ammount, deposit.AccountId);

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