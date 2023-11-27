using Microsoft.Win32;
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
    /// Логика взаимодействия для MovieCardPage.xaml
    /// </summary>
    public partial class MovieCardPage : Page
    {
        public static List<Movie> movies {  get; set; }
        public static Movie randomMovie;
        public static MovieGenre randomMovieGenre;
        public MovieCardPage()
        {
            InitializeComponent();
            Random random = new Random();
            int randomInt = random.Next(7, 52);
            randomMovie = DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie;
            MovieNameTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Name;
            MovieDescTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Description;
            MovieGenreTBk.Text = (DbConnection.RandomGeekEntities.MovieGenre.Where(x => x.IDMovieGenre == randomMovie.IDMovieGenre).ToList()[0] as MovieGenre).Name;
            MovieCompanyTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Studio;
            MovieYearTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Year.ToString();
            MovieIMG.Source = new BitmapImage(new Uri(randomMovie.Photo.ToString()));

            this.DataContext = this;
        }
        private void MoveToAuthPage_MouseDown(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void MoveToGamesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new GamesPage());
        }
        private void MoveToMainPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(Auth.user));
        }

        private void MoveToCinemaPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CinemaPage());
        }

        private void MoveToSettingsPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }
    }
}
