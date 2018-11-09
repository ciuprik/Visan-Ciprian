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
    public partial class newUser : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;
        public newUser ( )
        {
            InitializeComponent ( );
        }

        private void usersBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
        {
            this.Validate ( );
            this.usersBindingSource.EndEdit ( );
            this.tableAdapterManager.UpdateAll ( this.pontajDataSet );

        }

        private void newUser_Load ( object sender, EventArgs e )
        { 
            // TODO: This line of code loads data into the 'pontajDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill ( this.pontajDataSet.Users );

        }

        private void button1_Click ( object sender, EventArgs e )
        {
            if (userNameTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                cmd = new SqlCommand ( "insert into Users(UserName, FirstName, LastName, Password) values(@UserName, @FirstName, @LastName,@Password)", con );

                con.Open ( );
                cmd.Parameters.AddWithValue ( "@UserName", userNameTextBox.Text );
                cmd.Parameters.AddWithValue ( "@FirstName", firstNameTextBox.Text );
                cmd.Parameters.AddWithValue ( "@LastName", lastNameTextBox.Text );
                cmd.Parameters.AddWithValue ( "@Password", passwordTextBox.Text );
                cmd.ExecuteNonQuery ( );
                con.Close ( );
                MessageBox.Show ( "Record Inserted Successfully" );
                Dispose ( );
            }
            else
            {
                MessageBox.Show ( "Please Provide Details!" );
            }
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            if (userNameTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text !="" && passwordTextBox.Text!= "")
            {
                userNameTextBox.Text = "";
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }
    }
}
