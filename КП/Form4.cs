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
    public partial class Form4 : Form
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection SqlConnection { get; set; }

        int pageSize = 10;

        int pageNumber = 0;

        DataSet ds;

        SqlDataAdapter adapter;

        SqlCommandBuilder commandBuilder;

        string sql = "SELECT * FROM Orders";

        public Form4()
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

            adapter.InsertCommand = new SqlCommand("UpdateTableCustomers", SqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            adapter.InsertCommand.Parameters.Add(new SqlParameter("@firstname", SqlDbType.NVarChar, 50, "FirstName"));

            adapter.InsertCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.NVarChar, 50, "LastName"));

            adapter.InsertCommand.Parameters.Add(new SqlParameter("@middlename", SqlDbType.NVarChar, 50, "MiddleName"));

            adapter.InsertCommand.Parameters.Add(new SqlParameter("@phonenumber", SqlDbType.VarChar, 50, "PhoneNumber"));

            adapter.InsertCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, "Email"));

            SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");

            parameter.Direction = ParameterDirection.Output;

            adapter.Update(ds);
        }

        // обработчик кнопки Вперед
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Customers"].Rows.Count < pageSize) return;

            pageNumber++;

            adapter = new SqlDataAdapter(GetSql(), SqlConnection);

            ds.Tables["Customers"].Rows.Clear();

            adapter.Fill(ds, "Customers");
        }

        // обработчик кнопки Назад
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;

            pageNumber--;

            adapter = new SqlDataAdapter(GetSql(), SqlConnection);

            ds.Tables["Customers"].Rows.Clear();

            adapter.Fill(ds, "Customers");
        }
        private string GetSql()
        {
            return "SELECT * FROM Customers ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " + "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }
    }
}
