using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace MoneyKeeperClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class ApplicationUser
        {
            public Guid Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public decimal Balance { get; set; }
        }
        private async void SignIn_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient httpClient=new HttpClient())
            {
                
                string uri = "localhost/app/sign-in";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>(tbxLogin.Text,pbxPassword.Password)
                });


                var result = await httpClient.PostAsync(uri, content);

                MessageBox.Show(result.Content.ToString());
            }
        }
    }
}
