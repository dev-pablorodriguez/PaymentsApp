using PaymentsApp.Models;
using PaymentsApp.ViewModels;
using PaymentsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaymentsApp.Views
{
    public partial class PaymentsPage : ContentPage
    {
        PaymentsViewModel _viewModel;

        public PaymentsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PaymentsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}