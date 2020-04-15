using BuscaCep.Mobile.Data.Dtos;
using System.Threading.Tasks;

namespace BuscaCep.Mobile.ViewModels
{
    sealed class CepViewModel : BasePageViewModel
    {
        private CepDto _CepDto;

        public bool HasCep { get => !(_CepDto is null); }

        public string Logradouro { get => _CepDto?.logradouro; }

        public string Cep { get => _CepDto?.cep; }

        public string Complemento { get => _CepDto?.complemento; }

        public string Bairro { get => _CepDto?.bairro; }

        public string Localidade { get => _CepDto?.localidade; }

        public string UF { get => _CepDto?.uf; }

        internal override Task InitializeAsync(object parameter)
        {
            _CepDto = (CepDto)parameter;

            OnPropertyChanged(nameof(HasCep));
            OnPropertyChanged(nameof(Logradouro));
            OnPropertyChanged(nameof(Cep));
            OnPropertyChanged(nameof(Complemento));
            OnPropertyChanged(nameof(Bairro));
            OnPropertyChanged(nameof(Localidade));
            OnPropertyChanged(nameof(UF));

            return Task.CompletedTask;
        }
    }
}

