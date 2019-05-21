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
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO Cars (CarName, Mark, Color, Price, Fuel, EnginePower, EngineVolume, TankVolume) VALUES (@carname, @mark, @color, @price, @fuel, @enginepower, @enginevolume, @tankvolume)", SqlConnection);

                SqlParameter carNameParam = new SqlParameter("@carname", data.Name);

                SqlParameter carMarkParam = new SqlParameter("@mark", data.Mark);

                SqlParameter carColorParam = new SqlParameter("@color", data.Color);

                SqlParameter carPriceParam = new SqlParameter("@price", data.Price);

                SqlParameter carFuelParam = new SqlParameter("@fuel", data.Fuel);

                SqlParameter carEPParam = new SqlParameter("@enginepower", data.EnginePower);

                SqlParameter carEVParam = new SqlParameter("@enginevolume", data.EngineVolume);

                SqlParameter carTVParam = new SqlParameter("@tankvolume", data.TankVolume);

                insertCommand.Parameters.AddRange(new[] { carNameParam, carMarkParam, carColorParam, carPriceParam, carFuelParam, carEPParam, carEVParam, carTVParam });

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

                SqlParameter carFuelParam = new SqlParameter("@fuel", data.Fuel);

                SqlParameter carEPParam = new SqlParameter("@enginepower", data.EnginePower);

                SqlParameter carEVParam = new SqlParameter("@enginevolume", data.EngineVolume);

                SqlParameter carTVParam = new SqlParameter("@tankvolume", data.TankVolume);

                updateCommand.Parameters.AddRange(new[] { carNameParam, carMarkParam, carColorParam, carPriceParam, carFuelParam, carEPParam, carEVParam, carTVParam });

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
                        Fuel = response.GetString(5),
                        EnginePower = response.GetInt32(6),
                        EngineVolume = response.GetInt32(7),
                        TankVolume = response.GetInt32(8)
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
                        Price = response.GetDecimal(4),
                        Fuel = response.GetString(5),
                        EnginePower = response.GetInt32(6),
                        EngineVolume = response.GetInt32(7),
                        TankVolume = response.GetInt32(8)
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
