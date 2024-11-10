namespace LønTransportberegner.Services
{
    public class ElectricBike : ITransportStrategy
    {
        public decimal CalculateCost(decimal distance)
        {
            return distance * 2;
        }
    }
}
