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
using Microsoft.Win32;
using RandomGeek.Database;

namespace RandomGeek.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMoviePage.xaml
    /// </summary>
    public partial class AddMoviePage : Page
    {
        public static List<MovieGenre> movieGenres {  get; set; }
        public static List<MovieType> movieType { get; set; }
        public static Movie movieToAdd = new Movie();
        public AddMoviePage()
        {
            InitializeComponent();

            movieGenres = new List<MovieGenre>(DbConnection.RandomGeek_KamilEntities.MovieGenre.ToList());
            GenreCBx.ItemsSource = movieGenres;
            GenreCBx.DisplayMemberPath = "Name";
            movieType = new List<MovieType>(DbConnection.RandomGeek_KamilEntities.MovieType.ToList());
            TypeCBx.ItemsSource = movieType;
            TypeCBx.DisplayMemberPath = "Name";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddMoviebtn_Click(object sender, RoutedEventArgs e)
        {
                if (NameTbx.Text == string.Empty || DescriptionTbx.Text == string.Empty || DirectorTbx.Text == string.Empty || CountryProjectTbx.Text == string.Empty || GenreCBx.SelectedItem == null || TypeCBx.SelectedItem == null)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    Movie movie = new Movie()
                    {
                        Name = NameTbx.Text,
                        Description = DescriptionTbx.Text,
                        Director = DirectorTbx.Text,
                        Country = CountryProjectTbx.Text,
                        IDMovieGenre = (GenreCBx.SelectedItem as MovieGenre).IDMovieGenre,
                        IDMovieType = (TypeCBx.SelectedItem as MovieType).IDMovieType,
                        Photo = movieToAdd.Photo
                    };

                    DbConnection.RandomGeek_KamilEntities.Movie.Add(movie);
                    DbConnection.RandomGeek_KamilEntities.SaveChanges();

                    MessageBox.Show("Данные записаны!");

                    NavigationService.Navigate(new AdminPage());
                }
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                movieToAdd.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PreviewImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
