using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System_With_Records
{
    public class InventoryApp
    {

        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Mouse", 15, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Keyboard", 10, DateTime.Now));
        }

        public void SaveData() => _logger.SaveToFile();

        public void LoadData() => _logger.LoadFromFile();

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            Console.WriteLine("\n--- Inventory Items ---");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}: {item.Name} - Qty: {item.Quantity} (Added: {item.DateAdded})");
            }
        }
    }
}
