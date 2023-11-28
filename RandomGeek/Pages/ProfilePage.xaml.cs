using Microsoft.Win32;
using RandomGeek.Database;
using RandomGeek.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static List<Movie> movies { get; set; }
        User userToSend;
        public ProfilePage(User user)
        {
            InitializeComponent();

            userToSend = user;

            UserNameTBk.Text = Auth.user.Name;

            Random random = new Random();

            ProfilePictureImg.Source = new BitmapImage(new Uri($"pack://application:,,,/RandomGeek;component/Assets/Images/Profile{random.Next(1,4)}.png"));

            WatchedMoviesLv.ItemsSource = Auth.randomWatched.AsEnumerable().Reverse();
            this.DataContext = this;

            if (Auth.randomWatched.Count == 0)
            {
                WatchedMovieTBk.Text = "На данный момент вы еще не воспользовались нашей магией, а зря!";
            }


            if (!Auth.isAuth)
            {
                ExitSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg"));            }
            else
            {
                ExitSignInImg.Source = new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Exit.png"));
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
            NavigationService.Navigate(new AdminPage(userToSend));
        }

        private void MoveToAuthPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
        private void MoveToMainPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(userToSend));
        }
        private void MoveToAuthorizationPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ExitSignInImg.Source == new BitmapImage(new Uri("pack://application:,,,/RandomGeek;component/Assets/Images/Zamena.jpg")))
            {

            }
            else NavigationService.Navigate(new AuthorizationPage());
        }

        private void ChoosePhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                Auth.user.Photo = File.ReadAllBytes(openFileDialog.FileName);
                ProfilePictureImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

            DbConnection.RandomGeekEntities.User.AddOrUpdate(Auth.user);
            DbConnection.RandomGeekEntities.SaveChanges();

            MessageBox.Show("Фотография профиля обновлена.");
        }
    }
}
