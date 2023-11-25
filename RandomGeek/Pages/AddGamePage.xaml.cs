using Microsoft.Win32;
using RandomGeek.Database;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddGamePage.xaml
    /// </summary>
    public partial class AddGamePage : Page
    {
        public static List<GameGenre> gameGenres { get; set; }
        public static Game game = new Game();
        public AddGamePage()
        {
            InitializeComponent();

            /*gameGenres = new List<MovieGenre>(DbConnection.RandomGeek_KamilEntities.MovieGenre.ToList());
            GenreCBx.ItemsSource = movieGenres;
            GenreCBx.DisplayMemberPath = "Name";
            movieType = new List<MovieType>(DbConnection.RandomGeek_KamilEntities.MovieType.ToList());
            TypeCBx.ItemsSource = movieType;
            TypeCBx.DisplayMemberPath = "Name";*/
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                game.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PreviewImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
