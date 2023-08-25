namespace GetTicketMVC.Areas.AdminPanel.Models.Dtos
{
    public class NewBusDto
    {
        public int? BusFirmID { get; set; }
        public string? BusPlate { get; set; }
        public string? ModelOfBus { get; set; }
        public int? CapacityOfSeat { get; set; }
    }
}
