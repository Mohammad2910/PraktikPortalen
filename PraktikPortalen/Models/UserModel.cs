namespace PraktikPortalen.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int type { get; set; }
    }
}
