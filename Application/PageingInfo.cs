namespace Application
{
    public class PageingInfo
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string? Search { get; set; }
        public string? OrderBy { get; set; }
        public bool Reverse { get; set; } = false;
    }
}
