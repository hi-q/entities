namespace Entities.Models
{
    public abstract class PageQuery
    {
        protected PageQuery()
        {
            Page = 1;
            Rows = 10;
        }

        public string Sord { get; set; }

        public int Page { get; set; }

        public int Rows { get; set; }

        public SortBy SortBy
        {
            get { return Sord == "desc" ? SortBy.Desc : SortBy.Asc; }
        }

    }
}