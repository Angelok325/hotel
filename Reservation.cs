using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Project_HMS
{
    public partial class Reservation : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";

        public Reservation()
        {
            InitializeComponent();
            PopulateGridView();
            AutoIdGenerate();
        }

        private OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }

        private void PopulateGridView(string sql = "select * from Room;")
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();

                    // Загрузка данных о комнатах
                    using (OleDbDataAdapter da1 = new OleDbDataAdapter(sql, conn))
                    {
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dgvRoom.AutoGenerateColumns = false;
                        dgvRoom.DataSource = dt1;
                    }

                    // Загрузка данных о пакетах питания
                    using (OleDbDataAdapter da2 = new OleDbDataAdapter("select * from FoodPackage;", conn))
                    {
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        // Предполагается, что есть dgvFood, если нет - удалите эту часть
                    }

                    // Загрузка данных о сервисных пакетах
                    using (OleDbDataAdapter da3 = new OleDbDataAdapter("select * from ServicePackage;", conn))
                    {
                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        dgvService.AutoGenerateColumns = false;
                        dgvService.DataSource = dt3;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Room where Category like '" + txtAutoSearch.Text + "%';";
            PopulateGridView(sql);
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AutoIdGenerate()
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "select MAX(BId) as MaxId from Booking;";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int id = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                        txtBId.Text = id.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating ID: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    using (OleDbConnection conn = GetConnection())
                    {
                        conn.Open();
                        using (OleDbTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Вставка в таблицу Booking
                                string query = @"INSERT INTO Booking (BId, RId, CheckIn, CheckOut, FId, SId, CName, 
                                                [Address], Phone, NID, Total, Advance, Remaining) 
                                                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(query, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtBId.Text));
                                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtRId.Text));
                                    cmd.Parameters.AddWithValue("?", dtpCheckIn.Value.Date);
                                    cmd.Parameters.AddWithValue("?", dtpCheckOut.Value.Date);
                                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtFId.Text));
                                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtSId.Text));
                                    cmd.Parameters.AddWithValue("?", txtCName.Text);
                                    cmd.Parameters.AddWithValue("?", txtAdd.Text);
                                    cmd.Parameters.AddWithValue("?", txtPhone.Text);
                                    cmd.Parameters.AddWithValue("?", txtNID.Text);
                                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(txtTotal.Text));
                                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(txtAdv.Text));
                                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(txtRemaining.Text));

                                    int count = cmd.ExecuteNonQuery();

                                    if (count == 1)
                                    {
                                        // Обновление таблицы Room
                                        string update = "UPDATE Room SET IsBooked = 'Yes', BId = ? WHERE RId = ?";
                                        using (OleDbCommand updateCmd = new OleDbCommand(update, conn, transaction))
                                        {
                                            updateCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtBId.Text));
                                            updateCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtRId.Text));
                                            int count1 = updateCmd.ExecuteNonQuery();

                                            if (count1 == 1)
                                            {
                                                transaction.Commit();
                                                MessageBox.Show("Reservation successfully completed!");
                                                ClearContent();
                                                AutoIdGenerate();
                                                PopulateGridView();
                                            }
                                            else
                                            {
                                                transaction.Rollback();
                                                MessageBox.Show("Failed to update room status.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Failed to create reservation.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtBId.Text) || string.IsNullOrEmpty(txtRId.Text) ||
                string.IsNullOrEmpty(txtDay.Text) || string.IsNullOrEmpty(txtFId.Text) ||
                string.IsNullOrEmpty(txtSId.Text) || string.IsNullOrEmpty(txtCName.Text) ||
                string.IsNullOrEmpty(txtAdd.Text) || string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtNID.Text) || string.IsNullOrEmpty(txtTotal.Text) ||
                string.IsNullOrEmpty(txtAdv.Text) || string.IsNullOrEmpty(txtRemaining.Text))
            {
                MessageBox.Show("Please fill all the required information.");
                return false;
            }

            // Проверка дат
            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return false;
            }

            return true;
        }

        private void btnTCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRId.Text) || string.IsNullOrEmpty(txtSId.Text) || string.IsNullOrEmpty(txtDay.Text))
            {
                MessageBox.Show("Please select room, service package and enter number of days.");
                return;
            }

            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();

                    // Расчет стоимости комнаты
                    double roomCost = 0;
                    string roomQuery = "SELECT RoomCost FROM Room WHERE RId = ?";
                    using (OleDbCommand roomCmd = new OleDbCommand(roomQuery, conn))
                    {
                        roomCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtRId.Text));
                        roomCost = Convert.ToDouble(roomCmd.ExecuteScalar());
                    }

                    // Расчет стоимости сервисного пакета
                    double serviceCost = 0;
                    string serviceQuery = "SELECT SPackageCost FROM ServicePackage WHERE SId = ?";
                    using (OleDbCommand serviceCmd = new OleDbCommand(serviceQuery, conn))
                    {
                        serviceCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtSId.Text));
                        serviceCost = Convert.ToDouble(serviceCmd.ExecuteScalar());
                    }

                    // Общая стоимость
                    int days = Convert.ToInt32(txtDay.Text);
                    double total = (roomCost * days) + serviceCost;
                    txtTotal.Text = total.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
            }
        }

        private void btnRCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal.Text) || string.IsNullOrEmpty(txtAdv.Text))
            {
                MessageBox.Show("Please calculate total and enter advance amount first.");
                return;
            }

            try
            {
                double total = Convert.ToDouble(txtTotal.Text);
                double advance = Convert.ToDouble(txtAdv.Text);
                double remaining = total - advance;
                txtRemaining.Text = remaining.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating remaining amount: " + ex.Message);
            }
        }

        private void ClearContent()
        {
            txtRId.Text = "";
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            txtDay.Text = "";
            txtFId.Text = "";
            txtSId.Text = "";
            txtCName.Text = "";
            txtAdd.Text = "";
            txtPhone.Text = "";
            txtNID.Text = "";
            txtTotal.Text = "";
            txtAdv.Text = "";
            txtRemaining.Text = "";
            txtAutoSearch.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearContent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Show();
            this.Hide();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
        }
    }
}