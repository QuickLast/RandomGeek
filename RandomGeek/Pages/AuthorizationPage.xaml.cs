using RandomGeek.Database;
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

namespace RandomGeek.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user;
        public static List<User> users { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void NoEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = EmailTb.Text.Trim();
            string password = PasswordPb.Password.Trim();

            users = new List<User>(DbConnection.RandomGeek_KamilEntities.User.ToList());
            user = users.FirstOrDefault(i => i.Email == login && i.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Успешно!");
                NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Повторите попытку!");
                EmailTb.Text = string.Empty;
                PasswordPb.Password = string.Empty;
            }


             
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

    }
}