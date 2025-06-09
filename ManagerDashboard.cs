using System;
using System.Windows.Forms;

namespace Project_HMS
{
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            AddRoom ar = new AddRoom();
            ar.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation rs = new Reservation();
            rs.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerDetails cd = new CustomerDetails();
            cd.Show();
            this.Hide();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ExtraService es = new ExtraService();
            es.Show();
            this.Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            BillHistory bh = new BillHistory();
            bh.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void ManagerDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            // Можно оставить пустым или добавить инициализацию
        }
    }
}