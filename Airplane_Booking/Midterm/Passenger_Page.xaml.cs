using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using System.Linq;
namespace Midterm
{
    /// <summary>
    /// Interaction logic for Passenger_Page.xaml
    /// </summary>
    public partial class Passenger_Page : Window
    {
      
        public Passenger_Page()
        {
            InitializeComponent();
            // Checking if the Current User is Superuser or not
            addbtn.IsEnabled= Login.GetCurrentUSer().Superuser == 1;
            delbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            editbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            menu2.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            edit.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextupdate.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextdelete.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextAdd.IsEnabled = Login.GetCurrentUSer().Superuser == 1;

            // Initializing the Passenger listbox
            foreach (var x in Passenger.plist)
            {
                passbox.Items.Add(x);
            }
            // Superuser tag if superuser 
            Login l = Login.GetCurrentUSer();
            if (l.Superuser == 1)
            {
                usemode.Header = "SuperUser";

            }
            else
            {
                usemode.Header = "NormalUser";
            }

            passbox.SelectionMode = SelectionMode.Single;
          

        }
        // Add button
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(idbox.Text) || String.IsNullOrEmpty(flightbox.Text) || String.IsNullOrEmpty(custbox.Text))
            {
                MessageBox.Show("Please Fill all the Boxes");
                return;
            }
            int id = int.Parse(idbox.Text);
            int fid = int.Parse(flightbox.Text);
            int cid = int.Parse(custbox.Text);

            Passenger p = new Passenger(id, fid, cid);
            Passenger.plist.Add(p);
            
            
              
                this.Hide();
                Passenger_Page pp = new Passenger_Page();
                pp.Show();

           
          


        }

       
        // When user selects the list item , it displays the related item to other two listboxes
        private void passbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Passenger pass = (Passenger)passbox.SelectedItem;

            var customersrc = from cx in Customer.clist
                           where cx.Id == pass.CustomerId
                           select cx;
            viewcbox.Items.Clear();
            foreach(var cd in customersrc)
            {
                viewcbox.Items.Add(cd);
            }

            var flightssrc = from fp in Flights.flist
                          where fp.Id == pass.FlightId
                          select fp;
            viewfbox.Items.Clear();
            foreach(var fs in flightssrc)
            {
                viewfbox.Items.Add(fs);
            }
        }
        // back button to go back to Main Menu
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }
        // Delete button to delete a obect from list
        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            if (passbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            passbox.Items.Remove(passbox.SelectedItem.ToString());
            Passenger.plist.Remove((Passenger)passbox.SelectedItem);
            this.Hide();
            Passenger_Page pp = new Passenger_Page();
            pp.Show();

        }
        //Edit button 
        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            if (passbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            Passenger py = (Passenger)passbox.SelectedItem;

            idbox.Text = (py.Id).ToString();
            flightbox.Text = py.FlightId.ToString();
            custbox.Text = py.CustomerId.ToString();

            passbox.Items.Remove(passbox.SelectedItem.ToString());
            Passenger.plist.Remove((Passenger)passbox.SelectedItem);


        }
      // Exit event
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            exit ee = new exit();
            ee.Show();
        }
        // About Page event
        private void about_Click(object sender, RoutedEventArgs e)
        {
            About_Page ap = new About_Page();
            ap.Show();
        }
    }
}
