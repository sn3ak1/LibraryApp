using System.Windows.Forms;
using Library.Core;

namespace Library
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var form = new Main();
            form.FormClosed += (s, args) => this.Show();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if(UserController.Login(textBox1.Text, textBox2.Text))
                label1.Text = UserController.LoggedAs.Login;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            UserController.Logout();
            label1.Text = "guest";
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            var form = new Register();
            form.FormClosed += (s, args) => this.Show();
            this.Hide();
            form.Show();

            label1.Text = UserController.LoggedAs == null ? "guest" : UserController.LoggedAs.Login;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var form = new Main(rented: true);
            form.FormClosed += (s, args) => this.Show();
            this.Hide();
            form.Show();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var form = new Main(history: true);
            form.FormClosed += (s, args) => this.Show();
            this.Hide();
            form.Show();
        }
    }
}