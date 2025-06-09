using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project_HMS
{
    public partial class ExtraService : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";

        public ExtraService()
        {
            InitializeComponent();
            this.PopulateGridView();
            this.AutoIdGenerate();
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

        private void PopulateGridView(string sql = "select * from ServicePackage;")
        {
            try
            {
                DataSet ds1 = ExecuteQuery(sql);
                this.dgvService.AutoGenerateColumns = false;
                this.dgvService.DataSource = ds1.Tables[0];
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
                string sql1 = "select SId from ServicePackage order by SId desc;";
                DataTable dt1 = ExecuteQueryTable(sql1);
                if (dt1.Rows.Count > 0)
                {
                    string I = dt1.Rows[0]["SId"].ToString();
                    var ID = Convert.ToDouble(I);
                    id = ID + 1;
                }
                else
                {
                    id = 1; // если таблица пустая
                }
                txtSId.Text = Convert.ToString(id);
            }
            catch
            {
                txtSId.Text = "1"; // если ошибка
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtSId.Text) || string.IsNullOrEmpty(this.txtSName.Text) || string.IsNullOrEmpty(this.txtSCost.Text))
                {
                    MessageBox.Show("To add Service please fill all the information.");
                    return;
                }

                string sqlCheck = "select * from ServicePackage where SId = " + this.txtSId.Text + ";";
                var ds = ExecuteQuery(sqlCheck);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //Update
                    string query = "update ServicePackage set SName = ?, SPackageCost = ? where SId = ?";
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SName", this.txtSName.Text);
                            cmd.Parameters.AddWithValue("@SPackageCost", this.txtSCost.Text);
                            cmd.Parameters.AddWithValue("@SId", this.txtSId.Text);
                            int count = cmd.ExecuteNonQuery();

                            if (count == 1)
                                MessageBox.Show("Service Package Updated Successfully.");
                            else
                                MessageBox.Show("Service Package Upgradation Failed.");
                        }
                    }
                }
                else
                {
                    //Insert
                    string query = "insert into ServicePackage (SId, SName, SPackageCost) values (?, ?, ?)";
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SId", this.txtSId.Text);
                            cmd.Parameters.AddWithValue("@SName", this.txtSName.Text);
                            cmd.Parameters.AddWithValue("@SPackageCost", this.txtSCost.Text);
                            int count = cmd.ExecuteNonQuery();

                            if (count == 1)
                                MessageBox.Show("Service Package Inserted.");
                            else
                                MessageBox.Show("Service Package Insertion Failed.");
                        }
                    }
                }

                this.PopulateGridView();
                this.ClearContent();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dgvService.CurrentRow.Cells["SId"].Value.ToString();
                string sql = "delete from ServicePackage where SId = ?";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SId", id);
                        int count = cmd.ExecuteNonQuery();
                        if (count == 1)
                            MessageBox.Show("Service Package " + id + " has been deleted.");
                        else
                            MessageBox.Show("Service Package Deletion Failed.");
                    }
                }
                this.PopulateGridView();
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void dgvService_DoubleClick(object sender, EventArgs e)
        {
            this.txtSId.Text = this.dgvService.CurrentRow.Cells["SId"].Value.ToString();
            this.txtSName.Text = this.dgvService.CurrentRow.Cells["SName"].Value.ToString();
            this.txtSCost.Text = this.dgvService.CurrentRow.Cells["SPackageCost"].Value.ToString();
        }

        private void ClearContent()
        {
            this.txtSName.Text = "";
            this.txtSCost.Text = "";
            this.AutoIdGenerate();
        }

        private void ExtraService_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}