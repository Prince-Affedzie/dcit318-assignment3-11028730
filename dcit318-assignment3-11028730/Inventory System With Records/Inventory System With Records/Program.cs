using Inventory_System_With_Records;

public static class Program
{
    public static void Main()
    {
        string filePath = "inventory.json";
        var app = new InventoryApp(filePath);

        // Seed and save
        app.SeedSampleData();
        app.SaveData();

        // Simulate a fresh session
        app = new InventoryApp(filePath);
        app.LoadData();
        app.PrintAllItems();
    }
}