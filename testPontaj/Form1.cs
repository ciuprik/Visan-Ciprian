using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testPontaj
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;
        SqlDataAdapter adapt; 
        int ID = 0;

        public Form1 ( )
        {
            InitializeComponent ( );

        }

        private void Form1_Load ( object sender, EventArgs e )
        {
            // TODO: This line of code loads data into the 'pontajDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill ( this.pontajDataSet.Users );
            if (userNameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void usersBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
        {
            this.Validate ( );
            this.usersBindingSource.EndEdit ( );
            this.tableAdapterManager.UpdateAll ( this.pontajDataSet );

        }

        private void button1_Click ( object sender, EventArgs e )
        {
            if (userNameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                string query = "select * from Users where UserName = '"+userNameTextBox.Text.Trim ( ) + "' and Password ='"+passwordTextBox.Text.Trim ( )+ "' ";
                //cmd = new SqlCommand ( "select from Users(UserName, Password) values (@UserName,@Password) ", con );
                SqlDataAdapter sda = new SqlDataAdapter ( query, con );
                DataTable dtb = new DataTable ( );
                sda.Fill (dtb );
                con.Open ( );
                con.Close ( );
                if(dtb.Rows.Count == 1)
                {
                    UserPage objForm1 = new UserPage();
                    this.Hide ( );
                    objForm1.Show ( );
                }
                else
                {
                    MessageBox.Show ( "Cheack username and password!" );
                }
            }
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            using (newUser fb = new newUser ( ))
            {
                fb.ShowDialog ( );
            }
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            if (userNameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void button4_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }
    }
}
