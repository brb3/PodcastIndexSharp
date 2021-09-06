namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface ICategoriesClient
    {
        Task<List<Category>> List();
    }
}