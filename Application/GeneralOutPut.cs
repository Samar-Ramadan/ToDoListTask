namespace Application
{
    public class GeneralOutPut<T>
    {
        public int TotalSize { get; set; }
        public IQueryable<T> Items { get; set; }
    }
}
