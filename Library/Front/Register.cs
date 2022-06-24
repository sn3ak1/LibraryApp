using System.Windows.Forms;
using Library.Core;

namespace Library
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (UserController.AddUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text))
            {
                MessageBox.Show("Registration succesfull");
                UserController.Login(textBox1.Text, textBox2.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Registration failed");
            }
        }
    }
}