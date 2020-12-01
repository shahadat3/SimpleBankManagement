using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Gateway
{
    public class DepositGateway
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;

        public DepositGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["BankManagementConString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Deposit deposit)
        {
            string query = "INSERT INTO Deposit(Date,Ammount,AccountId) Values(@date,@ammount,@accountId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", deposit.Date);
            command.Parameters.AddWithValue("@ammount", deposit.Ammount);
            command.Parameters.AddWithValue("@accountId", deposit.AccountId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }



    }
}