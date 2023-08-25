namespace GetTicketMVC.Areas.AdminPanel.Models.Dtos
{
    public class NewBusJourneyDto
    {
        public string? DestinationPoint { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public int? BusID { get; set; }
       
    }
}
