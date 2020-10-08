using MvvmHelpers;
using PlacesApp.Mobile.Services.Navigation;
using PlacesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Mobile.Sections.Locations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        LocationsPageViewModel ViewModel => (LocationsPageViewModel)BindingContext;

        public LocationsPage()
        {
            InitializeComponent();
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ViewModel
                .SelecionarCommand
                .ExecuteAsync((LocationModel)e.Item)
                .SafeFireAndForget();
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}