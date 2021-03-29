using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.ProductBrands.Any()) // if no brands are available
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach (var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.ProductBrands.Any()) // if no brands are available
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach (var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.ProductTypes.Any()) // if no brands are available
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(brandData);

                    foreach (var productType in types)
                    {
                        storeContext.ProductTypes.Add(productType);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.Products.Any()) // if no brands are available
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        storeContext.Products.Add(product);
                    }

                    await storeContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();

                logger.LogError(ex.Message);
            }
        }
        
    }
}
