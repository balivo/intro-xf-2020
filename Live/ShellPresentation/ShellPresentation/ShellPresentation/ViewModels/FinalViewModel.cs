using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShellPresentation.ViewModels
{
    public class FinalViewModel : BaseViewModel
    {
        public Command BackCommand => new AsyncCommand(async () =>
        {
            await Navigation.GoToAsync("../..").ConfigureAwait(false);
        });
    }
}
