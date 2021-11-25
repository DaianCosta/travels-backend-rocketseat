using System.Collections.Generic;

namespace Api.Models
{
    public class GetTravelMetadata
    {
        public List<GetTravel> results { get; set; }

        public Metadata metadata { get; set; }
    }
}
