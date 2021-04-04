using PaymentsApp.Models;
using PaymentsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaymentsApp.Views
{
    public partial class NewPaymentPage : ContentPage
    {
        public Payment Item { get; set; }

        public NewPaymentPage()
        {
            InitializeComponent();
            BindingContext = new NewPaymentViewModel();
        }
    }
}