using MvvmHelpers.Commands;
using PlacesApp.Mobile.Services.Navigation;
using System;
using MvvmHelpersBaseViewModel = MvvmHelpers.BaseViewModel;

namespace PlacesApp.Mobile
{
    abstract class BaseViewModel : MvvmHelpersBaseViewModel
    {
        protected NavigationService NavigationService => NavigationService.Current;

        protected void CommandOnException(Exception obj)
        {
            //throw new NotImplementedException();
        }

        private AsyncCommand _GoBackCommand;
        public AsyncCommand GoBackCommand
            => _GoBackCommand
            ??= new AsyncCommand(
                execute: () => NavigationService.GoBack(),
                //canExecute: SelecionarCommandCanExecute,
                onException: CommandOnException);
    }
}
