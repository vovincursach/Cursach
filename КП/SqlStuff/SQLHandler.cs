using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace КП
{
    public class SQLHandler : ISqlCommand
    {

        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection SqlConnection { get; set; }

        public string ErrorMessage { get; set; }

        public SQLHandler()
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

        public ArrayList SelectAll()
        {
            var selectCommand = new SqlCommand($"SELECT * FROM Cars", SqlConnection);

            var response = selectCommand.ExecuteReader();

            ArrayList x = new ArrayList();

            if (response.HasRows)
            {
                while (response.Read())
                {
                    x.Add(new CarModel
                    {
                        Name = response.GetString(1),
                        Mark = response.GetString(2),
                        Color = response.GetString(3),
                        Price = response.GetDecimal(4),
                        //Image = response.GetBytes(5) for future
                    });
                }
                response.Close();
            }

            return x;
        }

        public ArrayList SelectAll(ISqlData searchData)
        {
            var selectCommand = new SqlCommand($"SELECT * FROM Cars where Name = {searchData.Name} and Price = {searchData.Price}", SqlConnection);

            var response = selectCommand.ExecuteReader();

            ArrayList x = new ArrayList();

            if (response.HasRows)
            {
                while (response.Read())
                {
                    x.Add(new CarModel
                    {
                        Name = response.GetString(1),
                        Mark = response.GetString(2),
                        Color = response.GetString(3),
                        Price = response.GetDecimal(4)
                    });
                }
                response.Close();
            }

            return x;
        }

        public void CloseConnection()
        {
            SqlConnection.Close();
        }
    }
}
