
namespace Api.Models
{
    public class MetadataPage
    {
        public int Limit { get; set; }

        public int? PreviousPage { get; set; }

        public int? NextPage { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }
    }
}