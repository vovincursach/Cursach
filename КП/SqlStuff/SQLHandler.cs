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
    public class SQLHandler
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection SqlConnection { get; set; }

        public List<Image> Images { get; set; }

        public string ErrorMessage { get; set; }

        public SQLHandler()
        {
            SqlConnection = new SqlConnection();

            SqlConnection.ConnectionString = ConnectionString;

            SqlConnection.Open();
        }  

        public ArrayList SelectCar(ISqlDataCars searchData)
        {
            var selectCommand = new SqlCommand($"SELECT *, Price - Price*0.1 AS Discount FROM Cars WHERE CarName = '{searchData.Name}' AND Mark = '{searchData.Mark}' AND Color = '{searchData.Color}'", SqlConnection);

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

                        TankVolume = response.GetInt32(8),

                        Discount = response.GetDecimal(9)
                    });
                }
                response.Close();
            }
            return x;
        }

        public ArrayList SelectCarWithoutColor(ISqlDataCars searchData)
        {
            var selectCommand = new SqlCommand($"SELECT *, Price - Price*0.1 AS Discount FROM Cars WHERE CarName = '{searchData.Name}' AND Mark = '{searchData.Mark}'", SqlConnection);

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

                        TankVolume = response.GetInt32(8),

                        Discount = response.GetDecimal(9)
                    });
                }
                response.Close();
            }
            return x;
        }

        public void SaveFileToDatabase(string fileName)
        {
            SqlCommand saveCommand = new SqlCommand("INSERT INTO Images (PhileName, Title, ImageData) VALUES (@PhileName, @Title, @ImageData)", SqlConnection);

            saveCommand.Parameters.Add("@PhileName", SqlDbType.NVarChar, 50);

            saveCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 50);

            saveCommand.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

            string title = fileName;

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

        public void ReadFileFromDatabase(string Name)
        {
            CloseConnection();

            SqlConnection.Open();

            List<Image> images = new List<Image>();

            var selectCommand = new SqlCommand($"SELECT * FROM Images WHERE PhileName = '{Name}'", SqlConnection);

            var reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    string filename = reader.GetString(1);

                    string title = reader.GetString(2);

                    byte[] data = (byte[])reader.GetValue(3);

                    Image image = new Image(id, filename, title, data);

                    images.Add(image);
                }

                reader.Close();
            }

            if(images.Count>0)
            {
                using (FileStream fs = new FileStream(images[0].FileName, FileMode.OpenOrCreate))
                {
                    fs.Write(images[0].Data, 0, images[0].Data.Length);
                }
            }

            Images = images;
        }

        public void CloseConnection()
        {
            SqlConnection.Close();
        }
    }
}