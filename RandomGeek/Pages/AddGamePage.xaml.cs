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
        public static Game gameToAdd = new Game();
        User userToSend;
        public AddGamePage(User user)
        {
            InitializeComponent();

            userToSend = user;

            gameGenres = new List<GameGenre>(DbConnection.RandomGeekEntities.GameGenre.ToList());
            GenreCBx.ItemsSource = gameGenres;
            GenreCBx.DisplayMemberPath = "Name";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(userToSend));
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                gameToAdd.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PreviewImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void AddGamebtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == string.Empty || DescriptionTbx.Text == string.Empty || RatingTbx.Text == string.Empty || PlatformTbx.Text == string.Empty || CompanyTbx.Text == string.Empty || StartYearTbx.Text == string.Empty || GenreCBx.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Game game = new Game()
                {
                    Name = NameTbx.Text,
                    Description = DescriptionTbx.Text,
                    Publisher = CompanyTbx.Text,
                    Rating = float.Parse(RatingTbx.Text),
                    Platforms = PlatformTbx.Text,
                    Year = int.Parse(StartYearTbx.Text),
                    IDGameGenre = (GenreCBx.SelectedItem as GameGenre).IDGameGenre,
                    Photo = gameToAdd.Photo
                };

                DbConnection.RandomGeekEntities.Game.Add(game);
                DbConnection.RandomGeekEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                NavigationService.Navigate(new AdminPage(userToSend));
            }
        }
    }
}
