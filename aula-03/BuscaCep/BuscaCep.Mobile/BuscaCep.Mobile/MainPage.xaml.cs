using BuscaCep.Mobile.Data.Dtos;
using BuscaCep.Mobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscaCep.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        BuscaCepViewModel ViewModel { get => ((BuscaCepViewModel)BindingContext); }

        public MainPage()
        {
            InitializeComponent();

            // = new ();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ViewModel.CEP))
                    return;

                using (var client = new HttpClient())
                {
                    //viacep.com.br/ws/01001000/json/
                    using (var response = await client.GetAsync($"https://viacep.com.br/ws/{ViewModel.CEP}/json/"))
                    {
                        response.EnsureSuccessStatusCode();

                        var content = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrWhiteSpace(content))
                            throw new InvalidOperationException();

                        var retorno = JsonConvert.DeserializeObject<CepDto>(content);

                        if (retorno.erro)
                            throw new InvalidOperationException();

                        txtLogradouro.Text = retorno.logradouro;
                        txtComplemento.Text = retorno.complemento;
                        txtBairro.Text = retorno.bairro;
                        txtLocalidade.Text = retorno.localidade;
                        txtUF.Text = retorno.uf;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Algo de errado não deu certo!", "Ok");
            }
        }
    }
}