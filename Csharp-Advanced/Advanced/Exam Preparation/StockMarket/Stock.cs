using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = PricePerShare * TotalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Company: {CompanyName}");
            stringBuilder.AppendLine($"Director: {Director}");
            stringBuilder.AppendLine($"Price per share: ${PricePerShare}");
            stringBuilder.AppendLine($"Market capitalization: ${MarketCapitalization}");
            return stringBuilder.ToString().Trim();
        }
    }
}
