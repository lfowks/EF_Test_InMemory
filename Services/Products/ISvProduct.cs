using Entidades;
namespace Services.Products
{
    public interface ISvProduct
    {
        //READS
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);

        //WRITES
        public Product AddProduct(Product author);
        public Product UpdateProduct(int id, Product author);
        public void DeleteProduct(int id);
    }
}
