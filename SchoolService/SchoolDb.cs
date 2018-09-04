using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SchoolService
{
    public class SchoolDb : IDisposable
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly string _connectionString;
        private SqlConnection _connection;

        public SchoolDb()
        {
            _connectionString = "Data Source=WIN-GQOKRARBRRP;Initial Catalog=School;Integrated Security=True";
            _connection = new SqlConnection(_connectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public bool AddStudent(string name)
        {
            string command = $"INSERT INTO Students(StudentName) VALUES('{name}')";
            SqlCommand cmd = new SqlCommand(command, _connection);
            var res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddStudent(Student student)
        {
            string command = $"INSERT INTO Students(StudentName) VALUES('{student.StudentName}')";
            SqlCommand cmd = new SqlCommand(command, _connection);
            var res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetListOfStudents()
        {
            List<Student> listOfStudents = new List<Student>();

            string command = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(command, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listOfStudents.Add(new Student(studentId: (int)reader["StudentId"], studentName: (string)reader["StudentName"]));
            }
            reader.Close();

            return listOfStudents;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}