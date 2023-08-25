namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes
{
    public class AccessTokenItem
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<string> Claims { get; set; }
    }
}
