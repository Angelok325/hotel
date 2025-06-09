using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project_HMS
{
    public partial class CustomerDetails : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";

        public CustomerDetails()
        {
            InitializeComponent();
            this.PopulateGridView();
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

        private void PopulateGridView(string sql = "select * from Booking;")
        {
            try
            {
                DataSet ds1 = ExecuteQuery(sql);
                this.dgvCustomer.AutoGenerateColumns = false;
                this.dgvCustomer.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtCName.Text) || string.IsNullOrEmpty(this.txtAdd.Text) ||
                    string.IsNullOrEmpty(this.txtNID.Text) || string.IsNullOrEmpty(this.txtPhone.Text))
                {
                    MessageBox.Show("To Update please fill all the information.");
                    return;
                }

                string query = "update Booking set CName = ?, CPhone = ?, CAdd = ?, CNID = ? where CNID = ?";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CName", this.txtCName.Text);
                        cmd.Parameters.AddWithValue("@CPhone", this.txtPhone.Text);
                        cmd.Parameters.AddWithValue("@CAdd", this.txtAdd.Text);
                        cmd.Parameters.AddWithValue("@CNID", this.txtNID.Text);
                        cmd.Parameters.AddWithValue("@CNID2", this.txtNID.Text); // для условия WHERE
                        int count = cmd.ExecuteNonQuery();

                        if (count == 1)
                        {
                            MessageBox.Show("Customer Info Updated Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Customer Upgradation Failed.");
                        }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            var row = this.dgvCustomer.CurrentRow;
            if (row != null)
            {
                this.txtCName.Text = row.Cells["CName"].Value.ToString();
                this.txtPhone.Text = row.Cells["CPhone"].Value.ToString();
                this.txtAdd.Text = row.Cells["CAdd"].Value.ToString();
                this.txtNID.Text = row.Cells["CNID"].Value.ToString();
            }
        }

        private void ClearContent()
        {
            this.txtCName.Text = "";
            this.txtPhone.Text = "";
            this.txtAdd.Text = "";
            this.txtNID.Text = "";
        }

        private void CustomerDetails_FormClosed(object sender, FormClosedEventArgs e)
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