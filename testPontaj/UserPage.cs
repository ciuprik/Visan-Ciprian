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
    public partial class UserPage : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;
        public UserPage ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }

        private void bazaDateBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
        {
            this.Validate ( );
            this.bazaDateBindingSource.EndEdit ( );
            this.tableAdapterManager.UpdateAll ( this.pontajDataSet );

        }

        private void UserPage_Load ( object sender, EventArgs e )
        {
            // TODO: This line of code loads data into the 'pontajDataSet.BazaDate' table. You can move, or remove it, as needed.
            this.bazaDateTableAdapter.Fill ( this.pontajDataSet.BazaDate );

        }
        private void DisplayData ( )
        {
            con.Open ( );
            DataTable dt = new DataTable ( );
            adapt = new SqlDataAdapter ( "select * from BazaDate", con );
            adapt.Fill ( dt );
            bazaDateDataGridView.DataSource = dt;
            con.Close ( );
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            timer1.Enabled = true;
            cmd = new SqlCommand ( "insert into BazaDate(zi,startTime) values ( @zi,@startTime)", con );
            con.Open ( );
            cmd.Parameters.AddWithValue ( "@zi", label3.Text );
            cmd.Parameters.AddWithValue ( "@startTime", label1.Text );
            cmd.ExecuteNonQuery ( );
            con.Close ( );
            MessageBox.Show ( "Have a nice Day!!!." );
            DisplayData ( );
            //Dispose ( );
            
        }
        
        private void button3_Click ( object sender, EventArgs e )
        {
            timer1.Enabled = true;
            cmd = new SqlCommand ( "insert into BazaDate(endTime) values ( @endTime)", con );
            con.Open ( );
            //cmd.Parameters.AddWithValue ( "@zi", label3.Text );
            cmd.Parameters.AddWithValue ( "@endTime", label1.Text );
            cmd.ExecuteNonQuery ( );
            con.Close ( );
            MessageBox.Show ( "See you next time." );
            DisplayData ( );
            //Dispose ( );

        }

        private void label1_Click ( object sender, EventArgs e )
        {

        }

        private void timer1_Tick ( object sender, EventArgs e )
        {
            label1.Text = DateTime.Now.ToString ( "HH:mm" );
            label2.Text = DateTime.Now.ToString ( "ss" );
            label3.Text = DateTime.Now.ToString ( "dd/MM/yyyy" );
        }
    }
}
