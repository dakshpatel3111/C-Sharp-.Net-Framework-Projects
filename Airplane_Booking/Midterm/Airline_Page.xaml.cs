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
    /// Interaction logic for Airline_Page.xaml
    /// </summary>
    public partial class Airline_Page : Window
    {
      
        public Airline_Page()
        {
            InitializeComponent();
            addbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            delbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
           editbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            menu2.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            edit.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextupdate.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextdelete.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextAdd.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            foreach (var x in Airline.alist)
            {
                planebox.Items.Add(x);
            }
            planebox.SelectionMode = SelectionMode.Single;
            Login l = Login.GetCurrentUSer();
            if (l.Superuser == 1)
                usemode.Header = "SuperUser";
            else
                usemode.Header = "NormalUser";
            
        }



        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(idbox.Text) || 
                String.IsNullOrEmpty(namebox.Text) || 
                String.IsNullOrEmpty(seatbox.Text) )
            {
                MessageBox.Show("Please Fill all the Boxes");
                return;
            }
            var id = int.Parse(idbox.Text);
            var name = namebox.Text;
  
                string pl = (string)plane.Content;
            
            if(plane2.IsChecked == true)
            {
                pl = (string)plane2.Content;
            }

            
                string ml = (string)meal.Content;
            
            if(meal2.IsChecked == true)
            {
                 ml = (string)meal2.Content;
            }
            var seats = int.Parse(seatbox.Text);
            Airline ap = new Airline(id,name,pl,seats,ml);
            planebox.Items.Add(ap);
            Airline.alist.Add(ap);

            idbox.Text = "";
            namebox.Text = "";
            seatbox.Text = "";
            plane.IsChecked = true;
            meal2.IsChecked = true;


        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            if (planebox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            planebox.Items.Remove(planebox.SelectedItem);
            Airline a = (Airline)planebox.SelectedItem;
           Airline.alist.Remove(a);
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            if (planebox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            Airline al = (Airline)planebox.SelectedItem;
            idbox.Text = (al.Id).ToString();
            namebox.Text = al.Name;
            string planes = al.Airplane;
            string meals = al.Meals;
             seatbox.Text = al.Seats.ToString();

            if(planes == plane.Content)
            {
                plane.IsChecked = true;
                plane2.IsChecked = false;
            }
            else if(planes == plane2.Content)
            {
                plane.IsChecked = false;
                plane2.IsChecked = true;
            }
            if(meals == meal.Content)
            {
                meal.IsChecked = true;
                meal2.IsChecked = false;
            }
            else if (meals == meal2.Content)
            {
                meal.IsChecked = false;
                meal2.IsChecked = true;
            }
            planebox.Items.Remove(planebox.SelectedItem);
            Airline.alist.Remove(al);


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
