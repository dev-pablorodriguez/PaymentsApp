using PaymentsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PaymentsApp.ViewModels
{
    public class NewPaymentViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string price;

        public NewPaymentViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return
                !string.IsNullOrWhiteSpace(text) &&
                !string.IsNullOrWhiteSpace(price) &&
                int.TryParse(price, out _);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            try
            {
                Payment newItem = new Payment()
                {
                    ID = 0,
                    Text = Text,
                    Description = Description,
                    Date = DateTime.Now,
                    Price = int.Parse(price)
                };

                await Service.SaveItemAsync(newItem);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            }
        }
    }
}
