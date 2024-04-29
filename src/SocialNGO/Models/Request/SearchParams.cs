using SocialNGO.Common.Constants;

namespace SocialNGO.Models.Request
{
    public class SearchParams : PaginationParams
    {
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        public string? ColumnFilters { get; set; }
    }
}
