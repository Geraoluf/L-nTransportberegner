namespace LønTransportberegner.Services

{
    public class TransportContext
    {
        private ITransportStrategy? _transportStrategy;

       
            public void SetTransportStrategy(ITransportStrategy? transportStrategy)
            {
                if (transportStrategy == null)
                {
                    throw new ArgumentNullException(nameof(transportStrategy), "Transport strategy cannot be null.");
                }

                _transportStrategy = transportStrategy;
            }

        

        public decimal CalculateTransportCost(decimal distance)
        {
            if (_transportStrategy == null)
                throw new InvalidOperationException("Transport strategy is not set.");

            return _transportStrategy.CalculateCost(distance); 
        }
    }

}
