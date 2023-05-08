namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    /// <summary>
    /// Client for fetching information about Categories used by the PodcastIndex
    /// </summary>
    public class CategoriesClient : BaseClient, ICategoriesClient
    {
        public CategoriesClient(PodcastIndexConfig config) : base(config) { }

        /// <summary>
        /// Returns all of the possible categories supported by the index.
        /// </summary>
        public async Task<List<Category>> List()
        {
            var endpoint = GetAuthorizedRequest("/categories/list");

            var categoriesListResponse = await GetResponse<CategoriesListResponse>(endpoint);

            return categoriesListResponse.Categories;
        }
    }
}