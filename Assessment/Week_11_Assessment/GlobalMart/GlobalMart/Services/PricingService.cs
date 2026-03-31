namespace GlobalMart.Services
{
    public class PricingService:IPricingService
    {
        public decimal CalculatePrice(decimal basePrice, string promoCode)
        {
            decimal finalPrice = basePrice;

            if (!string.IsNullOrEmpty(promoCode))
            {
                switch (promoCode.ToUpper())
                {
                    case "WINTER25":
                        finalPrice = basePrice * 0.85m; // 15% off
                        break;

                    case "FREESHIP":
                        finalPrice = basePrice - 5.00m;
                        break;
                }
            }

            return finalPrice < 0 ? 0 : finalPrice;
        }
    }
}
