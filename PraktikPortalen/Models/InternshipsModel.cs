namespace PraktikPortalen.Models
{
    public class InternshipsModel
    {

        public InternshipsModel(List<string> internships)
        {
            Internships = internships;
        }

        public List<String> Internships { get; set; }
    }
}
