using PaymentsApp.Models;
using PaymentsApp.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PaymentsApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(NewPaymentPage)));
        }

        public ICommand OpenWebCommand { get; }
    }
}