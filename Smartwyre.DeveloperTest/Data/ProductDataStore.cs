using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Product();
    }
}
