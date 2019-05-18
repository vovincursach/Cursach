using System;
using System.Data.SqlClient;
using System.Configuration;

namespace КП
{
    public class SQLHandler : ISqlCommand
    {

        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static SqlConnection SqlConnection { get; set; }

        public static string ErrorMessage { get; set; }

        static SQLHandler()
        {
            SqlConnection = new SqlConnection();

            SqlConnection.ConnectionString = ConnectionString;

            SqlConnection.Open();
        }

        public void Insert(ISqlData data)
        {
            if (data != null) 
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO Cars (CarName, Mark, Color, Price) VALUES (@carname, @mark, @color, @price)", SqlConnection);

                SqlParameter carNameParam = new SqlParameter("@carname", data.Name);

                SqlParameter carMarkParam = new SqlParameter("@mark", data.Mark);

                SqlParameter carColorParam = new SqlParameter("@color", data.Color);

                SqlParameter carPriceParam = new SqlParameter("@price", data.Price);

                insertCommand.Parameters.AddRange(new[] { carNameParam, carMarkParam, carColorParam, carPriceParam });

                insertCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public void Update(ISqlData data)
        {
            if (data != null)
            {
                SqlCommand updateCommand = new SqlCommand("Update Cars SET Color='Black' WHERE Color='Red'", SqlConnection);

                SqlParameter carNameParam = new SqlParameter("@carname", data.Name);

                SqlParameter carMarkParam = new SqlParameter("@mark", data.Mark);

                SqlParameter carColorParam = new SqlParameter("@color", data.Color);

                SqlParameter carPriceParam = new SqlParameter("@price", data.Price);

                updateCommand.Parameters.AddRange(new[] { carNameParam, carMarkParam, carColorParam, carPriceParam });

                updateCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public void Delete(ISqlData data)
        {
            if (data != null)
            {
                SqlCommand deleteCommand = new SqlCommand($"Delete Cars where CarName = {data.Name}", SqlConnection);

                deleteCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public ISqlData[] Select(string value ,string paramToSelect = null)
        {
            var selectCommand = paramToSelect != null
                ? new SqlCommand($"SELECT * FROM Cars where {paramToSelect} = {value}", SqlConnection)
                : new SqlCommand($"SELECT * FROM Cars", SqlConnection);

            var response = selectCommand.ExecuteReader();

            var result = new ISqlData[response.ToString().Length]; // Поменяю этот метот, оставил так, чтобы оно билдилось

            foreach (var item in response)
            {

            }

            return result;
        }
    }
}
