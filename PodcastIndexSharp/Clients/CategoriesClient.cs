namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class CategoriesClient : BaseClient, ICategoriesClient
    {
        public CategoriesClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Category>> List()
        {
            var endpoint = GetAuthorizedRequest("/categories/list");

            var categoriesListResponse = await GetResponse<CategoriesListResponse>(endpoint);

            return categoriesListResponse.Categories;
        }
    }
}