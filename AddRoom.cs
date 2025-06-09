using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project_HMS
{
    public partial class AddRoom : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";

        public AddRoom()
        {
            InitializeComponent();
            PopulateGridView();
            AutoIdGenerate();
        }

        private DataTable ExecuteQueryTable(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private DataSet ExecuteQuery(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        private int ExecuteDML(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private void PopulateGridView(string sql = "select * from Room;")
        {
            try
            {
                DataSet ds1 = ExecuteQuery(sql);
                this.dgvRoom.AutoGenerateColumns = false;
                this.dgvRoom.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void AutoIdGenerate()
        {
            double id = 0;
            try
            {
                string sql1 = "select RId from Room order by RId desc;";
                DataTable dt1 = ExecuteQueryTable(sql1);
                if (dt1.Rows.Count > 0)
                {
                    string I = dt1.Rows[0]["RId"].ToString();
                    var ID = Convert.ToDouble(I);
                    id = ID + 1;
                }
                else
                {
                    id = 1; // если таблица пустая
                }
                txtRId.Text = Convert.ToString(id);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void dgvRoom_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRoom.CurrentRow != null)
            {
                this.txtRId.Text = this.dgvRoom.CurrentRow.Cells["RId"].Value.ToString();
                this.textBox1.Text = this.dgvRoom.CurrentRow.Cells["Category"].Value.ToString();
                this.textBox2.Text = this.dgvRoom.CurrentRow.Cells["IsBooked"].Value.ToString();
                this.txtRCost.Text = this.dgvRoom.CurrentRow.Cells["RoomCost"].Value.ToString();
            }
        }

        private void ClearContent()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.txtRCost.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtRId.Text) || string.IsNullOrEmpty(this.textBox1.Text) ||
                    string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.txtRCost.Text))
                {
                    MessageBox.Show("To add Room please fill all the information.");
                    return;
                }

                // Проверка существования записи
                string checkSql = "select * from Room where RId = " + this.txtRId.Text + ";";
                var dsCheck = ExecuteQuery(checkSql);
                if (dsCheck.Tables[0].Rows.Count == 1)
                {
                    // Обновление записи
                    string updateSql = "update Room set Category = ?, IsBooked = ?, RoomCost = ? where RId = ?";
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Category", this.textBox1.Text);
                            cmd.Parameters.AddWithValue("@IsBooked", this.textBox2.Text);
                            cmd.Parameters.AddWithValue("@RoomCost", this.txtRCost.Text);
                            cmd.Parameters.AddWithValue("@RId", this.txtRId.Text);
                            int count = cmd.ExecuteNonQuery();
                            if (count == 1)
                                MessageBox.Show("Room Updated Successfully.");
                            else
                                MessageBox.Show("Room Upgradation Failed.");
                        }
                    }
                }
                else
                {
                    // Вставка новой записи
                    string insertSql = "insert into Room (RId, Category, IsBooked, RoomCost) values (?, ?, ?, ?)";
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@RId", this.txtRId.Text);
                            cmd.Parameters.AddWithValue("@Category", this.textBox1.Text);
                            cmd.Parameters.AddWithValue("@IsBooked", this.textBox2.Text);
                            cmd.Parameters.AddWithValue("@RoomCost", this.txtRCost.Text);
                            int count = cmd.ExecuteNonQuery();
                            if (count == 1)
                                MessageBox.Show("Room Inserted.");
                            else
                                MessageBox.Show("Room Insertion Failed.");
                        }
                    }
                }

                PopulateGridView();
                ClearContent();
                AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearContent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoom.CurrentRow == null)
                {
                    MessageBox.Show("Select a room to delete.");
                    return;
                }
                var id = dgvRoom.CurrentRow.Cells["RId"].Value.ToString();

                string deleteSql = "delete from Room where RId = ?";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RId", id);
                        int count = cmd.ExecuteNonQuery();
                        if (count == 1)
                            MessageBox.Show("Room " + id + " has been deleted.");
                        else
                            MessageBox.Show("Room Deletion Failed.");
                    }
                }

                PopulateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            // Можно оставить пустым или добавить инициализацию
        }
    }
}