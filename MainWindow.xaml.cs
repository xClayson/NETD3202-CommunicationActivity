/*
 * Name: Ryan Clayson
 * Date: 10/19/2020
 * Course: NETD 3202
 * Purpose: The purpose of this lab is to add records to the database. Then to retrieve from database.
 * Resources: Lab Database Basics Demo by Alaadin Addas 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NETD3202_RyanClayson_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Initialization
            InitializeComponent();
        }
        //If the user selects lend out or view lend out
        private void SettingsListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listview = e.Source as ListView;

            if (listview != null)
            {
                //Clears listview if not empty
                SettingsContentPanel.Children.Clear();

                if (listview.SelectedItem.Equals(lsvItLendOut))
                {
                    //AddEquipment is a custom user control used
                    Control addEquipment = new AddEquipment();
                    this.SettingsContentPanel.Children.Add(addEquipment);
                }
                if (listview.SelectedItem.Equals(lsvItViewLendOut))
                {
                    //ViewEquipment is another custom control used
                    Control viewEquipment = new ViewEquipment();
                    this.SettingsContentPanel.Children.Add(viewEquipment);
                }
                if (listview.SelectedItem.Equals(lsvItEmployeeSearch))
                {
                    //SearchEmployee is another customer control used 
                    Control searchEmployee = new EmployeeSearch();
                    this.SettingsContentPanel.Children.Add(searchEmployee);
                }
            }
        }
    }
}
