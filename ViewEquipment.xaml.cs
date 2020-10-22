using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace NETD3202_RyanClayson_Lab2
{
    /// <summary>
    /// Interaction logic for ViewEquipment.xaml
    /// </summary>
    public partial class ViewEquipment : UserControl
    {
        public ViewEquipment()
        {
            InitializeComponent();
            //Displays all of the database contents
            FillDataGrid();
        }

        //A function created to display all of the contents of the database
        private void FillDataGrid()
        {
            //Try's to connect to the database and retrieve content
            try
            {
                string connect_string = Properties.Settings.Default.connect_string;
                //Creates a new connection
                SqlConnection cn = new SqlConnection(connect_string);
                //Opens a connection
                cn.Open();
                //SQL Query that runs 
                string selectionQuery = "SELECT * FROM Equipment";
                //Creates command and passes the SQLCommand method
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                //Used to retrieve data and populates table
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //Links to the Equipment database created
                DataTable dt = new DataTable("Equipment");

                sda.Fill(dt);

                equipmentGrid.ItemsSource = dt.DefaultView;
            }
            //If contents can't be displayed, expection is called
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}