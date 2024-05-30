using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;

namespace Services.Products
{
    public class SvProduct : ISvProduct
    {
        private MyContext _myDbContext = default!;
        public SvProduct()
        {
            _myDbContext = new MyContext();
        }

        #region Reads
        public List<Product> GetAllProducts()
        {
            return _myDbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {       //_myDbContext.Products.Find(id)
            return _myDbContext.Products.SingleOrDefault(x => x.Id == id);
        }
        #endregion

        #region Writes
        public Product AddProduct(Product author)
        {
            _myDbContext.Products.Add(author);
            _myDbContext.SaveChanges();

            return author;
        }
        public void DeleteProduct(int id)
        {
            Product deleteProduct = _myDbContext.Products.Find(id);

            if (deleteProduct is not null)
            {
                _myDbContext.Products.Remove(deleteProduct);
                _myDbContext.SaveChanges();
            }
        }
        public Product UpdateProduct(int id, Product newProduct)
        {
            Product updateProduct = _myDbContext.Products.Find(id);

            if (updateProduct is not null)
            {
                updateProduct.Title = newProduct.Title;
                updateProduct.Stock = newProduct.Stock;
                updateProduct.Price = newProduct.Price;

                _myDbContext.Products.Update(updateProduct);
                _myDbContext.SaveChanges();
            }

            return updateProduct;

        }

        #endregion

        #region Utils
        public void ShowAll()
        {
            List<Product> authors = GetAllProducts();
            foreach (var item in authors)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price);
                Console.WriteLine("-----------------");
            }
        }
        #endregion

    }
}
