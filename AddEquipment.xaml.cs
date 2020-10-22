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

namespace NETD3202_RyanClayson_Lab2
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : UserControl
    {
        public AddEquipment()
        {
            InitializeComponent();
        }
        //When Add is Clicked, Adds the user inputs to the table (if passes all validations)
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int employeeID;

            //Checks to see if txtName is empty. If true proceeds
            if (txtName.Text != string.Empty)
            {
               //Checks to see if txtEmployeeID is empty or if it is a number. If true proceeds
               if (txtEmployeeID.Text != string.Empty && int.TryParse(txtEmployeeID.Text, out employeeID))
               {
                  //Checks to see if txtDescription is empty. If true proceeds
                  if (txtDescription.Text != string.Empty)
                  {
                      //Checks to see if txtPhoneNumber is empty. If true proceeds
                     if (txtPhoneNumber.Text != string.Empty)
                     {
                        //try's to connect with the database Equipment
                        try
                        {
                            //connects to the database
                            string connect_string = Properties.Settings.Default.connect_string;
                            //creates a new connection
                            SqlConnection conn = new SqlConnection(connect_string);
                            conn.Open();
                            //creates an insert statement
                            string insertQuery = "INSERT INTO [Equipment] (name, empID, description, phone) VALUES('" + txtName.Text + "', '" + int.Parse(txtEmployeeID.Text) + "', '" + txtDescription.Text + "', '" + txtPhoneNumber.Text + "')";
                            //creates a new command
                            SqlCommand command = new SqlCommand(insertQuery, conn);
                            //executes query
                            command.ExecuteNonQuery();
                            //Closes connection
                            conn.Close();

                            MessageBox.Show("Success! Added an equipment record");

                            //clears all textboxes. Sets focus to Name 
                            txtName.Text = "";
                            txtEmployeeID.Text = "";
                            txtDescription.Text = "";
                            txtPhoneNumber.Text = "";
                            txtName.Focus();                                
                        }
                        //An exception has occured. Will show that an error has occurred
                        catch (Exception exception)
                        {
                           MessageBox.Show(exception.ToString());
                           //throw;
                        }
                     }
                     //Validations Shown BELOW
                     //User Input for Phone Number is empty. Display's message
                     else
                     {
                         MessageBox.Show("Error! Phone number cannot be empty");
                         txtPhoneNumber.Text = "";
                         txtPhoneNumber.Focus();
                     }
                  }
                   //User Input for Description is empty. Display's message
                   else
                   {
                       MessageBox.Show("Error! Description cannot be empty");
                       txtDescription.Text = "";
                       txtDescription.Focus();
                   }                    
               }
               //User input for EmployeeID is empty as well as non numeric. Display's message
               else
               {
                   MessageBox.Show("Error! Employee ID cannot be empty and need's to be numeric");
                   txtEmployeeID.Text = "";
                   txtEmployeeID.Focus();
               }                
            }
            //User input for Name is empty. Display's Message
            else
            {
               MessageBox.Show("Error! Name cannot be empty.");
               txtName.Text = "";
               txtName.Focus();
            }           
        }
    }
}
