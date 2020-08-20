using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
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
    /// Interaction logic for Flight_Page.xaml
    /// </summary>
    public partial class Flight_Page : Window
    {

        public Flight_Page()
        {
            InitializeComponent();
            add.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            delbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            editbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            menu2.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            edit.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextupdate.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextdelete.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextAdd.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            foreach (var x in Flights.flist)
            {
                flightbox.Items.Add(x);
            }
            flightbox.SelectionMode = SelectionMode.Single;
            Login l = Login.GetCurrentUSer();
            if (l.Superuser == 1) {
                usemode.Header = "SuperUser";
               
        }
            else
            {
                usemode.Header = "NormalUser";
            }
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(idbox.Text) || String.IsNullOrEmpty(airbox.Text) || String.IsNullOrEmpty(deptbox.Text) || String.IsNullOrEmpty(estbox.Text)|| String.IsNullOrEmpty(timebox.Text)|| String.IsNullOrEmpty(datebox.Text))
            {
                MessageBox.Show("Please Fill all the Boxes");
                return;
            }
            var id = int.Parse(idbox.Text);
            var airlineid = int.Parse(airbox.Text);
            var deptcity = deptbox.Text;
            var destcity = estbox.Text;
            var flighttime = double.Parse(timebox.Text);
            var date = datebox.Text;

            Flights f = new Flights(id,airlineid,deptcity,destcity,date,flighttime);
            flightbox.Items.Add(f);
            Flights.flist.Add(f);

            idbox.Text = "";
            airbox.Text = "";
            deptbox.Text = "";
            estbox.Text = "";
            timebox.Text = "";
            datebox.Text = "";
            

        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            if(flightbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            flightbox.Items.Remove(flightbox.SelectedItem);
            Flights f = (Flights)flightbox.SelectedItem;
            Flights.flist.Remove(f);
        }

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            if (flightbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }

            Flights fp = (Flights)flightbox.SelectedItem;
            idbox.Text = (fp.Id).ToString();
            airbox.Text = (fp.AirlineId).ToString();
            deptbox.Text = fp.Departurecity;
            estbox.Text = fp.Destinationcity;
            datebox.Text = fp.Departuredate;
            timebox.Text = (fp.Flighttime).ToString();

            flightbox.Items.Remove(flightbox.SelectedItem);
            Flights.flist.Remove(fp);
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            exit ee = new exit();
            ee.Show();
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            About_Page ap = new About_Page();
            ap.Show();
        }

    }
}
