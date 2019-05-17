using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace КП
{
    static class SQLHandler
    {

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static SqlConnection SqlConnection { get; set; }

        static SQLHandler()
        {
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = ConnectionString;
            SqlConnection.Open();
        }

        public static void Insert(string data)
        {
            var result = data.ToString().Replace(" ", "").Replace(",", " ");
            //SQLHandler.Insert(result);
            Trace.WriteLine(result);
            var x = new[] {data};
            //string[] arr = new string[7];
            //foreach (var item in data)
            //{
            //    if(item == " ")

            //}
            SqlCommand Insert = new SqlCommand($"INSERT INTO Cars (CarName, Mark, Color, Price) VALUES ('{x[0]}', '{x[1]}', '{x[2]}', {x[3]})", SqlConnection);
            Insert.ExecuteNonQuery();
        }

        public static void Update(string data)
        {
            SqlCommand Update = new SqlCommand("UPDATE Cars SET Color='Black' WHERE Color='Red'", SqlConnection);
            Update.ExecuteNonQuery();
        }

        public static void Delete(string data)
        {
            SqlCommand Delete = new SqlCommand("DELETE Cars", SqlConnection);
            Delete.ExecuteNonQuery();
        }

        public static void ReadTable(string data)
        {
            SqlCommand ReadTable = new SqlCommand("SELECT * FROM Cars", SqlConnection);
            SqlDataReader reader =  ReadTable.ExecuteReader();
        }
    }
}
