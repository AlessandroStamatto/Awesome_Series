using AwesomeSeries.Models;
using AwesomeSeries.Services;
using AwesomeSeries.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AwesomeSeries.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly ISerieService _serieService;

        public ICommand ItemClickCommand { get; }

        public ObservableCollection<Serie> Items {
            get; set;
        }

        //new ObservableCollection<Serie>(Items.Where(
        //      serie => string.IsNullOrEmpty(serie.Name)
        //    || serie.Name.StartsWith(Search))
        //   )

        public MainViewModel(ISerieService serieService) : base("Awesome Series")
        {
            _serieService = serieService;

            Items = new ObservableCollection<Serie>();

            ItemClickCommand = new Command<Serie>(async(item) 
                => await ItemClickCommandExecute(item));
        }

        async Task ItemClickCommandExecute(Serie serie)
        {
            if (serie != null)
            {
                await NavigationService.NavigateToAsync<DetailViewModel>(serie);
            }
        }

        public override async Task InitializeAsync(object navgationData)
        {
            await base.InitializeAsync(navgationData);

            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var result = await _serieService.GetSeriesAsync();

            AddItems(result);
        }

        private void AddItems(SerieResponse result)
        {
            Items.Clear();
            result.Series.ToList()?.ForEach(serie => Items.Add(serie));
        }

        //public async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(e.NewTextValue))
        //        return;

        //    this.Items = new ObservableCollection<Serie> (this.Items.Where(
        //      serie => string.IsNullOrEmpty(serie.Name)
        //    || serie.Name.StartsWith(e.NewTextValue)));
        
        //SearchResultListView.BeginRefresh();  // IMPORTANT ***
        //collection.Items = await weatherService.GetForecastByCityOrCountry(e.NewTextValue);
        //SearchResultListView.ItemsSource = collection.Items;
        //SearchResultListView.EndRefresh(); // IMPORTANT ****
        //}
    }
}
