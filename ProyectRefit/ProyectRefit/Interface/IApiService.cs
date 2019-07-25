
namespace ProyectRefit.Interface
{
    using ProyectRefit.Models;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IApiService
    {
        [Get("/posts")]
        Task<List<Post>> GET();
        [Get("/Product")]
        Task<List<Product>> GetProduct();
        [Post("/Product")]
        Task PostProduct([Body] Product product);

    }
}
