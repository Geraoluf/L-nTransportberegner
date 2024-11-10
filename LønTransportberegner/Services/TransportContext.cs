namespace LønTransportberegner.Services

{
    public class TransportContext
    {
        private ITransportStrategy _transportStrategy;

        public void SetTransportStrategy(ITransportStrategy transportStrategy)
        {
            _transportStrategy = transportStrategy;
        }

        public decimal CalculateTransportCost(decimal distance)
        {
            if (_transportStrategy == null)
                throw new InvalidOperationException("Transport strategy is not set.");

            return _transportStrategy.CalculateCost(distance); // Bruger den valgte strategi
        }
    }

}
