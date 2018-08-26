

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Goro.Api.Infrastructure.Models;
using Microsoft.Azure.Documents.Spatial;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;

namespace Goro.Api.Infrastructure
{
    public static class GourmetClient
    {
        // Sortable epsode,season,location
        // Filterble location
        // Retreive all
        // searchable all
        private const string azureSearchName = "goro";
        private const string azureSearchKey = "606C7141783D5ED5AAF11228EAAC03F5";
        private const string indexName = "gourment-index";

        public static async Task<IEnumerable<GourmetEntity>> Search()
        {
            var searchClient = new SearchServiceClient(azureSearchName, new SearchCredentials(azureSearchKey));
            var indexClient = searchClient.Indexes.GetClient(indexName);

            var parameters = new SearchParameters()
            {
                OrderBy = new[] { "season asc", "episode asc" },
                Top = 1000
            };
            // https://docs.microsoft.com/en-us/rest/api/searchservice/OData-Expression-Syntax-for-Azure-Search

            var gourmetList = new List<GourmetEntity>();
            var results = await indexClient.Documents.SearchAsync<GourmetEntity>("*", parameters);
            foreach (var gourment in results.Results)
            {
                gourmetList.Add(gourment.Document);
            }
            return gourmetList;
        }

        public static async Task Search(double lng, double lat)
        {
            var searchClient = new SearchServiceClient(azureSearchName, new SearchCredentials(azureSearchKey));
            var indexClient = searchClient.Indexes.GetClient(indexName);

            var geo = string.Format("geo.distance(location, geography'POINT({0} {1})')", lng, lat);
            var parameters = new SearchParameters()
            {
                //Select = new[] { "title" },
                //Filter = "season eq 2",
                //OrderBy = new[] { "season asc", "episode asc" },
                OrderBy = new[] { geo },
                
                Top = 100
            };
            // https://docs.microsoft.com/en-us/rest/api/searchservice/OData-Expression-Syntax-for-Azure-Search

            var gourmetList = new List<GourmetEntity>();
            var results = await indexClient.Documents.SearchAsync<GourmetEntity>("*", parameters);
            foreach (var gourment in results.Results)
            {
                var title = gourment.Document.Title;
                gourmetList.Add(gourment.Document);
            }
            
            var continuationToken = results.ContinuationToken;
            while (continuationToken != null)
            {
                // Skip 50 にしか対応していない
                if (parameters.Skip == null)
                {
                    parameters.Skip = 0;
                }
                parameters.Skip += 50;

                var temp = await indexClient.Documents.SearchAsync<GourmetEntity>("*", parameters);
                foreach (var gourment in temp.Results)
                {
                    var title = gourment.Document.Title;
                    gourmetList.Add(gourment.Document);
                }
                continuationToken = temp.ContinuationToken;
            }
        }
    }

}