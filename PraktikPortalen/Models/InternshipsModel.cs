namespace PraktikPortalen.Models
{
    public class InternshipsModel
    {
        public int InternshipId { get; set; }
        public string InternshipName { get; set; } = string.Empty;
        public string InternshipCompany { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int user_id { get; set; }
        public int DTUSupervisor_id { get; set; }
        public int CompanySupervisor_id { get; set; }
    }
}
