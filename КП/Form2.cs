using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КП
{
    public partial class Form2 : Form
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection SqlConnection { get; set; }

        int pageSize = 10;
        
        int pageNumber = 0;  

        DataSet ds;

        SqlDataAdapter adapter;

        SqlCommandBuilder commandBuilder;

        string sql = "SELECT * FROM Cars";

        public Form2()
        {
            InitializeComponent();

            SqlConnection = new SqlConnection();

            SqlConnection.ConnectionString = ConnectionString;

            SqlConnection.Open();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AllowUserToAddRows = false;

            adapter = new SqlDataAdapter(sql, SqlConnection);

            ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            // делаем недоступным столбец id для изменения
            dataGridView1.Columns["Id"].ReadOnly = true;    
        }

        // кнопка добавления
        private void AddButton_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable

            ds.Tables[0].Rows.Add(row);
        }

        // кнопка удаления
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        // кнопка сохранения
        private void SaveButton_Click(object sender, EventArgs e)
        {
            
           adapter = new SqlDataAdapter(sql, SqlConnection);

           commandBuilder = new SqlCommandBuilder(adapter);

           adapter.InsertCommand = new SqlCommand("UpdateTableCars", SqlConnection)
           {
               CommandType = CommandType.StoredProcedure
           };

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@carname", SqlDbType.NVarChar, 50, "CarName"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@mark", SqlDbType.NVarChar, 50, "Mark"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@color", SqlDbType.NVarChar, 50, "Color"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Money, 0, "Price"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@fuel", SqlDbType.NVarChar, 50, "Fuel"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@enginepower", SqlDbType.NVarChar, 50, "EnginePower"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@enginevolume", SqlDbType.NVarChar, 50, "EngineVolume"));

           adapter.InsertCommand.Parameters.Add(new SqlParameter("@tankvolume", SqlDbType.NVarChar, 50, "TankVolume"));

           SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");

           parameter.Direction = ParameterDirection.Output;

            adapter.Update(ds);

            MessageBox.Show(
                    "Дані збережено.",
                    "Повідомлення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }

        // обработчик кнопки Вперед
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Cars"].Rows.Count < pageSize) return;

            pageNumber++;
            
            adapter = new SqlDataAdapter(GetSql(), SqlConnection);

            ds.Tables["Cars"].Rows.Clear();

            adapter.Fill(ds, "Cars");
        }

        // обработчик кнопки Назад
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;

            pageNumber--;
            
            adapter = new SqlDataAdapter(GetSql(), SqlConnection);

            ds.Tables["Cars"].Rows.Clear();

            adapter.Fill(ds, "Cars");   
        }
        private string GetSql()
        {
            return "SELECT * FROM Cars ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " + "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }
    }
}
