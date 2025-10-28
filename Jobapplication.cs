namespace JobTracker
{
    using System;

    // Den här klassen representerar en enskild jobbansökan
    public class JobApplication
    {
        // Företagets namn
        public string CompanyName { get; set; }

        // Jobbtitel eller position
        public string PositionTitle { get; set; }

        // Status på ansökan – vi använder en enum (Applied, Interview, Offer, Rejected)
        public StatusType Status { get; set; }

        // Datum när ansökan skickades
        public DateTime ApplicationDate { get; set; }

        // Datum när man fick svar (kan vara null om man inte fått svar ännu)
        public DateTime? ResponseDate { get; set; }  // <-- Den här raden är superviktig!

        // Löneförväntan i kronor
        public int SalaryExpectation { get; set; }

        // Metod som räknar ut hur många dagar som gått sedan man ansökte
        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }

        // Metod som ger en kort sammanfattning av ansökan
        public string GetSummary()
        {
            return $"{CompanyName} - {PositionTitle} ({Status}), skickad: {ApplicationDate.ToShortDateString()}";
        }
    }

    // Enum som visar möjliga statusar
    public enum StatusType
    {
        Applied,     // Ansökan skickad
        Interview,   // Intervju bokad/genomförd
        Offer,       // Erbjudande fått
        Rejected     // Fått avslag
    }









}












