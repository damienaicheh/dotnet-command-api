using CommandAPI.Models;

namespace CommandAPI.Services
{
    public interface IProfitService
    {
        Profit CalculateNetMargin(int numberOfProducts, double sellingPrice);
    }

    public class ProfitService : IProfitService
    {
        public Profit CalculateNetMargin(int numberOfProducts, double sellingPrice)
        {
            double productionCost = 1.0;
            double operationCostUnder50 = 15.0;
            double operationCostOver50 = 5.0;
            double taxUnder50 = 0.10;
            double taxOver50 = 0.02;

            double totalRevenue = numberOfProducts * sellingPrice;
            double totalProductionCost = numberOfProducts * productionCost;
            double tax = numberOfProducts < 50 ? totalRevenue * taxUnder50 : totalRevenue * taxOver50;
            double operationCost = numberOfProducts < 50 ? operationCostUnder50 : operationCostOver50;

            double netMargin = totalRevenue - totalProductionCost - tax - operationCost;

            return new Profit()
            {
                NumberOfProducts = numberOfProducts,
                SellingPrice = sellingPrice,
                NetMargin = netMargin
            };
        }
    }
}