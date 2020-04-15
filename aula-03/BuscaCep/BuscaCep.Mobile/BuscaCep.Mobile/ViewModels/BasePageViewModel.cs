using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep.Mobile.ViewModels
{
    abstract class BasePageViewModel : BaseViewModel
    {
        internal abstract Task InitializeAsync(object parameter);
    }
}
