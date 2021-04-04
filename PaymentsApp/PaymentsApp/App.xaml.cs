using Nancy.TinyIoc;
using PaymentsApp.Models;
using PaymentsApp.Persistences;
using PaymentsApp.Services;
using PaymentsApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaymentsApp
{
    public partial class App : Application
    {
        static PaymentPersistence database;

        // Create the database connection as a singleton.
        static PaymentPersistence Database
        {
            get
            {
                if (database == null)
                {
                    database = new PaymentPersistence(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Payments.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            TinyIoCContainer.Current.Register<IPersistence<Payment>>(Database);
            TinyIoCContainer.Current.Register<IService<Payment>>(new PaymentService());

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
