using MvvmHelpers.Commands;
using PlacesApp.Mobile.Clients;
using PlacesApp.Mobile.Views;
using PlacesApp.Models;
using System;
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

        private LocationFilters _SelectedFilter = LocationFilters.Todos;
        public LocationFilters SelectedFilter
        {
            get => _SelectedFilter;
            set => SetProperty(ref _SelectedFilter, value);
        }

        private AsyncCommand<LocationModel> _SelecionarCommand;
        public AsyncCommand<LocationModel> SelecionarCommand
            => _SelecionarCommand
            ??= new AsyncCommand<LocationModel>(
                execute: SelecionarCommandExecute,
                canExecute: SelecionarCommandCanExecute,
                onException: CommandOnException);

        private bool SelecionarCommandCanExecute(object arg) => true;

        private Task SelecionarCommandExecute(LocationModel location)
            => NavigationService.Navigate<LocationViewModel>(location);

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