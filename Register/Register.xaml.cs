
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmailSender
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Register()
        {
            InitializeComponent();
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            if(Gmail.Text == "" || AppPassword.Text == "")
            {
                MessageBox.Show("please fill all!");
                return;
            }

            Username = Gmail.Text;
            Password = AppPassword.Text;

            MainWindow main = new MainWindow(Username, Password);
            main.Show();

            this.Close();
        }
    }
}
