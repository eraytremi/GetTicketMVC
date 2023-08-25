namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus
{
    public class UpdateBus
    {
        public int BusID { get; set; }
        public int? BusFirmID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
    }
}
