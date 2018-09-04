using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Challenge_16_Develop_a_SWF_app_and_perform_Salt_hashing
{
    public class RegisterLoginDb : IDisposable
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private string _connectionString;
        private SqlConnection _connection;

        public RegisterLoginDb()
        {
            _connectionString = @"Data Source=WIN-GQOKRARBRRP;Initial Catalog=RegisterLoginDB;Integrated Security=True";
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public bool RegisterNewUser(AccountInfo accountInfo)
        {
            string command = $"INSERT INTO Accounts VALUES('{accountInfo.Login}','{accountInfo.GetPassHashCode(accountInfo.Pass)}','{accountInfo.Guid}')";
            SqlCommand cmd = new SqlCommand(command, _connection);
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool CheckLogin(AccountInfo accountInfo)
        {
            var receivedAccountInfo = GetUser(accountInfo.Login);
            if (receivedAccountInfo != null)
            {
                return accountInfo.Equals(receivedAccountInfo);
            }
            return false;
        }

        private AccountInfo GetUser(string login)
        {
            string command = $"SELECT HashedPass, GUID FROM Accounts WHERE Login LIKE '{login}'";
            SqlCommand cmd = new SqlCommand(command, _connection);
            AccountInfo receivedAccountInfo = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                bool once = false;
                while (reader.Read())
                {
                    if (once)
                    {
                        throw new Exception("Unexpected error, found several records with the same login, contact support");
                    }
                    receivedAccountInfo = new AccountInfo();
                    receivedAccountInfo.Login = login;
                    receivedAccountInfo.Pass = (string)reader["HashedPass"];
                    receivedAccountInfo.Guid = (string)reader["GUID"];
                    once = true;
                }
            }
            return receivedAccountInfo;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}