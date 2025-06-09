using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project_HMS
{
    public partial class BillHistory : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";

        public BillHistory()
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


        private void PopulateGridView()
        {
            try
            {
                string sql = "select * from Booking;";
                DataSet ds1 = ExecuteQuery(sql);
                this.dgvBooking.AutoGenerateColumns = false;
                this.dgvBooking.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void BillHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvBooking_DoubleClick(object sender, EventArgs e)
        {
            var row = this.dgvBooking.CurrentRow;
            if (row != null)
            {
                this.txtBId.Text = row.Cells["BId"].Value.ToString();
                this.txtRId.Text = row.Cells["RId"].Value.ToString();
                this.txtCName.Text = row.Cells["CName"].Value.ToString();
                this.txtPhone.Text = row.Cells["CPhone"].Value.ToString();
                this.dtpCheckIn.Text = row.Cells["CheckIn"].Value.ToString();
                this.dtpCheckOut.Text = row.Cells["CheckOut"].Value.ToString();
                this.txtAdvance.Text = row.Cells["Advance"].Value.ToString();
                this.txtRemaining.Text = row.Cells["Remaining"].Value.ToString();
                this.txtTotal.Text = row.Cells["Total"].Value.ToString();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double rv = 0;
                double R = Convert.ToDouble(this.txtRemaining.Text);
                double N = Convert.ToDouble(this.txtNPaid.Text);
                rv = N - R;
                txtReturn.Text = Convert.ToString(rv);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int x = 100, y = 100; //start position
                int width = 80, height = 50;

                var header = new Font("Calibri", 21, FontStyle.Bold);
                int hdy = (int)header.GetHeight(e.Graphics);
                var fnt = new Font("Times New Roman", 14, FontStyle.Bold);
                int dy = (int)fnt.GetHeight(e.Graphics);

                e.Graphics.DrawString("Hotel Dream", header, Brushes.Black, new PointF(x, y));
                y += hdy + hdy;
                e.Graphics.DrawString("Bill Id : " + txtBId.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Room Id : " + txtRId.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Customer Name : " + txtCName.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Phone No : " + txtPhone.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Check In : " + dtpCheckIn.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Check Out : " + dtpCheckOut.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Total : " + txtTotal.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Advance : " + txtAdvance.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Now Paid Amount : " + txtNPaid.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Returned Amount : " + txtReturn.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Обновление таблицы Room
                string updateRoom = "UPDATE Room SET IsBooked = 'No' WHERE RId = " + this.txtRId.Text;
                int count1 = ExecuteDML(updateRoom);
                if (count1 == 1)
                {
                    MessageBox.Show("Data Updated In Room Table Successfully.");
                }
                else
                {
                    MessageBox.Show("Data Upgradation Failed In Room Table.");
                }

                //Обновление таблицы Booking
                string updateBooking = "UPDATE Booking SET Advance = " + this.txtTotal.Text + ", Remaining = 0 WHERE BId = " + this.txtBId.Text;
                int count2 = ExecuteDML(updateBooking);
                if (count2 == 1)
                {
                    MessageBox.Show("Data Updated In Booking Table Successfully.");
                    this.PopulateGridView();
                }
                else
                {
                    MessageBox.Show("Data Upgradation Failed In Booking Table.");
                }
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ClearContent()
        {
            this.txtBId.Text = "";
            this.txtRId.Text = "";
            this.dtpCheckIn.Text = "";
            this.txtCName.Text = "";
            this.txtPhone.Text = "";
            this.txtTotal.Text = "";
            this.txtAdvance.Text = "";
            this.txtRemaining.Text = "";
            this.txtNPaid.Text = "";
            this.txtReturn.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}
