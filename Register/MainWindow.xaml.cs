using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
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

namespace EmailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string username;
        string password;
        string otheruser = "anonim.nymo2@gmail.com";

        public MainWindow(string gmail, string appPassword)
        {
            InitializeComponent();
            username = gmail;
            password = appPassword;
            TextBlockFrom.Text = username;
        }
        private void Write_Message_Button(object sender, RoutedEventArgs e)
        {
            MessageSend message = new MessageSend(username, password, ToWhom.Text, Theme.Text, ListAttachedFile.Items.Cast<string>().ToList());
            message.ShowDialog();
        }

        private void AttachedFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                ListAttachedFile.Items.Add(openFileDialog.FileName);
            }
        }
    }
}