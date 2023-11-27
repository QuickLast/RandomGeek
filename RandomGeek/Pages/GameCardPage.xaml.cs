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
        public GameCardPage()
        {
            InitializeComponent();
            Random random = new Random();
            int randomInt = random.Next(7, 52);
            randomGame = DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game;
            GameNameTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Name;
            GameDescTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Description;
            GameGenreTBk.Text = (DbConnection.RandomGeekEntities.GameGenre.Where(x => x.IDGameGenre == randomGame.IDGameGenre).ToList()[0] as GameGenre).Name;
            GameCompanyTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Publisher;
            GameYearTBk.Text = (DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Year.ToString();
            GameIMG.Source = ToImage((DbConnection.RandomGeekEntities.Game.Where(x => x.IDGame == randomInt).ToList()[0] as Game).Photo);

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
