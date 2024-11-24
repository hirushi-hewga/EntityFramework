using Airport_Data_Access;
using Airport_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
    
    public class Flight_
    {
        public string ArrivalCountry { get; set; }
        [Required]
        public string ArrivalCity { get; set; }
        public string FlightDate { get; set; }
        public string AircraftType { get; set; }
        public string AircraftModel { get; set; }
    }

    public partial class MainWindow : Window
    {
        public AirportDbContext dbContext = new AirportDbContext();
        public MainWindow()
        {
            InitializeComponent();
            LoadDate();
            LoadCities();
            UpdateButtonState();
            LoadFlights();
        }

        public void LoadFlights()
        {
            listBox.ItemsSource = GetFlightDetails();
        }

        public List<Flight_> GetFlightDetails()
        {
            return dbContext.Flights
                .Include(f => f.ArrivalCity)
                .ThenInclude(ac => ac.Country)
                .Include(f => f.Aircraft)
                .ThenInclude(a => a.AircraftType)
                .Select(f => new Flight_()
                {
                    ArrivalCountry = f.ArrivalCity.Country.CountryName,
                    ArrivalCity = f.ArrivalCity.CityName,
                    FlightDate = f.FlightDate.ToString("yyyy-MM-dd"),
                    AircraftType = f.Aircraft.AircraftType.TypeName,
                    AircraftModel = f.Aircraft.AircraftModel
                })
                .ToList();
        }

        public void LoadDate()
        {
            for (int i = 2000; i <= DateTime.Now.Year; i++) year_combobox.Items.Add(i);
            for (int i = 1; i <= 12; i++) month_combobox.Items.Add(i);
            for (int i = 1; i <= 31; i++) day_combobox.Items.Add(i);
        }

        public void LoadCities()
        {
            List<City> cities = dbContext.Cities.ToList();
            foreach (var item in cities) city_combobox.Items.Add(item.CityName);
        }

        private void UpdateButtonState()
        {
            button.IsEnabled = (year_combobox.SelectedItem == null && 
                                month_combobox.SelectedItem == null && 
                                day_combobox.SelectedItem == null && 
                                city_combobox.SelectedItem == null) ? false : true;
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Flight_> flights_ = GetFlightDetails();
            if (year_combobox.SelectedItem != null)
                flights_ = flights_.Where(f => DateTime.ParseExact(f.FlightDate, "yyyy-MM-dd", null).Year == (int)year_combobox.SelectedItem);
            if (month_combobox.SelectedItem != null)
                flights_ = flights_.Where(f => DateTime.ParseExact(f.FlightDate, "yyyy-MM-dd", null).Month == (int)month_combobox.SelectedItem);
            if (day_combobox.SelectedItem != null)
                flights_ = flights_.Where(f => DateTime.ParseExact(f.FlightDate, "yyyy-MM-dd", null).Day == (int)day_combobox.SelectedItem);
            if (city_combobox.SelectedItem != null)
                flights_ = flights_.Where(f => f.ArrivalCity == city_combobox.SelectedItem.ToString());
            listBox.ItemsSource = flights_ ?? null;
        }
    }
}