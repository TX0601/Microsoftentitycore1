using System.ComponentModel.DataAnnotations;

namespace CanteenprojectH.Models
{
    public class Calendar
    {
        [Key]
        public int CalendarId { get; set; }

        public DateTime Date { get; set; }

        public bool IsClosed { get; set; } = false; // Automatically set to true for Sundays
    }
}
