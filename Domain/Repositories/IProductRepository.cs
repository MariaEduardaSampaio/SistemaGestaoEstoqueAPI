using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        Product ReadProductByID(int id);
        Product ReadProductByName(string name);
        IEnumerable<Product> ReadAllProductsByDisponibility(bool disponibility);
        IEnumerable<Product> ReadAllProducts();
        void UpdateProduct(Product product);
        Product DeleteProduct(int id);
    }
}
