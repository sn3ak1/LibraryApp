using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Library.Core;
using Library.Data;

namespace Library
{
    public partial class Main : Form
    {
        public Main(bool rented = false, bool history = false)
        {
            InitializeComponent();

            if (history)
            {
                var books = new BindingList<HistoryBook>(MainController.GetUserHistory(UserController.LoggedAs));
                books.AllowNew = false;
                dataGridView1.DataSource = books;
                dataGridView1.Columns["Id"]!.Visible = false;
                dataGridView1.MouseDown += MyDataGridView_MouseDown;
            }
            else if(rented)
            {
                var books = new BindingList<Book>(UserController.LoggedAs.RentedBooks.ToList());

                books.AllowEdit = false;
                var prolong = new ToolStripMenuItem("Prolong");
                prolong.Click += (sender, args) =>
                {
                    books.AllowEdit = true;
                    var book = (Book) dataGridView1.CurrentRow!.DataBoundItem;
                    book.RentingDate = DateTime.Today;
                    books.AllowEdit = false;
                    MainController.EditBook(book);

                };
                contextMenuStrip1.Items.Add(prolong);
                
                var returnBook = new ToolStripMenuItem("Return");
                returnBook.Click += (sender, args) =>
                {
                    MainController.ReturnBook((Book) dataGridView1.CurrentRow!.DataBoundItem);
                    deleteFromDataGrid();
                };
                contextMenuStrip1.Items.Add(returnBook);
                
                books.AllowNew = false;
                dataGridView1.DataSource = books;
                dataGridView1.Columns["Id"]!.Visible = false;
                dataGridView1.MouseDown += MyDataGridView_MouseDown;
            }
            else
            {
                var books = new BindingList<Book>(MainController.GetBooks());
                
                if (UserController.LoggedAs?.IsAdmin ?? false)
                {
                    panel1.Visible = true;
                    dataGridView1.Top += panel1.Height;
                    books.AllowEdit = true;

                    button1.Click += (sender, args) =>
                    {
                        var book = new Book()
                        {
                            Title = textBox1.Text, Author = textBox2.Text, Price = Convert.ToInt32(textBox3.Text),
                            Genre = (Genre) comboBox1.SelectedItem, Currency = (Currency) comboBox2.SelectedItem
                        };
                        books.AllowNew = true;
                        books.Add(book);
                        books.AllowNew = false;
                        MainController.AddBook(book);
                    };

                    var update = new ToolStripMenuItem("Update");
                    update.Click += (sender, args) =>
                    {
                        MainController.EditBook((Book) dataGridView1.CurrentRow!.DataBoundItem);

                    };
                    contextMenuStrip1.Items.Add(update);
                
                    var delete = new ToolStripMenuItem("Delete");
                    delete.Click += ((sender, args) =>
                    {
                        MainController.DeleteBook((Book) dataGridView1.CurrentRow!.DataBoundItem);
                        deleteFromDataGrid();
                    });
                    contextMenuStrip1.Items.Add(delete);
                    comboBox1.DataSource = Enum.GetValues(typeof(Genre));
                    comboBox2.DataSource = Enum.GetValues(typeof(Currency));
                }
                else if(UserController.LoggedAs!=null)
                {
                    books.AllowEdit = false;
                    var rentBook = new ToolStripMenuItem("Rent book");
                    rentBook.Click += (sender, args) =>
                    {
                        if (!MainController.RentBook((Book) dataGridView1.CurrentRow!.DataBoundItem))
                            MessageBox.Show("Renting failed");
                        else
                        {
                            books.AllowEdit = true;
                            ((Book) dataGridView1.CurrentRow!.DataBoundItem).UserRenting = UserController.LoggedAs;
                            books.AllowEdit = false;

                        }
                    };
                    contextMenuStrip1.Items.Add(rentBook);
                }
                else
                {
                    books.AllowEdit = false;
                }
                
                books.AllowNew = false;
                dataGridView1.DataSource = books;
                dataGridView1.Columns["Id"]!.Visible = false;
                dataGridView1.MouseDown += MyDataGridView_MouseDown;
            }
        }
        
        private void MyDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if(e.Button == MouseButtons.Right)
                {
                    var hti = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception exception) { }
        }
        

        private void deleteFromDataGrid()
        {
            Int32 rowToDelete = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            dataGridView1.Rows.RemoveAt(rowToDelete);
            dataGridView1.ClearSelection();
        }
    }
}
