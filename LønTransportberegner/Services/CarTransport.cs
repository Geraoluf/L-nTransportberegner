namespace LønTransportberegner.Services
{
    public class CarTransport : ITransportStrategy
    {

        public decimal CalculateCost(decimal distance)
        {
            return distance * 5m;
        }
    }
}
