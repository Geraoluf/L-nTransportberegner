namespace LønTransportberegner.Services

{
    public class TransportContext
    {
        private ITransportStrategy? _transportStrategy;

       
            public void SetTransportStrategy(ITransportStrategy? transportStrategy)
            {
                if (transportStrategy == null)
                {
                    throw new ArgumentNullException(nameof(transportStrategy), "kan ikke være null.");
                }

                _transportStrategy = transportStrategy;
            }

        

        public decimal CalculateTransportCost(decimal distance)
        {
            if (_transportStrategy == null)
                throw new InvalidOperationException("Transport strategy er ikke sat.");

            return _transportStrategy.CalculateCost(distance); 
        }
    }

}
