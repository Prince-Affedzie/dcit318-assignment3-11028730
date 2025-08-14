using HealthCare_System;

public static class Program
{
    public static void Main()
    {
        var app = new HealthSystemApp();
        app.SeedData();
        app.BuildPrescriptionMap();
        app.PrintAllPatients();

        Console.WriteLine("\nEnter a Patient ID to view prescriptions:");
        if (int.TryParse(Console.ReadLine(), out int pid))
        {
            app.PrintPrescriptionsForPatient(pid);
        }
        else
        {
            Console.WriteLine("Invalid ID entered.");
        }
    }
}