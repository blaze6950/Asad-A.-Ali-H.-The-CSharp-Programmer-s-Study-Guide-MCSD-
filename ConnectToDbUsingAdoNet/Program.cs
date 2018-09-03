using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDbUsingAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=WIN-GQOKRARBRRP;Initial Catalog=School;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            //string command = "Insert into Student values(1,'Hamza Ali')";
            //SqlCommand cmd = new SqlCommand(command, con);
            //int result = cmd.ExecuteNonQuery();
            //con.Close();
            //if (result > 0)
            //    Console.WriteLine("Data is Inserted");
            //else
            //    Console.WriteLine("Error while inserting");


            //string command = "select count(*) from Student";
            //SqlCommand cmd = new SqlCommand(command, con);
            //var noOfStudents = cmd.ExecuteScalar();
            //con.Close();
            //Console.WriteLine(noOfStudents);

            //string command = "select * from Student";
            //SqlCommand cmd = new SqlCommand(command, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //int StudentID = 0;
            //string StudentName = null;
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        StudentID = int.Parse(reader[0].ToString());//0 index means first clm in the table which is StudentID
            //        StudentName = reader["StudentName"].ToString();//it will fetch the value of provided clm name
            //        Console.WriteLine("ID is: " + StudentID);
            //        Console.WriteLine("Name is: " + StudentName);
            //    }
            //}
            //reader.Close();
            //con.Close();


            string command = "select * from Student";
            SqlDataAdapter ad = new SqlDataAdapter(command, con);
            DataTable tbl = new DataTable();
            ad.Fill(tbl);//Now the data in DataTable (memory)
            con.Close();//connection closed
            foreach (DataRow item in tbl.Rows)
            {
                Console.WriteLine("ID is: " + item[0]);
                Console.WriteLine("Name is: " + item[1]);
            }
        }
    }
}
