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
    /// Логика взаимодействия для GameCardPage.xaml
    /// </summary>
    public partial class GameCardPage : Page
    {
        public static List<Movie> movies { get; set; }
        public Game randomGame;
        public MovieGenre randomGameGenre;
        User userToSend;
        public GameCardPage(User user)
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
            int randomInt = random.Next(1, 26);
            randomGame = DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game;
            GameNameTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Name;
            GameDescTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Description;
            GameGenreTBk.Text = (DbConnection.RandomGeekEntities.GameGenre.Where(x => x.IDGameGenre == randomGame.IDGameGenre).ToList()[0] as GameGenre).Name;
            GameCompanyTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Publisher;
            GameYearTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Year.ToString();
            GameIMG.Source = ToImage((DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Photo);
            GameRatingTBk.Text += (DbConnection.RandomGeekEntities.Movie.Where(x => x.IDMovie == randomInt).ToList()[0] as Movie).Rating.ToString();

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
