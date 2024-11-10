namespace LønTransportberegner.Services
{
    public interface ITransportStrategy
    {
        decimal CalculateCost(decimal distance); 
    }
}
