using RandomGeek.Database;
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
        public static List<Game> games { get; set; }
        public static List<Game> strategies { get; set; }
        public static List<Game> shooters { get; set; }
        User userToSend;
        public GamesPage(User user)
        {
            InitializeComponent();

            userToSend = user;

            games = new List<Game>(DbConnection.RandomGeekEntities.Game.Where(x => x.Rating >= 8.8).ToList());
            this.DataContext = this;

            BestGamesLv.ItemsSource = games;

            strategies = new List<Game>(DbConnection.RandomGeekEntities.Game.Where(x => x.IDGameGenre == 14).ToList());
            this.DataContext = this;

            StrategiesLv.ItemsSource = strategies;

            shooters = new List<Game>(DbConnection.RandomGeekEntities.Game.Where(x => x.IDGameGenre == 11).ToList());
            this.DataContext = this;

            ShootersLv.ItemsSource = shooters;

            if (!Auth.isAuth)
            {
                ExitSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg"));
                ProfileSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/SignIn.png"));
            }
            else
            {
                ExitSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Exit.png"));
                ProfileSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Profile.png"));
            }
            if (Auth.isAdmin(Auth.user))
            {
                SettingsImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Settings.png"));
            }
            else
            {
                SettingsImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg"));
            }
        }
           

        private void MoveToAuthPage_MouseDown(object sender, MouseEventArgs e)
        {

            if (Auth.isAuth)
            {
                NavigationService.Navigate(new ProfilePage(userToSend));
            }
            else
            {
                NavigationService.Navigate(new AuthorizationPage());
            }
        }

        private void MoveToGamesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new GamesPage(userToSend));
        }

        private void MoveToCinemaPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CinemaPage(userToSend));
        }

        private void MoveToMainPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(userToSend));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GameCardPage(userToSend));
        }

        private void MoveToSettingsPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isAdmin(Auth.user))
            {
                NavigationService.Navigate(new AdminPage(userToSend));
            }
            else
            {

            }

        }
        private void MoveToAuthorizationPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ExitSignInImg.Source == new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg")))
            {

            }
            else NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
