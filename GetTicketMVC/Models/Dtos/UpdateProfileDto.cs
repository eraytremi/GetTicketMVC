namespace GetTicketMVC.Models.Dtos
{
    public class UpdateProfileDto
    {
        public int PassengerID { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerLastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IDNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? RegisterTime { get; set; }
    }
}
