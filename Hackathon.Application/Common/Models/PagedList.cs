namespace Hackathon.Application.Common.Models
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData 
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int) Math.Ceiling( count / (double)pageSize)
            };
            AddRange(items);    
        }

        public static PagedList<T> ToPageList(List<T> source, int count, int pageNumber, int pageSize)
        {
            return new PagedList<T>(source, count, pageNumber, pageSize);
        }
    }
}