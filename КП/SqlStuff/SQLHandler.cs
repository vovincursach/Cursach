using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Data;
using System.Collections.Generic;
using КП.ResponseModels;

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

        public void InsertCars(ISqlDataCars data)
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

        public void UpdateCars(ISqlDataCars data)
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

        public void DeleteCars(ISqlDataCars data)
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

        public ArrayList SelectAllCars()
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
                        
                    });
                }
                response.Close();
            }

            return x;
        }

        public ArrayList SelectAllCars(ISqlDataCars searchData)
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

        public void InsertCustomers(ISqlDataCustomers data)
        {
            if (data != null)
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO Customers VALUES (@firstname, @lastname, @middlename, @phonenumber, @email)", SqlConnection);

                SqlParameter carFirstNameParam = new SqlParameter("@firstname", data.FirstName);

                SqlParameter carLastNameParam = new SqlParameter("@lastname", data.LastName);

                SqlParameter carMiddleNameParam = new SqlParameter("@middlename", data.MiddleName);

                SqlParameter carPhoneNumberParam = new SqlParameter("@phonenumbe", data.PhoneNumber);

                SqlParameter carEmailParam = new SqlParameter("@email", data.Email);


                insertCommand.Parameters.AddRange(new[] { carFirstNameParam, carLastNameParam, carMiddleNameParam, carPhoneNumberParam, carEmailParam });

                insertCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public void UpdateCustomers(ISqlDataCustomers data)
        {
            if (data != null)
            {
                SqlCommand updateCommand = new SqlCommand("Update Customers SET FirstName='Black' WHERE FirstName='Red'", SqlConnection);

                SqlParameter carFirstNameParam = new SqlParameter("@firstname", data.FirstName);

                SqlParameter carLastNameParam = new SqlParameter("@lastname", data.LastName);

                SqlParameter carMiddleNameParam = new SqlParameter("@middlename", data.MiddleName);

                SqlParameter carPhoneNumberParam = new SqlParameter("@phonenumbe", data.PhoneNumber);

                SqlParameter carEmailParam = new SqlParameter("@email", data.Email);

                updateCommand.Parameters.AddRange(new[] { carFirstNameParam, carLastNameParam, carMiddleNameParam, carPhoneNumberParam, carEmailParam });

                updateCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public void DeleteCustomers(ISqlDataCustomers data)
        {
            if (data != null)
            {
                SqlCommand deleteCommand = new SqlCommand($"Delete Cars where CarName = {data.PhoneNumber}", SqlConnection);

                deleteCommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Query is empty");
            }
        }

        public void SaveFileToDatabase(string fileName)
        {
            SqlCommand saveCommand = new SqlCommand();

            saveCommand.CommandText = @"INSERT INTO (PhileName, Title, ImageData)Images VALUES (@PhileName, @Title, @ImageData)";

            saveCommand.Parameters.Add("@PhileName", SqlDbType.NVarChar, 50);

            saveCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 50);

            saveCommand.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

            string title = "";

            byte[] imageData;

            string shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);

            using(FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            saveCommand.Parameters["@PhileName"].Value = shortFileName;

            saveCommand.Parameters["@Title"].Value = title;

            saveCommand.Parameters["@ImageData"].Value = imageData;

            saveCommand.ExecuteNonQuery();
        }

        public void ReadFileFromDatabase()
        {
            List<Image> images = new List<Image>();

            var selectCommand = new SqlCommand($"SELECT * FROM Images", SqlConnection);

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);

                string filename = reader.GetString(1);

                string title = reader.GetString(2);

                byte[] data = (byte[])reader.GetValue(3);

                Image image = new Image(id, filename, title, data);

                images.Add(image);
            }

            if(images.Count>0)
            {
                using (FileStream fs = new FileStream(images[0].FileName, FileMode.OpenOrCreate))
                {
                    fs.Write(images[0].Data, 0, images[0].Data.Length);
                }
            }
        }

        public int DataGridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Cars", SqlConnection);

            DataSet ds = new DataSet();

            return adapter.Fill(ds);

        }

        public void CloseConnection()
        {
            SqlConnection.Close();
        }
    }
}