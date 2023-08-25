namespace GetTicketMVC.Models.ApiTypes
{
    public class MyJourney
    {
        public int JourneyID { get; set; }
        public int? SeatNo { get; set; }
        public GetBusJourney? BusJourneyDto { get; set; }
        public GetPassenger? GetPassengerDto { get; set; }

    }
}
