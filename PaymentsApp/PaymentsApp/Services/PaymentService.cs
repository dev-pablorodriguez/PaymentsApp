using Nancy.TinyIoc;
using PaymentsApp.Models;
using PaymentsApp.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PaymentsApp.Services
{
    public class PaymentService : IService<Payment>
    {
        public IPersistence<Payment> PagoPersistence => TinyIoCContainer.Current.Resolve<IPersistence<Payment>>();

        public async Task<Payment> GetItemAsync(int id)
        {
            return await PagoPersistence.GetItemAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync()
        {
            return await PagoPersistence.GetItemsAsync();
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync(int year)
        {
            return await PagoPersistence.GetItemsAsync(year);
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync(int year, int month)
        {
            return await PagoPersistence.GetItemsAsync(year, month);
        }

        public async Task<int> SaveItemAsync(Payment item)
        {
            return await PagoPersistence.SaveItemAsync(item);
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            return await PagoPersistence.DeleteItemAsync(id);
        }        
    }
}