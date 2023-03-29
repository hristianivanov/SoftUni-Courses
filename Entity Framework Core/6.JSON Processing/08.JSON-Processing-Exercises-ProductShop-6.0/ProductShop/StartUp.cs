namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Data;
    using DTOs.Export;
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {

            ProductShopContext context = new ProductShopContext();
            //string inputJson = File.ReadAllText(@"../../../DataSets/categories-products.json");
            //string result = ImportCategoryProducts(context,inputJson);

            string output = GetUsersWithProducts(context);

            Console.WriteLine(output);
        }
        private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()));
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos =
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson)!;

            //Mapping to one user and getting the info 
            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto useeDto in userDtos)
            {
                User user = mapper.Map<User>(useeDto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productDtos =
                JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson)!;

            //Mapping to Collection
            var products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos =
                JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)!;

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
                    continue;

                Category category = mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson)!;

            var products = mapper.Map<CategoryProduct[]>(categoryProductDtos);
            context.CategoriesProducts.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer!.FirstName,
                            buyerLastName = ps.Buyer!.LastName
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(usersWithSoldProducts, settings);
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(p => p.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, settings);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
                
            };

            var userAndProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = userAndProducts.Length,
                Users = userAndProducts
            };

            return JsonConvert.SerializeObject(userWrapperDto, settings);
        }
    }
}