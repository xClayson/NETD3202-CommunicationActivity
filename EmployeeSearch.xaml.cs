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
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EmployeeSearch : UserControl
    {
        public EmployeeSearch()
        {
            InitializeComponent();
        }

        private void btnSearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            int employeeId;

            //Checks to see if user input is empty or a valid integer
            if (txtSearchEmployee.Text != string.Empty && int.TryParse(txtSearchEmployee.Text, out employeeId))
            {
                string connect_string = Properties.Settings.Default.connect_string;
                //Creates a new connection
                SqlConnection cn = new SqlConnection(connect_string);
                //Opens a connection
                cn.Open();

                //Queries to see if employee id entered matches one in the database
                string selectionQuery = "SELECT * FROM Equipment WHERE empID =" + employeeId;
                //Creates command and passes the SQLCommand method
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                //Used to retrieve data and populates table
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //Links to the Equipment database created
                DataTable dt = new DataTable("Equipment");

                sda.Fill(dt);
                int searchEmployeeId = dt.Rows.Count;
                //if employee id matches, shows record
                if (searchEmployeeId > 0)
                {
                    searchEmployeeGrid.ItemsSource = dt.DefaultView;
                }
                //If id does not match records. Display's error
                else
                {
                    MessageBox.Show("Employee ID is not found. Please Try Again.");
                    txtSearchEmployee.Focus();
                    txtSearchEmployee.Text = "";
                }
            }
            //User input is invalid. Either empty or non integer value
            else
            {
                MessageBox.Show("Employee ID must not be empty and needs to be numeric");
                txtSearchEmployee.Focus();
                txtSearchEmployee.Text = "";
            }      
        }
    }
}
