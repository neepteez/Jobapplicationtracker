namespace JobTracker
{

    // Denna klass hanterar alla jobbansökningar
    public class JobManager
    {
        // Lista som lagrar alla ansökningar
        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();

        // Lägger till en ny ansökan i listan
        public void AddJob(JobApplication job)
        {
            Applications.Add(job);
        }

        // Uppdaterar status för ett specifikt företag
        public void UpdateStatus(string company, StatusType newStatus)
        {
            // Letar upp första matchningen i listan (ignorerar stora/små bokstäver)
            var job = Applications.FirstOrDefault(a => a.CompanyName.Equals(company, StringComparison.OrdinalIgnoreCase));

            // Om vi hittar jobbet
            if (job != null)
            {
                job.Status = newStatus; // Uppdatera statusen
                Console.WriteLine("Status uppdaterad!");
            }
            else
            {
                Console.WriteLine("Företaget hittades inte.");
            }
        }

        // Skriver ut alla ansökningar
        public void ShowAll()
        {
            foreach (var job in Applications)
            {
                Console.WriteLine(job.GetSummary());
            }
        }

        // LINQ: Filtrerar efter status
        public void ShowByStatus(StatusType status)
        {
            var filtered = Applications.Where(a => a.Status == status); // Hämtar alla med vald status

            foreach (var job in filtered)
                Console.WriteLine(job.GetSummary());
        }

        //  LINQ: Sorterar ansökningar efter datum
        public void ShowSortedByDate()
        {
            var sorted = Applications.OrderBy(a => a.ApplicationDate); // Sorterar stigande efter datum
            foreach (var job in sorted)
                Console.WriteLine(job.GetSummary());
        }

        // 📊 LINQ: Visar statistik
        public void ShowStatistics()
        {
            // Totalt antal ansökningar
            Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");

            // Räknar antal per status (GroupBy)
            var byStatus = Applications
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() });

            foreach (var s in byStatus)
                Console.WriteLine($"{s.Status}: {s.Count}");

            // Genomsnittlig svarstid (endast de med svar)
            var avgResponse = Applications
                .Where(a => a.ResponseDate != null)
                .Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);

            Console.WriteLine($"Genomsnittlig svarstid: {avgResponse:F1} dagar");
        }
    }






}
