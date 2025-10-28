namespace JobTracker
{
    internal class Program
    {
        static void Main()
        {
            // Skapar en ny instans av JobManager som hanterar våra ansökningar
            JobManager manager = new JobManager();

            // Håller programmet igång tills användaren väljer att avsluta
            bool running = true;

            while (running)
            {
                // Skriver ut menyvalen
                Console.WriteLine("\n===== Job Application Tracker =====");
                Console.WriteLine("1. ➕ Lägg till ny ansökan");
                Console.WriteLine("2. 📋 Visa alla ansökningar");
                Console.WriteLine("3. 🔍 Filtrera efter status");
                Console.WriteLine("4. 📅 Sortera efter datum");
                Console.WriteLine("5. 📊 Visa statistik");
                Console.WriteLine("6. ✏️ Uppdatera status");
                Console.WriteLine("7. 💾 Avsluta programmet");
                Console.Write("Välj ett alternativ: ");

                // Läser användarens val
                switch (Console.ReadLine())
                {
                    case "1":
                        // Lägga till en ny ansökan
                        Console.Write("Företag: ");
                        string company = Console.ReadLine();

                        Console.Write("Position: ");
                        string position = Console.ReadLine();

                        Console.Write("Lön (kr): ");
                        int salary = int.Parse(Console.ReadLine());

                        // Skapa nytt objekt och lägg till i listan
                        manager.AddJob(new JobApplication
                        {
                            CompanyName = company,
                            PositionTitle = position,
                            SalaryExpectation = salary,
                            Status = StatusType.Applied, // Standardstatus
                            ApplicationDate = DateTime.Now // Dagens datum
                        });
                        break;

                    case "2":
                        // Visa alla ansökningar
                        manager.ShowAll();
                        break;

                    case "3":
                        // Filtrera efter status
                        Console.WriteLine("Välj status (Applied, Interview, Offer, Rejected):");
                        if (Enum.TryParse(Console.ReadLine(), out StatusType status))
                            manager.ShowByStatus(status);
                        else
                            Console.WriteLine("Ogiltig status.");
                        break;

                    case "4":
                        // Sortera efter datum
                        manager.ShowSortedByDate();
                        break;

                    case "5":
                        // Visa statistik (antal, genomsnittlig svarstid osv.)
                        manager.ShowStatistics();
                        break;

                    case "6":
                        // Uppdatera status för ett företag
                        Console.Write("Vilket företag vill du uppdatera?: ");
                        string name = Console.ReadLine();

                        Console.Write("Ny status (Applied, Interview, Offer, Rejected): ");
                        if (Enum.TryParse(Console.ReadLine(), out StatusType newStatus))
                            manager.UpdateStatus(name, newStatus);
                        else
                            Console.WriteLine("Ogiltig status.");
                        break;

                    case "7":
                        // Avsluta programmet
                        running = false;
                        break;

                    default:
                        // Ogiltigt menyval
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }





}

