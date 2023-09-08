using System;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Data.Interfaces
{
	public interface IProductDataStore
	{
        Product GetProduct(string productIdentifier);

    }
}

