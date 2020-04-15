using BuscaCep.Mobile.Pages;
using BuscaCep.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscaCep.Mobile.Services.Navigation
{
    sealed class NavigationService
    {
        private static Lazy<NavigationService> _Lazy = new Lazy<NavigationService>(() => new NavigationService());

        public static NavigationService Current { get => _Lazy.Value; }

        private NavigationService()
        {
            _Mappings = new Dictionary<Type, Type>();
            CreateViewModelMappings();
        }

        private readonly Dictionary<Type, Type> _Mappings;

        private void CreateViewModelMappings()
        {
            _Mappings.Add(typeof(CepsViewModel), typeof(CepsPage));
            _Mappings.Add(typeof(CepViewModel), typeof(CepPage));
        }

        private Application CurrentApplication => Application.Current;

        private INavigation Navigation { get => ((CustomNavigationPage)CurrentApplication.MainPage).Navigation; }

        internal Task Navigate<TViewModel>(object parameter = null)
            where TViewModel : BasePageViewModel
            => InternalNavigate(typeof(TViewModel), parameter);

        private async Task InternalNavigate(Type viewModelType, object parameter = null)
        {
            try
            {
                Page page = null;

                // Verificar se estou indo para a página inicial...
                if (viewModelType == typeof(CepsViewModel))
                {
                    // Se a página inicial não foi carregada...
                    if (!Navigation.NavigationStack.Any(lbda => lbda.BindingContext.GetType() == typeof(CepsViewModel)))
                    {
                        page = CreateAndBindPage(viewModelType);

                        var pagesToRemove = Navigation.NavigationStack.ToList();

                        await Navigation.PushAsync(page);

                        foreach (var pageToRemove in pagesToRemove)
                        {
                            Navigation.RemovePage(pageToRemove);
                        }
                    }
                    else
                        await GoBack(toRoot: true);
                }
                else
                {
                    page = CreateAndBindPage(viewModelType);

                    if (viewModelType.BaseType == typeof(BaseModalPageViewModel))
                        await Navigation.PushModalAsync(page, true);
                    else
                        await Navigation.PushAsync(page, true);
                }

                if (!(page is null))
                    await (page.BindingContext as BasePageViewModel).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task GoBack(bool toRoot = false, bool animated = true)
        {
            if (toRoot)
                return Navigation.PopToRootAsync(animated);

            if (Navigation.ModalStack.Count > 0)
                return Navigation.PopModalAsync(animated);

            return Navigation.PopAsync(animated);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            try
            {
                if (!_Mappings.ContainsKey(viewModelType))
                    throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");

                return _Mappings[viewModelType];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Page CreateAndBindPage(Type viewModelType)
        {
            try
            {
                Type pageType = GetPageTypeForViewModel(viewModelType);

                if (pageType == null)
                    throw new Exception($"Mapping type for {viewModelType} is not a page");

                Page page = Activator.CreateInstance(pageType) as Page;
                page.BindingContext = Activator.CreateInstance(viewModelType) as BasePageViewModel;

                return page;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Initialize(object args = null)
        {
            CurrentApplication.MainPage = new CustomNavigationPage();

            Device.BeginInvokeOnMainThread(async () => await Navigate<CepsViewModel>(args));
        }
    }
}
