using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections;

namespace EmailSender
{
    /// <summary>
    /// Interaction logic for MessageSend.xaml
    /// </summary>
    public partial class MessageSend : Window
    {
        string server = "smtp.gmail.com";
        int port = 587;

        string username;
        string password;
        string otheruser;
        string theme;

        List<string> attachedFiles;
        public MessageSend(string gmail, string appPassword, string recipient, string subject, List<string> files)
        {
            InitializeComponent();
            username = gmail;
            password = appPassword;
            otheruser = recipient;
            theme = subject;
            attachedFiles = files;
        }

        private void Send_Button(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(username, otheruser, theme, MyMessage.Text);

            using (StreamReader sr = new StreamReader(@"C:\Users\Vlad\Downloads\index.html"))
            {
                message.Body += sr.ReadToEnd();
            }
            message.IsBodyHtml = true;

            message.Priority = MailPriority.High;

            foreach (var file in attachedFiles)
            {
                string files = file;
                message.Attachments.Add(new Attachment(files));
            }

            SmtpClient client = new SmtpClient(server, port);

            client.EnableSsl = true; // шифрування повідомлення
            client.Credentials = new NetworkCredential(username, password);
            client.SendCompleted += Client_SendCompleted;

            client.SendAsync(message, message);
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            MessageBox.Show($"Message was send! Subject : {state?.Subject}");
        }
    }
}

