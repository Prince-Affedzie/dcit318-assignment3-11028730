using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class WareHouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics = new();
        private InventoryRepository<GroceryItem> _groceries = new();

        public void SeedData()
        {
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Laptop", 5, "Dell", 24));
                _electronics.AddItem(new ElectronicItem(2, "Smartphone", 10, "Samsung", 12));

                _groceries.AddItem(new GroceryItem(1, "Milk", 20, DateTime.Today.AddDays(10)));
                _groceries.AddItem(new GroceryItem(2, "Bread", 15, DateTime.Today.AddDays(3)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding data: {ex.Message}");
            }
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            Console.WriteLine($"\n--- {typeof(T).Name} Inventory ---");
            foreach (var item in repo.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Increased stock for {item.Name} by {quantity}. New quantity: {item.Quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Removed item with ID {id}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        public InventoryRepository<ElectronicItem> ElectronicsRepo => _electronics;
        public InventoryRepository<GroceryItem> GroceriesRepo => _groceries;
    }
}
