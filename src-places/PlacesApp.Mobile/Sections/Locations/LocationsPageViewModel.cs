using PlacesApp.Mobile.Clients;
using PlacesApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlacesApp.Mobile.Sections.Locations
{
    sealed class LocationsPageViewModel : BasePageViewModel
    {
        public LocationsPageViewModel()
        {
            Title = "Locations";
        }

        public ObservableCollection<LocationModel> Locations
        {
            get;
            private set;
        } = new ObservableCollection<LocationModel>();

        public override async Task Initialize(object args = null)
        {
            await base.Initialize(args);

            foreach (var locationModel in PlacesClient.Current.GetLocations())
            {
                Locations.Add(locationModel);
            }
        }
    }
}