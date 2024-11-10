namespace LønTransportberegner.Services
{
    public class publicTransport : ITransportStrategy   
    {

        public decimal CalculateCost(decimal distance)
        {
          return distance * 10;
        }
    }
}
