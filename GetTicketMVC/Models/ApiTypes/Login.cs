namespace GetTicketMVC.Models.ApiTypes
{
    public class Login
    {
        public int PassengerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerLastName { get; set; }
        public string? Phone { get; set; }

    }
}
