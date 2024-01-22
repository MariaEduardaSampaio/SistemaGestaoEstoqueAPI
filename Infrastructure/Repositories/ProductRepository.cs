using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetService<DataContext>();
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> ReadAllProducts()
        {
            // antes tinha asNoTracking() antes do where
            return _context.Products.OrderBy(product => product.Name).ToList();
        }

        public IEnumerable<Product> ReadAllProductsByDisponibility(bool disponibility)
        {
            return _context.Products.Where(product => product.IsAvailable == disponibility).OrderBy(product => product.Name).ToList();
        }

        public Product ReadProductByID(int id)
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                throw new ArgumentException("Não existe produto com este ID.");

            return product;
        }

        public Product ReadProductByName(string name)
        {
            var product = _context.Products.FirstOrDefault(product => product.Name == name);
            if (product == null)
                throw new ArgumentException("Não existe produto com este nome.");

            return product;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public Product DeleteProduct(int id)
        {
            var product = ReadProductByID(id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }
    }
}
