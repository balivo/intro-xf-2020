using ShellPresentation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellPresentation.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string itemName;

        public string ItemName
        {
            get => itemName;
            set => SetProperty(ref itemName, value);
        }

        private string itemDescription;

        public string ItemDescription
        {
            get => itemDescription;
            set => SetProperty(ref itemDescription, value);
        }

        public Command CancelCommand => new AsyncCommand(CancelCommandExecute);

        async Task CancelCommandExecute()
        {
            await Navigation.GoToAsync("..").ConfigureAwait(false);
        }

        public Command AddCommand => new AsyncCommand(AddCommandExecute);

        async Task AddCommandExecute()
        {
            var item = new Item
            {
                Text = ItemName,
                Description = ItemDescription
            };
            //MessagingCenter.Send(this, "AddItem", item);

            await Navigation.GoToAsync("..", item).ConfigureAwait(false);

        }

        public NewItemViewModel()
        {
        }
    }
}
