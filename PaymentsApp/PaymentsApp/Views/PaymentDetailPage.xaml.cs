using PaymentsApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PaymentsApp.Views
{
    public partial class PaymentDetailPage : ContentPage
    {
        public PaymentDetailPage()
        {
            InitializeComponent();
            BindingContext = new PaymentDetailViewModel();
        }
    }
}