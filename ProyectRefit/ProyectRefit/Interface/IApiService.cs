
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
        //product
        [Get("/Product/getAll")]
        Task<List<Product>> GetProduct();
        [Post("/Product/create")]
        Task<Product>PostProduct([Body]Product product);
        [Put("update")]
        Task PutProduct([Body]Product product);
        [Delete("/Product/{id}")]
        Task DelateProduct(long id);
        //users
        [Post("/Users/createUser")]
        Task <User>PostUser([Body]User user);
    }
}
