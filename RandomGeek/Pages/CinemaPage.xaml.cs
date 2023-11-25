﻿using RandomGeek.Database;
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
    /// Логика взаимодействия для CinemaPage.xaml
    /// </summary>
    public partial class CinemaPage : Page
    {
        public static List<Movie> movies {  get; set; }
        public static List<Movie> series { get; set; }
        public static List<Movie> cartoons { get; set; }
        public CinemaPage()
        {
            InitializeComponent();

            movies = new List<Movie>(DbConnection.RandomGeek_KamilEntities.Movie.Where(x => x.IDMovieType == 1).ToList());
            this.DataContext = this;

            BestMoviesLv.ItemsSource = movies;

            series = new List<Movie>(DbConnection.RandomGeek_KamilEntities.Movie.Where(x => x.IDMovieType == 2).ToList());
            this.DataContext = this;

            BestSeriesLv.ItemsSource = series;

            cartoons = new List<Movie>(DbConnection.RandomGeek_KamilEntities.Movie.Where(x => x.IDMovieType == 3).ToList());
            this.DataContext = this;

            BestCartoonsLv.ItemsSource = cartoons;
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
           // NavigationService.Navigate(new MainPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MovieCardPage());
        }
    }
}
