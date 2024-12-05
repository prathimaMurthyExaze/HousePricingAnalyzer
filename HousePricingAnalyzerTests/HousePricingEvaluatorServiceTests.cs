using HousePricingAnalyzer.Services;

namespace HousePricingAnalyzerTests
{
    [TestFixture]
    public class HousePricingEvaluatorServiceTests
    {
        private HousePricingEvaulatorService housePricingService;
        [SetUp]
        public void Setup()
        {
            housePricingService = new HousePricingEvaulatorService();
        }

        [Test]
        public void FindHousePrice_ValidPostalCode_ReturnsPrice()
        {
            string postalCode = "ABC234";

            using(var sw = new StringWriter())
            {
                Console.SetOut(sw);
                housePricingService.GetHousePricing(postalCode);
                var result = sw.ToString().Trim();

                Assert.That(result, Is.EqualTo("Housing at the postal address : ABC234 is priced at \"$45000\""));
            }
        }

        [Test]
        public void InvalidPostalCode_ReturnsNotFound()
        {
            string postalCode = "AB234";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                housePricingService.GetHousePricing(postalCode);
                var result = sw.ToString().Trim();

                Assert.That(result, Is.EqualTo("Pricing details for postal code AB234 unavailable"));
            }
        }
    }
}