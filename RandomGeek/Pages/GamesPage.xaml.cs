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
        public GamesPage()
        {
            InitializeComponent();

            games = new List<Game>(DbConnection.RandomGeek_KamilEntities.Game.ToList());
            this.DataContext = this;

            BestGamesLv.ItemsSource = games;

            strategies = new List<Game>(DbConnection.RandomGeek_KamilEntities.Game.Where(x => x.IDGameGenre == 1).ToList());
            this.DataContext = this;

            StrategiesLv.ItemsSource = strategies;

            shooters = new List<Game>(DbConnection.RandomGeek_KamilEntities.Game.Where(x => x.IDGameGenre == 2).ToList());
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
                NavigationService.Navigate(new ProfilePage());
            }
            else
            {
                NavigationService.Navigate(new AuthorizationPage());
            }
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
