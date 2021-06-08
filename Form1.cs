using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HW2._1
{
   
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source = (local); Initial Catalog = SageBook; Integrated Security = True");

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            string newName= textBox2.Text;
            int newId = Convert.ToInt32(textBox1.Text);
            var st = new Sage
            {
                name = newName,
                id = newId,
            };
            dc.Sage.InsertOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.Sage where a.id== Convert.ToInt32(textBox1.Text) select a).First();
            st.id= Convert.ToInt32(textBox1.Text);
            st.name= textBox2.Text;
            dc.SubmitChanges();
            LoadData();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            int IdSB = Convert.ToInt32(textBox7.Text);
            int SId = Convert.ToInt32(textBox3.Text);
            int BId = Convert.ToInt32(textBox4.Text);
            var st = new SageBook
            {
                id=IdSB,
                idS=SId,
                idB=BId,
            };
            dc.SageBook.InsertOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.SageBook where a.id == Convert.ToInt32(textBox7.Text) select a).First();
            st.id = Convert.ToInt32(textBox7.Text);
            st.idS = Convert.ToInt32(textBox3.Text);
            st.idB = Convert.ToInt32(textBox4.Text);
            dc.SubmitChanges();
            LoadData();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            string newName = textBox5.Text;
            int newId = Convert.ToInt32(textBox6.Text);
            var st = new Book
            {
                name = newName,
                id = newId,
            };
            dc.Book.InsertOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.Book where a.id == Convert.ToInt32(textBox5.Text) select a).First();
            st.id = Convert.ToInt32(textBox5.Text);
            st.name = textBox6.Text;
            dc.SubmitChanges();
            LoadData();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var SelectQuery =
                from a in dc.GetTable<Sage>()
                select a;
            dataGridView1.DataSource = SelectQuery;
            var SelectQuery1 =
                from a in dc.GetTable<SageBook>()
                select a;
            dataGridView2.DataSource = SelectQuery1;
            var SelectQuery2 =
                from a in dc.GetTable<Book>()
                select a;
            dataGridView3.DataSource = SelectQuery2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st =
                from a in dc.Sage
                where a.id == Convert.ToInt32(textBox1.Text)
                select a;
            dataGridView1.DataSource = st;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st =
                from a in dc.SageBook
                where a.id == Convert.ToInt32(textBox7.Text)
                select a;
            dataGridView2.DataSource = st;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st =
                from a in dc.Book
                where a.id == Convert.ToInt32(textBox5.Text)
                select a;
            dataGridView3.DataSource = st;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.Sage where a.id == Convert.ToInt32(textBox1.Text) select a).First();
            dc.Sage.DeleteOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.SageBook where a.id == Convert.ToInt32(textBox7.Text) select a).First();
            dc.SageBook.DeleteOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            var st = (from a in dc.Book where a.id == Convert.ToInt32(textBox5.Text) select a).First();
            dc.Book.DeleteOnSubmit(st);
            dc.SubmitChanges();
            LoadData();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
