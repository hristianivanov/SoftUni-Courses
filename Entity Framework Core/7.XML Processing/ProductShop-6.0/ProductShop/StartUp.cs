using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            string xmlOutput = GetUsersWithProducts(context);
            File.WriteAllText(@"../../../Results/users-and-products.xml", xmlOutput);

            Console.WriteLine(xmlOutput);
        }
        //TODO: Make the tasks with auto mapper
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            var users = userDtos.Select(userDto => new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age!.Value
            })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            var categories = categoryDtos
                .Where(c => !string.IsNullOrEmpty(c.Name))
                .Select(c => new Category()
                {
                    Name = c.Name!
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlHelper = new XmlHelper();

            var productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            var products = productDtos
                .Select(p => new Product()
                {
                    Name = p.Name!,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId ?? 0,
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var categoryProductDtos =
                xmlHelper.Deserialize<ImportCategoryProduct[]>(inputXml, "CategoryProducts");

            var categoryProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProductDto in categoryProductDtos)
            {
                if (!categoryProductDto.ProductId.HasValue ||
                    !categoryProductDto.CategoryId.HasValue)
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductDto.CategoryId.Value,
                    ProductId = categoryProductDto.ProductId.Value
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductDto()
                {
                    Price = p.Price,
                    Name = p.Name,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            return xmlHelper.Serialize<ExportProductDto[]>(products, "Products");
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.LastName)
                .Take(5)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ExportSoldProductDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(users, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var categories = context.Categories
                .Select(c => new ExportCategoryDto()
                {
                    Name = c.Name,
                    NumberOfProducts = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.NumberOfProducts)
                .ThenBy(u => u.TotalRevenue)
                .ToArray();

            return xmlHelper.Serialize(categories, "Categories");
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var usersInfo = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserInfo()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCount()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new SoldProduct()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUserCountDto exportUserCountDto = new ExportUserCountDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersInfo
            };

            return xmlHelper.Serialize(exportUserCountDto, "Users");
        }
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
    }
}