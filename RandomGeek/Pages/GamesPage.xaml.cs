using RandomGeek.Functions;
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
    /// Логика взаимодействия для GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        public GamesPage()
        {
            InitializeComponent();
        }
        private void MoveToAuthPage_MouseDown(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void MoveToGamesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new GamesPage());
        }

        private void MoveToCinemaPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CinemaPage());
        }

        private void MoveToMainPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
           NavigationService.Navigate(new MainPage(Auth.user));
        }
    }
}
