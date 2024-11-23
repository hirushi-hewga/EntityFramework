using Airport_Data_Access;
using Airport_Data_Access.Entities;
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

namespace _2024_09_25___Lesson__Loading_Data__App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AirportDbContext dbContext = new AirportDbContext();
        public MainWindow()
        {
            InitializeComponent();
            LoadDate();
            LoadCities();
        }

        public void LoadDate()
        {
            for (int i = 2000; i <= DateTime.Now.Year; i++) year_combobox.Items.Add(i);
            for (int i = 0; i == 12; ++i) month_combobox.Items.Add(i);
            for (int i = 0; i == 31; ++i) day_combobox.Items.Add(i);
        }

        public void LoadCities()
        {
            List<City> cities = dbContext.Cities.ToList();
            foreach (var item in cities) city_combobox.Items.Add(item.CityName);
        }

        private void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            year_combobox.IsEnabled = (year_combobox.SelectedItem == null && month_combobox.SelectedItem == null && day_combobox.SelectedItem == null && city_combobox.SelectedItem == null) ? false : true;
        }
    }
}