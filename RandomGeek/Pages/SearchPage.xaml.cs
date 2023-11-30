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
using static System.Net.Mime.MediaTypeNames;

namespace RandomGeek.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        User userToSend;
        public static List<Movie> movies = DbConnection.RandomGeekEntities.Movie.ToList();
        public static List<Game> games = DbConnection.RandomGeekEntities.Game.ToList();
        public SearchPage(User user, String textFromSearch)
        {
            InitializeComponent();

            SearchTBx.Text = textFromSearch;

            if (SearchTBx.Text.Trim() != String.Empty)
            {
                SearchLV.ItemsSource = movies.Where(x => x.Name.ToLower().Contains(SearchTBx.Text.Trim().ToLower()));
                SearchGamesLV.ItemsSource = games.Where(x => x.Name.ToLower().Contains(SearchTBx.Text.Trim().ToLower()));
            }

            userToSend = user;
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

            if (Auth.isAdmin(user))
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

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                NavigationService.Navigate(new SearchPage(userToSend, SearchTBx.Text));
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

        private void MoveToSettingsPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Auth.isAdmin(userToSend))
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

        private void SearchTBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTBx.Text.Trim() != String.Empty)
            {
                SearchLV.ItemsSource = movies.Where(x => x.Name.ToLower().Contains(SearchTBx.Text.Trim().ToLower()));
                SearchGamesLV.ItemsSource = games.Where(x => x.Name.ToLower().Contains(SearchTBx.Text.Trim().ToLower()));
            }
        }
        private void WatchedMoviesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = ((ListView)sender).SelectedItem as Movie;
            NavigationService.Navigate(new ListViewCardPage(userToSend, new ProfilePage(userToSend), t));
        }

        private void WatchedGamesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = ((ListView)sender).SelectedItem as Game;
            NavigationService.Navigate(new ListViewCardPageGames(userToSend, new ProfilePage(userToSend), t));
        }
    }
}
