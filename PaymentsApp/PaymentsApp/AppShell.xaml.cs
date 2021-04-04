using PaymentsApp.ViewModels;
using PaymentsApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PaymentsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PaymentDetailPage), typeof(PaymentDetailPage));
            Routing.RegisterRoute(nameof(NewPaymentPage), typeof(NewPaymentPage));
        }

    }
}
