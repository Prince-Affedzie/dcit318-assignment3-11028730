
using Warehouse_Inventory_Management_System;

public static class Program
{
    public static void Main()
    {
        var manager = new WareHouseManager();
        manager.SeedData();

        manager.PrintAllItems(manager.GroceriesRepo);
        manager.PrintAllItems(manager.ElectronicsRepo);

        // Test exceptions
        try
        {
            manager.ElectronicsRepo.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"[Handled] {ex.Message}");
        }

        try
        {
            manager.GroceriesRepo.RemoveItem(99);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"[Handled] {ex.Message}");
        }

        try
        {
            manager.GroceriesRepo.UpdateQuantity(1, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"[Handled] {ex.Message}");
        }
    }
}