using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory_System_With_Records
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new();
        private string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item) => _log.Add(item);

        public List<T> GetAll() => new List<T>(_log);

        public void SaveToFile()
        {
            try
            {
                using (var stream = new FileStream(_filePath, FileMode.Create))
                {
                    JsonSerializer.Serialize(stream, _log);
                }
                Console.WriteLine($"Data saved to {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("No file found to load data.");
                    return;
                }

                using (var stream = new FileStream(_filePath, FileMode.Open))
                {
                    var data = JsonSerializer.Deserialize<List<T>>(stream);
                    if (data != null)
                        _log = data;
                }
                Console.WriteLine($"Data loaded from {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
}
