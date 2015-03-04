namespace Entities.Domain.Abstract.Pages
{
    public abstract class PageQuery
    {
        public int Page { get; set; }

        public int Rows { get; set; }
    }
}
