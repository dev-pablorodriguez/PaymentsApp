using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsApp.Persistences
{
    public interface IPersistence<T>
    {
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<IEnumerable<T>> GetItemsAsync(int year);
        Task<IEnumerable<T>> GetItemsAsync(int year, int month);
        Task<int> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(int id);
    }
}
