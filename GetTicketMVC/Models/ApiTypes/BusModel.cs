namespace GetTicketMVC.Models.ApiTypes
{
    public class BusModel
    {
        public int BusID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
        public string? BusFirmName { get; set; }
    }
}
