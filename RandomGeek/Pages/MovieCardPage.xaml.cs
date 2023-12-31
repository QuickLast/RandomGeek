﻿using Microsoft.Win32;
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
        public Movie randomMovie;
        public MovieGenre randomMovieGenre;
        User userToSend;
        public MovieCardPage(User user)
        {
            InitializeComponent();

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

            if (Auth.isAdmin(Auth.user))
            {
                SettingsImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Settings.png"));
            }
            else
            {
                SettingsImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg"));
            }

            Random random = new Random();
            int randomInt = random.Next(DbConnection.RandomGeekEntities.Movie.ToList()[0].IDMovie, DbConnection.RandomGeekEntities.Movie.ToList().Count);
            randomMovie = DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie;
            Auth.randomWatched.Add(randomMovie);
            MovieNameTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Name;
            MovieDescTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Description;
            MovieGenreTBk.Text = (DbConnection.RandomGeekEntities.MovieGenre.Where(x => x.IDMovieGenre == randomMovie.IDMovieGenre).ToList()[0] as MovieGenre).Name;
            MovieCompanyTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Studio;
            MovieYearTBk.Text = (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Year.ToString();
            MovieIMG.Source = ToImage((DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Photo);
            MovieRatingTBk.Text += (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Rating.ToString();

            this.DataContext = this;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MovieCardPage(userToSend));
        }

        private void MoveToGamesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new GamesPage(userToSend));
        }
        private void MoveToMainPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(userToSend));
        }

        private void MoveToCinemaPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CinemaPage(userToSend));
        }

        private void MoveToSettingsPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(userToSend));
        }

        private void MoveToAuthorizationPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ExitSignInImg.Source == new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg")))
            {

            }
            else NavigationService.Navigate(new AuthorizationPage());
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
