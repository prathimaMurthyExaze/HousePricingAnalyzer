using HousePricingAnalyzer.Interfaces;
using HousePricingAnalyzer.Services;

namespace HousePricingAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter a postal address to check the pricing");
                string postalCode = Console.ReadLine();

                IHousePricingEvaluatorInterface housePricingEvaluator = new HousePricingEvaulatorService();
                housePricingEvaluator.GetHousePricing(postalCode);

                Console.WriteLine("Do you wish to continue ? yes/no ");
                var continueOption = Console.ReadLine();    

                if(continueOption.Equals("no",StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

        }
    }

}