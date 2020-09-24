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
    public partial class LocationItemView : ContentView
    {
        public LocationItemView()
        {
            InitializeComponent();
        }
    }
}