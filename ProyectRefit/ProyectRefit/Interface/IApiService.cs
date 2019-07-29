
namespace ProyectRefit.Interface
{
    using ProyectRefit.Models;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    [Headers("ContentType", "application/json")]
    public interface IApiService
    {
        [Get("/posts")]
        Task<List<Post>> GET();
        [Get("/Product")]
        Task<List<Product>> GetProduct();
        [Post("/Product/create")]
        Task<Product>PostProduct([Body]Product product);
        //users
        [Post("/User/createUser")]
        Task <User>PostUser([Body]User user);
    }
}
