namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus
{
    public class BusList
    {
        public int BusID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
        public string? BusFirmName { get; set; }
    }
}
