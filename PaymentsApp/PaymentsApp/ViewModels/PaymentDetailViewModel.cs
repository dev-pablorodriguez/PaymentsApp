using PaymentsApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PaymentsApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PaymentDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string date;
        private string price;

        public string Id { get; set; }

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

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await Service.GetItemAsync(int.Parse(itemId));
                Id = item.ID.ToString();
                Text = item.Text;
                Description = item.Description;
                Date = item.Date.ToString("dd-MM-yyyy HH:mm:ss");
                Price = item.Price.ToString();
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            }
        }
    }
}
