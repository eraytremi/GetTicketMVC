namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Passenger
{
    public class GetPassengerList
    {
        public int PassengerID { get; set; }

        public string? PassengerName { get; set; }
        public string? PassengerLastName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? IDNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? RegisterTime { get; set; }
        public string? Gender { get; set; }
    }
}
