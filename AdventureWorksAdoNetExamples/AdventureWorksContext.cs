using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdventureWorksAdoNetExamples
{
    public class AdventureWorksContext : IDisposable
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly string _connectionString;
        private SqlConnection _connection;

        public AdventureWorksContext()
        {
            _connectionString = "Data Source=WIN-GQOKRARBRRP;Initial Catalog=AdventureworksDW2016CTP3;Integrated Security=True";
            _connection = new SqlConnection(_connectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public AdventureWorksContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void GetDataFromDimAccountTable()
        {
            string command = "select * from DimAccount";
            SqlCommand cmd = new SqlCommand(command, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["AccountKey"]}.\t{reader["ParentAccountKey"]}, {reader["AccountCodeAlternateKey"]}, {reader["ParentAccountCodeAlternateKey"]}, {reader["AccountDescription"]}, {reader["AccountType"]}, {reader["Operator"]}, {reader["CustomMembers"]}, {reader["ValueType"]}, {reader["CustomMemberOptions"]}\n");
            }
            reader.Close();
        }

        public void GetDataFromDimCurrencyTable()
        {
            string command = "select * from DimCurrency";
            SqlCommand cmd = new SqlCommand(command, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["CurrencyKey"]}.\t{reader["CurrencyAlternateKey"]}, {reader["CurrencyName"]}\n");
            }
            reader.Close();
        }

        public void InsertIntoDimCurrencyTable(DimCurrency dimCurrency)
        {
            string command = $"INSERT INTO DimCurrency(CurrencyAlternateKey, CurrencyName) VALUES('{dimCurrency.CurrencyAlternateKey}', '{dimCurrency.CurrencyName}')";
            SqlCommand cmd = new SqlCommand(command, _connection);
            cmd.ExecuteNonQuery();
        }

        public void GetSearchDataFromDimCurrencyTable(string pattern)
        {
            string command = $"select * from DimCurrency where CurrencyAlternateKey Like '%{pattern}%'";
            SqlCommand cmd = new SqlCommand(command, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["CurrencyKey"]}.\t{reader["CurrencyAlternateKey"]}, {reader["CurrencyName"]}\n");
            }
            reader.Close();
        }

        public void RemoveSearchDataFromDimCurrencyTable(string pattern)
        {
            string command = $"DELETE from DimCurrency where CurrencyAlternateKey Like '%{pattern}%'";
            SqlCommand cmd = new SqlCommand(command, _connection);
            cmd.ExecuteNonQuery();
        }

        public void GetCountOfRowsFromDimCurrency()
        {
            string command = $"SELECT COUNT(*) FROM DimCurrency";
            SqlCommand cmd = new SqlCommand(command, _connection);
            var res = cmd.ExecuteScalar();
            Console.WriteLine("Rows: " + res);
        }

        public void Dispose()
        {
            try
            {
                _connection?.Close();
                _connection?.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}