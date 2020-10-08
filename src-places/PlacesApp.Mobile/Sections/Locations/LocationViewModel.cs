using PlacesApp.Models;
using System;
using System.Threading.Tasks;

namespace PlacesApp.Mobile.Sections.Locations
{
    sealed class LocationViewModel : BasePageViewModel
    {
        public LocationViewModel()
        {

        }

        private LocationModel _Location;

        public string Imagem { get => _Location?.Imagem; }

        public string Nome { get => _Location?.Nome; }

        public string Descricao { get => _Location?.Descricao; }

        public DateTime Data { get => _Location?.Data ?? DateTime.Now; }

        public override async Task Initialize(object args = null)
        {
            await base.Initialize(args);

            _Location = args switch
            {
                LocationModel location => location,
                _ => throw new InvalidOperationException(
                    message: "Algo de errado não deu certo ao carregar o local"),
            };

            OnPropertyChanged(nameof(Imagem));
            OnPropertyChanged(nameof(Nome));
            OnPropertyChanged(nameof(Descricao));
            OnPropertyChanged(nameof(Data));
        }
    }
}
