using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }
        public int Count { get { return this.Portfolio.Count; } }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            if (stock.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.SingleOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count() == 0)
                return null;
            Stock stock = Portfolio.OrderByDescending(x => x.MarketCapitalization).First();
            return stock;
        }

        public string InvestorInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            Portfolio.ForEach(stock => stringBuilder.AppendLine(stock.ToString()));
            return stringBuilder.ToString().Trim();
        }
    }
}
