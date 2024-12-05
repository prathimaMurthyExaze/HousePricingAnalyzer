using HousePricingAnalyzer.Interfaces;

namespace HousePricingAnalyzer.Services
{
    public class HousePricingEvaulatorService : IHousePricingEvaluatorInterface
    {
        public void GetHousePricing(string postalCode)
        {

            try
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "HousePricing.csv");

                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line;
                    bool header = true;
                    int postalCodeIndex = -1;
                    int priceIndex = -1;
                    bool found = false;
                    while((line = reader.ReadLine()) != null ) 
                    {
                        string[] columns = line.Split(",");

                        if(header)
                        {
                            postalCodeIndex= Array.IndexOf(columns, "PostalCode");
                            priceIndex= Array.IndexOf(columns, "Price");
                            header = false;
                            continue;
                        }

                        if(postalCodeIndex > -1 && priceIndex > -1)
                        {
                            string currentPostCode = columns[postalCodeIndex].Trim();
                            string currentPrice = columns[priceIndex].Trim();

                            if(currentPostCode.Equals(postalCode, StringComparison.OrdinalIgnoreCase))
                            {
                                found = true;
                                Console.WriteLine($"Housing at the postal address : {currentPostCode} is priced at {currentPrice}");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("PostalCode or Price details not found.");
                        }
                    }
                    if(!found)
                    {
                        Console.WriteLine($"Pricing details for postal code {postalCode} unavailable");
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An exception occured " + ex.Message);
            }
        }
    }
}
