namespace digiturkProject.Models
{
    public class PackageModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public List<string> Features { get; set; }
        public string Url { get; set; }
    }
}
