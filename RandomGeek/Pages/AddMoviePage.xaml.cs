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
using RandomGeek.Database;

namespace RandomGeek.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMoviePage.xaml
    /// </summary>
    public partial class AddMoviePage : Page
    {
        public static List<MovieGenre> movieGenres {  get; set; }
        public static List<AgeRating> ageRating { get; set; }
        public static List<MovieType> movieType { get; set; }
        public AddMoviePage()
        {
            InitializeComponent();

            movieGenres = new List<MovieGenre>(DbConnection.RandomGeek_KamilEntities.MovieGenre.ToList());
            GenreCb.ItemsSource = movieGenres;
            GenreCb.DisplayMemberPath = "Name";

            ageRating = new List<AgeRating>(DbConnection.RandomGeek_KamilEntities.AgeRating.ToList());
            AgeRatingCb.ItemsSource = ageRating;
            AgeRatingCb.DisplayMemberPath = "Rating";

            movieType = new List<MovieType>(DbConnection.RandomGeek_KamilEntities.MovieType.ToList());
            TypeCb.ItemsSource = movieType;
            TypeCb.DisplayMemberPath = "Name";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddMoviebtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text == string.Empty || DescriptionTb.Text == string.Empty || DirectorTb.Text == string.Empty || ScreenwriterTb.Text == string.Empty || ProducerTb.Text == string.Empty || CountryProjectTb.Text == string.Empty || GenreCb.SelectedItem == null || AgeRatingCb.SelectedItem == null || TypeCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Movie movie = new Movie()
                {
                    Name = NameTb.Text,
                    Description = DescriptionTb.Text,
                    Director = DirectorTb.Text,
                    Screenwriter = ScreenwriterTb.Text,
                    Producer = ProducerTb.Text,
                    Country = CountryProjectTb.Text,
                    IDMovieGenre = (GenreCb.SelectedItem as MovieGenre).IDMovieGenre,
                    IDAgeRating = (AgeRatingCb.SelectedItem as AgeRating).IDAgeRating,
                    IDMovieType = (TypeCb.SelectedItem as MovieType).IDMovieType
                };

                DbConnection.RandomGeek_KamilEntities.Movie.Add(movie);
                DbConnection.RandomGeek_KamilEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                NavigationService.Navigate(new AdminPage());
            }
        }
    }
}
