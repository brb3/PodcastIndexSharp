namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class CategoriesClient : BaseClient, ICategoriesClient
    {
        public CategoriesClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Category>> List()
        {
            var categoriesListResponse = await SendRequest<CategoriesListResponse>("categories/list", new ApiParameter[] { });
            return categoriesListResponse.Categories;
        }
    }
}