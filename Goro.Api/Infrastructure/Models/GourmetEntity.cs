using Microsoft.Azure.Documents.Spatial;
using Newtonsoft.Json;

namespace Goro.Api.Infrastructure.Models
{
    public class GourmetEntity : DocumentBase
    {
        [JsonProperty(PropertyName = "season")]
		public int Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
		public int Episode { get; set; }

        [JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

        [JsonProperty(PropertyName = "restaurant")]
		public string Restaurant { get; set; }

        [JsonProperty(PropertyName = "matome")]
		public string Matome { get; set; }


        [JsonProperty(PropertyName = "phoneNumber")]
		public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

        [JsonProperty(PropertyName = "closed")]
		public bool? Closed { get; set; }

        [JsonProperty(PropertyName = "location")]
		public string Location { get; set; }
    }

    public class Location
    {
		[JsonProperty(PropertyName = "lat")]
        public float Lat { get; set; }

		[JsonProperty(PropertyName = "lng")]
        public float Lng { get; set; }
    }

}