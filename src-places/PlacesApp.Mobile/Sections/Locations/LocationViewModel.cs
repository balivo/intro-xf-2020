using PlacesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlacesApp.Mobile.Sections.Locations
{
    sealed class LocationViewModel : BasePageViewModel
    {
        public LocationViewModel(LocationModel model)
        {
            Location = model;
        }

        public LocationModel Location;

        public override Task Initialize(object args = null)
        {
            return base.Initialize(args);
        }
    }
}
