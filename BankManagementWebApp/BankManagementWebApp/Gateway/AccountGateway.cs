using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BankManagementWebApp.Models;

namespace BankManagementWebApp.Gateway
{
    public class AccountGateway
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;

        public AccountGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["BankManagementConString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Account account)
        {
            string query =
                "INSERT INTO CreateAc(Name,ContactNo,Address,AcNo,Date,Balance) VALUES(@name,@contactNo,@address,@acNo,@date,@balance)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", account.Name);
            command.Parameters.AddWithValue("@contactNo", account.ContactNo);
            command.Parameters.AddWithValue("@address", account.Address);
            command.Parameters.AddWithValue("@acNo", account.AcNo);
            command.Parameters.AddWithValue("@date", account.Date);
            command.Parameters.AddWithValue("@balance", account.Balance);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool AcExist(string acNo)
        {
            string query = "SELECT * FROM CreateAc WHERE AcNo = @acNo";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@acNo", acNo);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public int SearchBalanceByAcNo(string acNo)
        {
            string query = "SELECT Balance FROM CreateAc WHERE AcNo = @acNo";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@acNo", acNo);
            connection.Open();
            reader = command.ExecuteReader();
            int balance = 0;
            while (reader.Read())
            {
                balance = (int)reader["Balance"];
            }
            connection.Close();
            return balance;
        }
        public int UpdateBalByAcNo(int bal, string acNo)
        {
            string query = "UPDATE CreateAc SET Balance+=@bal Where AcNo=@acNo";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@bal", bal);
            command.Parameters.AddWithValue("@acNo", acNo);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }

        public int WithdrawBalByAcNo(int bal, string acNo)
        {
            string query = "UPDATE CreateAc SET Balance-=@bal Where AcNo=@acNo";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@bal", bal);
            command.Parameters.AddWithValue("@acNo", acNo);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }

        public List<Account> GetAllInfoById()
        {
            string query = "SELECT * FROM CreateAc";
            command = new SqlCommand(query,connection);
            
            connection.Open();
            reader = command.ExecuteReader();
            List<Account> accountList = new List<Account>();

            while (reader.Read())
            {
              
                Account account = new Account();
                account.Name = reader["Name"].ToString();
                account.ContactNo = reader["AcNo"].ToString();
                account.Address = reader["Address"].ToString();
                account.AcNo = reader["ContactNo"].ToString();
                account.Date = reader["Date"].ToString();
                
                account.Balance = Convert.ToInt32(reader["Balance"]);
                
                accountList.Add(account);
                
            }

            reader.Close();
            connection.Close();

            return accountList;
        }

    }
}