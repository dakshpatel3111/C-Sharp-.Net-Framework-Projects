using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Window
    {
             

        public CustomerPage()
        {
            InitializeComponent();
            
            addbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            delbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            upbtn.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            menu2.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            edit.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextupdate.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextdelete.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            contextAdd.IsEnabled = Login.GetCurrentUSer().Superuser == 1;
            foreach (var x in Customer.clist) {
                clistbox.Items.Add(x);
                      
            }
            Login l = Login.GetCurrentUSer();
            if (l.Superuser == 1)
            {
                usemode.Header = "SuperUser";

            }
            else
            {
                usemode.Header = "NormalUser";
            }
            clistbox.SelectionMode = SelectionMode.Single;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(idbox.Text) || String.IsNullOrEmpty(namebox.Text) || String.IsNullOrEmpty(emailbox.Text) || String.IsNullOrEmpty(addbox.Text) || String.IsNullOrEmpty(phonebox.Text) )
            {
                MessageBox.Show("Please Fill all the Boxes");
                return;
            }
            var id = int.Parse(idbox.Text);
            var name = namebox.Text;
            var email = emailbox.Text;
            var address = addbox.Text;
            var phone = phonebox.Text;

            Customer nc = new Customer(id, name, email, address, phone);
           Customer.clist.Add(nc);
            clistbox.Items.Add(nc);

            idbox.Text = "";
            namebox.Text = "";
            emailbox.Text = "";
            addbox.Text = "";
            phonebox.Text = "";
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            if (clistbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            Customer c = (Customer)clistbox.SelectedItem;
            clistbox.Items.Remove(clistbox.SelectedItem);
           Customer.clist.Remove(c);
        }

        private void upbtn_Click(object sender, RoutedEventArgs e)
        {
            if (clistbox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Element from listbox");
                return;
            }
            Customer c1 = (Customer)clistbox.SelectedItem;
            idbox.Text = (c1.Id).ToString();
            namebox.Text = c1.Name;
            emailbox.Text = c1.Email;
            addbox.Text = c1.Address;
            phonebox.Text = c1.Phone;

            clistbox.Items.Remove(clistbox.SelectedItem);
           Customer.clist.Remove(c1);
            
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
