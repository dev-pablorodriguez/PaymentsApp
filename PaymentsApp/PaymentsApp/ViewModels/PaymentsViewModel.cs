using PaymentsApp.Models;
using PaymentsApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PaymentsApp.ViewModels
{
    public class PaymentsViewModel : BaseViewModel
    {
        private Payment _selectedItem;

        public ObservableCollection<Payment> Items { get; }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Payment> ItemTapped { get; }

        public PaymentsViewModel()
        {
            Title = $"Pagos {DateTime.Now.ToString("MMMM yyyy", CultureInfo.GetCultureInfo("es-CL"))}";
            Items = new ObservableCollection<Payment>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Payment>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await Service.GetItemsAsync(DateTime.Now.Year, DateTime.Now.Month);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Payment SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPaymentPage));
        }

        async void OnItemSelected(Payment item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PaymentDetailPage)}?{nameof(PaymentDetailViewModel.ItemId)}={item.ID}");
        }
    }
}