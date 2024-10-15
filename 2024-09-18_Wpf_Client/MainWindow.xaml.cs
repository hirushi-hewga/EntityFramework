using _2024_09_18___HW__Intro_to_EntityFramework_;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2024_09_18_Wpf_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MusicDbContext MusicDb = new MusicDbContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Countries;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Artists;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Genres;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Albums;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Tracks;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Categories;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = MusicDb.Playlists;
        }
    }
}