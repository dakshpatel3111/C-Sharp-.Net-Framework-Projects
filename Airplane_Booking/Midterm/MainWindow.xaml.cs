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

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<string, string> credentials = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            Customer.AddDefaults();
            Flights.addFlights();
            Airline.getairlines();
            Passenger.getpassengerlist();
            Login.getcredentials();
           
            foreach (var u in Login.ulist)
            {
                credentials.Add(u.Username, u.Password);
            }

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
           

            var username = userbox.Text;
            string password = passbox.Password;
            

            if (credentials.Any(entry => entry.Key == username && entry.Value == password))
                {
                var index = Login.ulist.FindIndex(a => a.Username == username && a.Password == password);
                Login.SetCurrentUser(Login.ulist[index]);

                this.Hide();
                    Menu m = new Menu();
                    m.Show();
               

            }
                
                else
                {
                    MessageBox.Show("Invalid Login Entry");
                    

                }
        
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            exit ee = new exit();
            ee.Show();
        }
    }
}
