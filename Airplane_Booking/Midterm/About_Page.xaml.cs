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
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for About_Page.xaml
    /// </summary>
    public partial class About_Page : Window
    {
        public About_Page()
        {
            InitializeComponent();
            textblock.Text = "This is An Airline Portal Which Manages the Flights of Customers and their Details" +
                "It consists of Four Pages that includes Customer Pages , Flights Pages , Airlines Pages and Passenger Pages" +
                "\n If the USer is super User than he or she has the access to add , update and delete the Items in Lists , while " +
                "if You are not Super user than you can not change the content , You can only view the data" +
                " This site is Developed by Daksh Patel and its Student Number : 991547214";

        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
