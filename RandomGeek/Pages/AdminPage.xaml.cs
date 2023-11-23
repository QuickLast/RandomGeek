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
  
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AddMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMoviePage());
        }

        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGamePage());
        }
    }
}
