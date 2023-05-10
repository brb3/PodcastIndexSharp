namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface ICategoriesClient
    {
        /// <summary>
        /// Return all the possible categories supported by the index.
        /// </summary>
        Task<List<Category>> List();
    }
}