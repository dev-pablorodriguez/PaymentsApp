using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsApp.Services
{
    public interface IService<T>
    {
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<IEnumerable<T>> GetItemsAsync(int year);
        Task<IEnumerable<T>> GetItemsAsync(int year, int month);
        Task<int> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(int id);
    }
}
