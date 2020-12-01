using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Gateway
{
    public class WithdrawGateway
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;

        public WithdrawGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["BankManagementConString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Withdraw withdraw)
        {
            string query = "INSERT INTO Withdraw(Date,Ammount,AccountId) Values(@date,@ammount,@accountId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", withdraw.Date);
            command.Parameters.AddWithValue("@ammount", withdraw.Ammount);
            command.Parameters.AddWithValue("@accountId", withdraw.AccountId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}